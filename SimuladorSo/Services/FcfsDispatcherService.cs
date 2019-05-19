using SimuladorSo.Models;
using SimuladorSo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services
{
    public class FcfsDispatcherService : IDispatcherService
    {
        private readonly IRamService _ramService;
        private readonly IMmuSerivce _mmuService;
        public FcfsDispatcherService(IRamService ramService, IMmuSerivce mmuSerivce)
        {
            _ramService = ramService;
            _mmuService = mmuSerivce;
        }

        public bool Preemptivo()
        {
            return false;
        }

        public Processo RetornarProcesso()
        {
            var processos = _ramService.RetornarTodosProcessos();
            var processoExecucao = processos.OrderBy(p => p.Chegada).FirstOrDefault();

            if (processoExecucao == null)
                return null;

            var enderecoFisico = _mmuService.RetornarEnderecoFisico(processoExecucao.EnderecoLogico);
            var processo = _ramService.Desalocar(enderecoFisico);
            _mmuService.RealizarSwapOut();
            return processo;
        }

        public void SalvarContexto(Processo processo)
        {
            _mmuService.Alocar(processo);
        }
    }
}
