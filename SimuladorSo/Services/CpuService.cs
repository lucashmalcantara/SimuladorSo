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
        private readonly IMmuSerivce _mmuService;
        public CpuService(IMmuSerivce mmuSerivce, int frequenciaClockSegundos)
        {
            _mmuService = mmuSerivce;
            _frequenciaClockSegundos = frequenciaClockSegundos;
        }

        public void Carregar(Processo processo)
        {
            processo.EnderecoLogico = Guid.NewGuid().ToString();
            processo.Chegada = DateTime.Now;
            _mmuService.Alocar(processo);
        }

        public void Executar(ref Processo processo)
        {
            processo.UltimaExecucao = DateTime.Now;

            var surtoRestante = processo.DuracaoSurto - _frequenciaClockSegundos;
            processo.DuracaoSurto = surtoRestante < 0 ? 0 : surtoRestante;
        }
    }
}
