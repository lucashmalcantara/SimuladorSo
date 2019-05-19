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
        private readonly int _frequenciaClockSegundos;
        private readonly IMmuSerivce _mmuSerivce;
        public CpuService(IMmuSerivce mmuSerivce, int frequenciaClockSegundos)
        {
            _mmuSerivce = mmuSerivce;
            _frequenciaClockSegundos = frequenciaClockSegundos;
        }

        public void Carregar(Processo processo)
        {
            processo.EnderecoLogico = Guid.NewGuid().ToString();
            processo.Chegada = DateTime.Now;
            _mmuSerivce.Alocar(processo);
        }

        public void Executar(ref Processo processo)
        {
            processo.UltimaExecucao = DateTime.Now;

            var surtoRestante = processo.DuracaoSurto - _frequenciaClockSegundos;
            processo.DuracaoSurto = surtoRestante < 0 ? 0 : surtoRestante;
        }

        public void SalvarContexto(Processo processo)
        {
            _mmuSerivce.Alocar(processo);
        }
    }
}
