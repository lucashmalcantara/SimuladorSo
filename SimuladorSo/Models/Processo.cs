﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Models
{
    public class Processo
    {
        public string Nome { get; set; }
        public float TamanhoEmMB { get; set; }
        public string EnderecoLogico { get; set; }
        public List<PaginaMemoria> PaginasMemoria { get; set; }
        public DateTime UltimaExecucao { get; set; }
        public DateTime Chegada { get; set; }
        public int DuracaoSurto { get; set; }
    }
}
