namespace dif
{
    public class RelatorioDeCodigo(int totalArquivos, int totalLinhas, Dictionary<string, int> linhasPorExtensao)
    {
        public int TotalArquivos { get; set; } = totalArquivos;
        public int TotalLinhas { get; set; } = totalLinhas;
        public Dictionary<string, int> LinhasPorExtensao { get; set; } = linhasPorExtensao;
    }
}
