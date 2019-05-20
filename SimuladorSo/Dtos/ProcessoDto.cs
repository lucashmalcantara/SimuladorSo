using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Dtos
{
    public class ProcessoDto
    {
        public string EnderecoLogico { get; set; }
        public string Nome { get; set; }
        public float TamanhoMB { get; set; }
        public List<PaginaMemoriaDto> PaginasMemoria { get; set; }
        public int DuracaoSurto { get; set; }
        public DateTime Chegada { get; set; }
        public override string ToString()
        {
            var informacoesProcesso = new StringBuilder();
            informacoesProcesso.AppendLine(Nome);
            informacoesProcesso.AppendLine($"Tamanho: {TamanhoMB}MB");

            if (PaginasMemoria != null)
                informacoesProcesso.AppendLine($"Quantidade páginas memória: {PaginasMemoria.Count} (total: {PaginasMemoria.Sum(p => p.TamanhoMB)}MB)");

            informacoesProcesso.AppendLine($"Duração surto: {DuracaoSurto}");
            informacoesProcesso.AppendLine($"Hora Chegada: {Chegada.ToString("HH:mm:ss.fff")}");

            return informacoesProcesso.ToString();
        }
    }
}
