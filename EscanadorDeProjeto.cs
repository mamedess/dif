namespace dif
{
    public class EscaneadorDeProjeto(string[] pastasIgnoradas)
    {
        public RelatorioDeCodigo AnalisarPasta(string caminho)
        {
            var pasta = new DirectoryInfo(caminho);
            int totalLinhas = 0;
            int totalArquivos = 0;
            foreach (var arquivo in pasta.GetFiles())
            {
                try
                {
                    totalLinhas += File.ReadLines(arquivo.FullName).Count();
                    totalArquivos += 1;
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
            }

            return new(totalArquivos, totalLinhas);
        }
    }


}
