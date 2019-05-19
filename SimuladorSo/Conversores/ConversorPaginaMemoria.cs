using SimuladorSo.Dtos;
using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Conversores
{
    public class ConversorPaginaMemoria
    {
        public static PaginaMemoriaDto Converter(PaginaMemoria paginaMemoria)
        {
            if (paginaMemoria == null)
                return null;

            return new PaginaMemoriaDto(paginaMemoria.TamanhoMB);
        }

        public static List<PaginaMemoriaDto> Converter(List<PaginaMemoria> paginaMemoria)
        {
            if (paginaMemoria == null || paginaMemoria.Count == 0)
                return null;

            return paginaMemoria.Select(p => Converter(p)).ToList();
        }
    }
}
