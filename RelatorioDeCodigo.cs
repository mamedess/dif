using System;
using System.Collections.Generic;
using System.Text;

namespace dif
{
    public class RelatorioDeCodigo(int totalArquivos = 0, int totalLinhas = 0)
    {
        public int TotalArquivos { get; set; } = totalArquivos;
        public int TotalLinhas { get; set; } = totalLinhas;
    }
}
