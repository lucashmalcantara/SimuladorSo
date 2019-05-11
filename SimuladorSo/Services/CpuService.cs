using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimuladorSo.Services.Interfaces;

namespace SimuladorSo.Services
{
    public class CpuService : ICpuService
    {
        public void CarregarMemoriaPrincipal(Processo processo)
        {
            throw new NotImplementedException();
        }

        public void Executar(ref Processo processo)
        {
            throw new NotImplementedException();
        }

        public void Finalizar(Processo processo)
        {
            throw new NotImplementedException();
        }
    }
}
