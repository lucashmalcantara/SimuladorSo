using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Dtos
{
    public class ProcessoDto
    {
        public string Nome { get; set; }
        public float TamanhoMB { get; set; }

        public List<PaginaMemoriaDto> PaginasMemoria { get; set; }

        public override string ToString()
        {
            var informacoesProcesso = new StringBuilder();
            informacoesProcesso.AppendLine(Nome);
            informacoesProcesso.AppendLine($"Tamanho: {TamanhoMB}MB");

            if (PaginasMemoria != null)
                informacoesProcesso.AppendLine($"Quantidade páginas memória: {PaginasMemoria.Count} (total: {PaginasMemoria.Sum(p => p.TamanhoMB)}MB)");

            return informacoesProcesso.ToString();
        }
    }
}
