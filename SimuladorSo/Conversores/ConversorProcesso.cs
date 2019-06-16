using SimuladorSo.Dtos;
using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Conversores
{
    public class ConversorProcesso
    {
        public static ProcessoDto Converter(Processo processo)
        {
            if (processo == null)
                return null;

            return new ProcessoDto
            {
                EnderecoLogico = processo.EnderecoLogico,
                Nome = processo.Nome,
                TamanhoMB = processo.TamanhoEmMB,
                PaginasMemoria = processo.PaginasMemoria.ConverterParaPaginaMemoriaDto(),
                DuracaoSurto = processo.DuracaoSurto,
                Chegada = processo.Chegada
            };
        }

        public static List<ProcessoDto> Converter(IEnumerable<Processo> processos)
        {
            return processos.Select(p => Converter(p)).ToList();
        }

        public static Processo Converter(ProcessoDto processo)
        {
            if (processo == null)
                return null;

            return new Processo
            {
                EnderecoLogico = processo.EnderecoLogico,
                Nome = processo.Nome,
                TamanhoEmMB = processo.TamanhoMB,
                DuracaoSurto = processo.DuracaoSurto
            };
        }

        public static List<Processo> Converter(IEnumerable<ProcessoDto> processos)
        {
            return processos.Select(p => Converter(p)).ToList();
        }
    }
}
