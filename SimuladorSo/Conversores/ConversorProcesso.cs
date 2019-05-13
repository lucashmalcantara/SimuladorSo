﻿using SimuladorSo.Dtos;
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
            return new ProcessoDto
            {
                Nome = processo.Nome,
                TamanhoMB = processo.TamanhoEmMB,
                PaginasMemoria = processo.PaginasMemoria.ConverterParaPaginaMemoriaDto()
            };
        }

        public static List<ProcessoDto> Converter(IEnumerable<Processo> processos)
        {
            return processos.Select(p => Converter(p)).ToList();
        }

        public static Processo Converter(ProcessoDto processo)
        {
            return new Processo
            {
                Nome = processo.Nome,
                TamanhoEmMB = processo.TamanhoMB
            };
        }

        public static List<Processo> Converter(IEnumerable<ProcessoDto> processos)
        {
            return processos.Select(p => Converter(p)).ToList();
        }
    }
}
