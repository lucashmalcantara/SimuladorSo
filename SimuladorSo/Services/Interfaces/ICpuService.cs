using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services.Interfaces
{
    public interface ICpuService
    {
        void Carregar(Processo processo);
        void Executar(ref Processo processo);
    }
}
