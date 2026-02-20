namespace MauiAppJogoDaVelha
{
    public partial class MainPage : ContentPage
    {
        string vez = "X";
        public MainPage()
        {
            InitializeComponent();
        }



        private async void Button_Clicked(object? sender, EventArgs e)
        {
            if (sender is not Microsoft.Maui.Controls.Button btn)
                return;

            // Evita sobrescrever uma jogada já feita
            if (!string.IsNullOrEmpty(btn.Text))
                return;

            // Marca a jogada e desabilita o botão
            btn.Text = vez;
            btn.IsEnabled = false;

            // Verificar vitória
            var vencedor = CheckWinner();
            if (!string.IsNullOrEmpty(vencedor))
            {
                await DisplayAlertAsync("Resultado", $"Jogador {vencedor} venceu!", "OK");
                ZerarJogo();
                return;
            }

            // Verificar empate
            if (IsDraw())
            {
                await DisplayAlertAsync("Resultado", "Empate!", "OK");
                ZerarJogo();
                return;
            }

            // Trocar vez
            vez = vez == "X" ? "O" : "X";
        }

        void ZerarJogo()
        {
            // Limpar todos os botões na página (percorrendo recursivamente)
            LimparBotoes(Content);
            vez = "X"; // Reiniciar a vez para o jogador X
        }

        static void LimparBotoes(Microsoft.Maui.IView? view)
        {
            if (view == null)
                return;

            if (view is Microsoft.Maui.Controls.Button btn)
            {
                btn.Text = string.Empty;
                btn.IsEnabled = true;
                return;
            }

            if (view is Microsoft.Maui.Controls.Layout layout)
            {
                foreach (var child in layout.Children)
                    LimparBotoes(child);
            }
        }

        Microsoft.Maui.Controls.Button?[,] GetButtonsGrid()
        {
            var result = new Microsoft.Maui.Controls.Button?[3, 3];

            if (Content is Microsoft.Maui.Controls.Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    if (child is Microsoft.Maui.Controls.Button b)
                    {
                        int row = Microsoft.Maui.Controls.Grid.GetRow(b);
                        int col = Microsoft.Maui.Controls.Grid.GetColumn(b);
                        // Os botões estão nas linhas 1..3 no XAML (linha 0 é o label)
                        if (row >= 1 && row <= 3 && col >= 0 && col <= 2)
                            result[row - 1, col] = b;
                    }
                }
            }

            return result;
        }

        string? CheckWinner()
        {
            var b = GetButtonsGrid();
            if (b == null) return null;

            // Linhas
            for (int r = 0; r < 3; r++)
            {
                var a = b[r, 0]?.Text;
                if (!string.IsNullOrEmpty(a) && a == b[r, 1]?.Text && a == b[r, 2]?.Text)
                    return a;
            }

            // Colunas
            for (int c = 0; c < 3; c++)
            {
                var a = b[0, c]?.Text;
                if (!string.IsNullOrEmpty(a) && a == b[1, c]?.Text && a == b[2, c]?.Text)
                    return a;
            }

            // Diagonais
            var d = b[0, 0]?.Text;
            if (!string.IsNullOrEmpty(d) && d == b[1, 1]?.Text && d == b[2, 2]?.Text)
                return d;

            d = b[0, 2]?.Text;
            if (!string.IsNullOrEmpty(d) && d == b[1, 1]?.Text && d == b[2, 0]?.Text)
                return d;

            return null;
        }

        bool IsDraw()
        {
            var b = GetButtonsGrid();
            if (b == null) return false;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (string.IsNullOrEmpty(b[r, c]?.Text))
                        return false;

            // Se não há vencedor e todas as células preenchidas, é empate
            return CheckWinner() == null;
        }

        

    }
}
