using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Models
{
    public class PaginaMemoria
    {
        public float TamanhoMB { get; private set; }

        public PaginaMemoria(float tamanhoMB)
        {
            TamanhoMB = tamanhoMB;
        }
    }
}
