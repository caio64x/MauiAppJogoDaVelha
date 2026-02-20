# Jogo da Velha (MAUI)

Aplicativo simples de Jogo da Velha (tic-tac-toe) desenvolvido com .NET MAUI (alvo: .NET 10).

## Descrição

- Interface construída com `Grid` em `MainPage.xaml`.
- Alterna jogadas entre `X` e `O`.
- Detecta vitória (linhas, colunas, diagonais) e empate.
- Reinicia o tabuleiro automaticamente ao fim da partida.

## Pré-requisitos

- .NET 10 SDK
- .NET MAUI workload:

```sh
dotnet workload install maui
```

- Visual Studio com suporte a .NET MAUI (recomendado) ou ambiente CLI com targets configurados.

## Estrutura principal

- `MainPage.xaml` — layout do tabuleiro.
- `MainPage.xaml.cs` — lógica do jogo (cliques, verificação de vitória/empate, reset).
- `App.xaml` / `AppShell.xaml` — bootstrap da aplicação.

## Instalação e execução

Com Visual Studio
1. Abra `MauiAppJogoDaVelha.sln`.
2. Selecione o projeto e o target (Android / iOS / Windows / MacCatalyst).
3. Execute (F5).

Com dotnet CLI (build)

```sh
dotnet restore
dotnet build
# Build para Android (exemplo)
dotnet build -f net10.0-android
```

Observação: deploy/emulação depende do setup da sua máquina — usar o Visual Studio é mais simples para deploy.

## Como jogar

- Toque/clique em uma célula para marcar `X` ou `O`.
- Não é possível sobrescrever uma jogada já feita.
- Ao detectar vitória ou empate, um alerta é exibido e o tabuleiro é reiniciado.

## Funcionalidades

- Prevenção de sobrescrever jogadas.
- Verificação de vencedor (linhas, colunas, diagonais).
- Detecção de empate.
- Reset recursivo dos botões (limpa texto e reabilita).
- Ajustes de nulabilidade e uso de pattern matching para segurança.

## Testes rápidos

1. Executar o app em um emulador/dispositivo.
2. Jogar normalmente e verificar:
   - Vitória detectada corretamente.
   - Empate detectado quando todas as células estiverem preenchidas sem vencedor.
   - Tabuleiro limpa após alerta.

## Licença

Escolha conforme sua preferência (ex.: MIT). Adicione arquivo `LICENSE` se desejar.

---

Se quiser, eu também gero:
- `LICENSE` (ex.: MIT),
- `CHANGELOG.md`,
- instruções de CI (GitHub Actions) para build MAUI.

