using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace dif
{
    public class ContarLinhasSettings : CommandSettings
    {
        [CommandArgument(0, "[CAMINHO]")]
        [Description("Caminho para o diretório ou arquivo a ser analisado. Se não for fornecido, o diretório atual será usado.")]
        public string? Caminho { get; set; }
        
        [CommandOption("-i|--ignore <PASTAS>")]
        [Description("Pastas a serem ignoradas durante a análise.")]
        public string? PastasIgnoradas { get; set; }
        
        [CommandOption("-d|--detalhes")]
        [Description("Mostra os arquivos lidos um por um no terminal")] 
        public bool MostrarDetalhes { get; set; }
    }
}
