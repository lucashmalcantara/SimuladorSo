using SimuladorSo.Conversores;
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
using System.Timers;

namespace SimuladorSo.Presenters
{
    public class SimuladorPresenter
    {
        private const int FREQUENCIA_CLOCK_SEGUNDOS = 1;

        private readonly ISimuladorView _simuladorView;

        #region Services
        private ICpuService _cpuService;
        private IMmuSerivce _mmuSerivce;
        private IRamService _ramService;
        private ISsdService _ssdService;
        private IDispatcherService _dispatcherService;
        #endregion

        private Timer _clock;
        public SimuladorPresenter(ISimuladorView simuladorView)
        {
            _simuladorView = simuladorView;
            _ssdService = new SsdService();
            _ramService = new RamService(MmuService.TAMANHO_PAGINA_MB);
            _mmuSerivce = new MmuService(_ramService, _ssdService);
            _cpuService = new CpuService(_mmuSerivce, FREQUENCIA_CLOCK_SEGUNDOS);
            _dispatcherService = new FcfsDispatcherService(_ramService, _mmuSerivce);

            ConfigurarTimer();
            _clock.Start();
        }

        private void ConfigurarTimer()
        {
            var fequenciaClockMilissegundos = FREQUENCIA_CLOCK_SEGUNDOS * 1000;
            _clock = new Timer();
            _clock.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _clock.Interval = fequenciaClockMilissegundos;
            _clock.Enabled = true;
        }

        public void Carregar(ProcessoDto processo)
        {
            _cpuService.Carregar(processo.ConverterParaProcesso());
            ExibirProcessosMemoriaPrincipal();
            ExibirProcessosMemoriaSecundaria();
        }

        private void ExibirProcessosMemoriaPrincipal()
        {
            var processoMemoriaPrincipal = _ramService.RetornarTodosProcessos();
            _simuladorView.ExibirProcessosMemoriaPrincipal(processoMemoriaPrincipal.ConverterParaProcessoDto());
        }

        private void ExibirProcessosMemoriaSecundaria()
        {
            var processoMemoriaSecundaria = _ssdService.RetornarTodosProcessos();
            _simuladorView.ExibirProcessosMemoriaSecundaria(processoMemoriaSecundaria.ConverterParaProcessoDto());
        }
        private void ExibirProcessoCpu(Processo processo)
        {
            _simuladorView.ExibirProcessoCpu(processo.ConverterParaProcessoDto());
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var processo = _dispatcherService.RetornarProcesso();

            if (processo != null)
            {
                _cpuService.Executar(ref processo);
                _cpuService.SalvarContexto(processo);
                ExibirProcessoCpu(processo);
                ExibirProcessosMemoriaPrincipal();
            }
        }

        //private int tempoCompartilhadoSegundos = 3;
    }
}
