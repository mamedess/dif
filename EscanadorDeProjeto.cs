namespace dif
{
    public class EscaneadorDeProjeto(string[] pastasIgnoradas)
    {
        public RelatorioDeCodigo AnalisarPasta(string caminho)
        {
            var pasta = new DirectoryInfo(caminho);
            int totalLinhas = 0;
            int totalArquivos = 0;
            Dictionary<string,int> linhasPorExtensao = [];

            foreach (var arquivo in pasta.GetFiles())
            {
                try
                {
                    totalLinhas += File.ReadLines(arquivo.FullName).Count();
                    totalArquivos += 1;
                    
                    if (!linhasPorExtensao.ContainsKey(arquivo.Extension))
                        linhasPorExtensao[arquivo.Extension] = 0;

                    linhasPorExtensao[arquivo.Extension] = totalLinhas;
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

                var relatorioDaSubpasta = AnalisarPasta(subpasta.FullName);

                totalLinhas += relatorioDaSubpasta.TotalLinhas;
                totalArquivos += relatorioDaSubpasta.TotalArquivos;
                foreach (var kvp in relatorioDaSubpasta.LinhasPorExtensao)
                {
                    if (!linhasPorExtensao.ContainsKey(kvp.Key))
                        linhasPorExtensao[kvp.Key] = 0;

                    linhasPorExtensao[kvp.Key] += kvp.Value;
                }
            }

            return new(totalArquivos, totalLinhas, linhasPorExtensao);
        }
    }


}
