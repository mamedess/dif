using Spectre.Console;
using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace dif
{
    public class ContarLinhasCommand : Command<ContarLinhasSettings>
    {
        protected override int Execute([NotNull] CommandContext context, [NotNull] ContarLinhasSettings settings, CancellationToken ct)
        {
            string caminho = settings.Caminho ?? EncontrarRaizDoProjeto(Environment.CurrentDirectory);
            string[] ignorados = settings.PastasIgnoradas?.Split(',') ?? [];
            string ignoradosTexto = ignorados.Length == 0 ? "(nenhuma)" : string.Join(", ", ignorados);

            AnsiConsole.MarkupLine($"[green]Iniciando análise em:[/] {caminho}");
            AnsiConsole.MarkupLine($"[yellow]Ignorando as pastas:[/] {Markup.Escape(ignoradosTexto)}");

            if (settings.MostrarDetalhes)
                AnsiConsole.MarkupLine("[gray]Modo detalhado ativado...[/]");

            RelatorioDeCodigo resultado = 
                new EscaneadorDeArquivos(ignorados).AnalisarPasta(caminho, settings.MostrarDetalhes, settings.ExtensoesExclusivas);

            AnsiConsole.MarkupLine($"Total de Arquivos: [yellow]{resultado.TotalArquivos}[/]");
            AnsiConsole.MarkupLine($"Total de Linhas: [yellow]{resultado.TotalLinhas}[/]");
            AnsiConsole.MarkupLine($"Total de Linhas Por Extensão: ");
            
            foreach(var kvp in resultado.LinhasPorExtensao)
                AnsiConsole.MarkupLine($" {kvp.Key}: [yellow]{kvp.Value}[/]");

            return 0;
        }

        private static string EncontrarRaizDoProjeto(string pastaAtual)
        {
            var diretorio = new DirectoryInfo(pastaAtual);

            while (diretorio != null)
            {
                bool ehRaiz = diretorio.GetFiles("*.csproj").Length > 0;

                if (ehRaiz)
                {
                    return diretorio.FullName;
                }

                diretorio = diretorio.Parent;
            }

            return pastaAtual;
        }
    }
}
