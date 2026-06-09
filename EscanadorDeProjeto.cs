using Spectre.Console;

namespace dif
{
    public class EscaneadorDeArquivos(string[] pastasIgnoradas)
    {
        public RelatorioDeCodigo AnalisarPasta(string caminho, bool mostrarDetalhes, string? extensoesAnalise, int profundidade = 1)
        {
            var pasta = new DirectoryInfo(caminho);
            int _totalLinhas = 0;
            int _totalArquivos = 0;
            int _profundidade = profundidade;

            Dictionary<string,int> linhasPorExtensao = [];

            foreach (var arquivo in pasta.GetFiles())
            {
                try
                {
                    if (string.IsNullOrEmpty(arquivo.Extension) || (extensoesAnalise is not null && !extensoesAnalise.Contains(arquivo.Extension)))
                        continue;

                    _totalLinhas += File.ReadLines(arquivo.FullName).Count();
                    _totalArquivos += 1;
                    
                    if (!linhasPorExtensao.ContainsKey(arquivo.Extension))
                        linhasPorExtensao[arquivo.Extension] = 0;

                    linhasPorExtensao[arquivo.Extension] += File.ReadLines(arquivo.FullName).Count();
                    
                    if (mostrarDetalhes)
                    {
                        string detalhe = $"[gray]{(_profundidade > 1 ? "├─" : "")}[/] Lendo arquivo: [yellow]{arquivo.Name}[/]: {_totalLinhas}";
                        AnsiConsole.MarkupLine($"{detalhe.PadLeft(_profundidade + detalhe.Length)}");
                    }
                }
                catch (IOException)
                {
                    continue;
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }

            foreach (var subpasta in pasta.GetDirectories())
            {
                if (pastasIgnoradas.Contains(subpasta.Name))
                    continue;

                int profundidadeAtual = _profundidade + 1;
                
                if (mostrarDetalhes)
                {
                    string detalhe = $"Lendo subpasta: [yellow]{subpasta.Name}[/]";
                    AnsiConsole.MarkupLine(detalhe.PadLeft(profundidadeAtual + detalhe.Length));
                }

                var relatorioDaSubpasta = AnalisarPasta(subpasta.FullName, mostrarDetalhes, extensoesAnalise, profundidadeAtual);

                _totalLinhas += relatorioDaSubpasta.TotalLinhas;
                _totalArquivos += relatorioDaSubpasta.TotalArquivos;
                _profundidade = profundidadeAtual;

                foreach (var kvp in relatorioDaSubpasta.LinhasPorExtensao)
                {
                    if (!linhasPorExtensao.ContainsKey(kvp.Key))
                        linhasPorExtensao[kvp.Key] = 0;

                    linhasPorExtensao[kvp.Key] += kvp.Value;
                }
            }

            return new(_totalArquivos, _totalLinhas, linhasPorExtensao);
        }
    }
}
