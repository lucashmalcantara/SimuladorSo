using SimuladorSo.Conversores;
using SimuladorSo.Models;
using SimuladorSo.Services;
using SimuladorSo.Services.Interfaces;
using SimuladorSo.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Presenters
{
    public class SimuladorPresenter
    {
        private readonly ISimuladorView _simuladorView;

        #region Services
        private ICpuService _cpuService;
        private IRamService _ramService;
        #endregion
        public SimuladorPresenter(ISimuladorView simuladorView)
        {
            _simuladorView = simuladorView;
            _cpuService = new CpuService();
            _ramService = new RamService();
        }

        #region CPU
        public void CarregarMemoria(Processo processo)
        {
            _cpuService.CarregarMemoriaPrincipal(processo);
            ExibirProcessosMemoriaPrincipal();
        }
        #endregion

        #region Memória Principal
        private void ExibirProcessosMemoriaPrincipal()
        {
            var processosExibicao = _ramService.RetornarTodosProcessos().ConverterParaProcessoDto();
            _simuladorView.ExibirProcessosMemoriaPrincipal(processosExibicao);
        }
        #endregion
    }
}
