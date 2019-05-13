﻿using SimuladorSo.Conversores;
using SimuladorSo.Dtos;
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
        private IMmuSerivce _mmuSerivce;
        private IRamService _ramService;
        #endregion
        public SimuladorPresenter(ISimuladorView simuladorView)
        {
            _simuladorView = simuladorView;
            _ramService = new RamService(MmuService.TAMANHO_PAGINA_MB);
            _mmuSerivce = new MmuService(_ramService);
            _cpuService = new CpuService(_mmuSerivce);
        }

        public void Carregar(ProcessoDto processo)
        {
            _cpuService.Carregar(processo.ConverterParaProcesso());
            ExibirProcessosMemoriaPrincipal();
        }

        private void ExibirProcessosMemoriaPrincipal()
        {
            var processoMemoriaPrincipal = _ramService.RetornarTodosProcessos();
            _simuladorView.ExibirProcessosMemoriaPrincipal(processoMemoriaPrincipal.ConverterParaProcessoDto());
        }
    }
}
