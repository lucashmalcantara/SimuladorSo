using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Dtos
{
   public class PaginaMemoriaDto
    {
        public float TamanhoMB { get; set; }

        public PaginaMemoriaDto(float tamanhoMB)
        {
            TamanhoMB = tamanhoMB;
        }
    }
}
