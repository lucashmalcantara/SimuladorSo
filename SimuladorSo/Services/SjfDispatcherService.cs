using SimuladorSo.Models;
using SimuladorSo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services
{
    public class SjfDispatcherService : IDispatcherService
    {
        private readonly IRamService _ramService;
        private readonly IMmuSerivce _mmuService;
        public SjfDispatcherService(IRamService ramService, IMmuSerivce mmuSerivce)
        {
            _ramService = ramService;
            _mmuService = mmuSerivce;
        }

        public Processo RetornarProcesso()
        {
            var processos = _ramService.RetornarTodosProcessos();
            var processoExecucao =  processos.OrderBy(p => p.DuracaoSurto).FirstOrDefault();

            if (processoExecucao == null)
                return null;

            var enderecoFisico = _mmuService.RetornarEnderecoFisico(processoExecucao.EnderecoLogico);
            return _ramService.Desalocar(enderecoFisico);
        }
    }
}
