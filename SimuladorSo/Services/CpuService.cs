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
        private IMmuSerivce _mmuSerivce;
        public CpuService(IMmuSerivce mmuSerivce)
        {
            _mmuSerivce = mmuSerivce;
        }

        public void Carregar(Processo processo)
        {
            processo.EnderecoLogico = Guid.NewGuid().ToString();
            _mmuSerivce.Alocar(processo);
        }
    }
}
