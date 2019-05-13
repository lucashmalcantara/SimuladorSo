using SimuladorSo.Dtos;
using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Conversores
{
    public static class MetodosExtensao
    {
        public static ProcessoDto ConverterParaProcessoDto(this Processo processo)
        {
            return ConversorProcesso.Converter(processo);
        }

        public static List<ProcessoDto> ConverterParaProcessoDto(this List<Processo> processos)
        {
            return ConversorProcesso.Converter(processos);
        }

        public static Processo ConverterParaProcesso(this ProcessoDto processo)
        {
            return ConversorProcesso.Converter(processo);
        }

        public static List<Processo> ConverterParaProcesso(this List<ProcessoDto> processos)
        {
            return ConversorProcesso.Converter(processos);
        }

        public static PaginaMemoriaDto ConverterParaPaginaMemoriaDto(this PaginaMemoria paginaMemoria)
        {
            return ConversorPaginaMemoria.Converter(paginaMemoria);
        }

        public static List<PaginaMemoriaDto> ConverterParaPaginaMemoriaDto(this List<PaginaMemoria> paginasMemoria)
        {
            return ConversorPaginaMemoria.Converter(paginasMemoria);
        }
    }
}
