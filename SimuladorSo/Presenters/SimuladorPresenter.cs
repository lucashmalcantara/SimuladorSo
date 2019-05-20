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
        private const float ESPACO_RESERVADO_SO_MB = 50;
        private const int FREQUENCIA_CLOCK_SEGUNDOS = 1;

        private readonly ISimuladorView _simuladorView;

        #region Services
        private readonly ICpuService _cpuService;
        private readonly IMmuSerivce _mmuSerivce;
        private readonly IRamService _ramService;
        private readonly ISsdService _ssdService;
        private IDispatcherService _dispatcherService;
        #endregion

        private Timer _clock;
        private Processo processoExecucao;

        public enum TipoEscalonamento
        {
            PrimeiroAChegar,
            JobMaisCurto
        }

        public SimuladorPresenter(ISimuladorView simuladorView, TipoEscalonamento tipoEscalonamento)
        {
            _simuladorView = simuladorView;
            _ssdService = new SsdService();
            _ramService = new RamService(MmuService.TAMANHO_PAGINA_MB, ESPACO_RESERVADO_SO_MB);
            _mmuSerivce = new MmuService(_ramService, _ssdService);
            _cpuService = new CpuService(_mmuSerivce, FREQUENCIA_CLOCK_SEGUNDOS);
            ConfigurarTimer();
            ConfigurarDispatcher(tipoEscalonamento);
            _simuladorView.ExibirEspacoReservadoSo(_ramService.RetornarEspacoReservadoSoMB());
        }

        public void IniciarExecucao()
        {
            _clock.Enabled = true;
            _clock.Start();
        }

        public void ConfigurarDispatcher(TipoEscalonamento tipoEscalonamento)
        {
            switch (tipoEscalonamento)
            {
                case TipoEscalonamento.PrimeiroAChegar:
                    _dispatcherService = new FcfsDispatcherService(_ramService, _mmuSerivce);
                    break;
                case TipoEscalonamento.JobMaisCurto:
                    _dispatcherService = new SjfDispatcherService(_ramService, _mmuSerivce);
                    break;
                default:
                    throw new ArgumentException("Tipo de escalonamento inválido.", nameof(tipoEscalonamento));
            }
        }

        private void ConfigurarTimer()
        {
            var fequenciaClockMilissegundos = FREQUENCIA_CLOCK_SEGUNDOS * 1000;
            _clock = new Timer();
            _clock.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            _clock.Interval = fequenciaClockMilissegundos;
        }

        public void Carregar(ProcessoDto processo)
        {
            var novoProcesso = processo.ConverterParaProcesso();
            _cpuService.Carregar(novoProcesso);

            if (_dispatcherService.Preemptivo() && processoExecucao != null)
            {
                _clock.Stop();
                _dispatcherService.SalvarContexto(processoExecucao);
                processoExecucao = null;
                ExibirProcessoCpu();
                _clock.Start();
            }

            ExibirProcessosMemoriaPrincipal();
            ExibirEspacoLivreMemoriaPrincipal();
            ExibirProcessosMemoriaSecundaria();
        }

        private void ExibirEspacoLivreMemoriaPrincipal()
        {
            _simuladorView.ExibirEspacoLivre(_ramService.RetornarEspacoDisponivelMB());
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
        private void ExibirProcessoCpu()
        {
            _simuladorView.ExibirProcessoCpu(processoExecucao.ConverterParaProcessoDto());
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (processoExecucao == null)
            {
                processoExecucao = _dispatcherService.RetornarProcesso();
                ExibirProcessosMemoriaPrincipal();
                ExibirEspacoLivreMemoriaPrincipal();
                ExibirProcessosMemoriaSecundaria();
            }

            if (processoExecucao != null)
            {
                _cpuService.Executar(ref processoExecucao);

                if (processoExecucao.DuracaoSurto == 0)
                    processoExecucao = null;

                ExibirProcessoCpu();
            }
        }

        public void FinalizarProcesso(string enderecoLogico)
        {
            if (EstaEmExecucao(enderecoLogico))
                AbortarProcessoCpu();

            AbortarProcessoViaMmu(enderecoLogico);
        }

        private void AbortarProcessoViaMmu(string enderecoLogico)
        {
            _clock.Stop();
            _mmuSerivce.AbortarProcesso(enderecoLogico);
            ExibirProcessosMemoriaPrincipal();
            ExibirEspacoLivreMemoriaPrincipal();
            ExibirProcessosMemoriaSecundaria();
            _clock.Start();
        }

        private void AbortarProcessoCpu()
        {
            _clock.Stop();
            processoExecucao = null;
            ExibirProcessoCpu();
            _clock.Start();
        }

        private bool EstaEmExecucao(string enderecoLogico)
        {
            return processoExecucao != null && processoExecucao.EnderecoLogico.Equals(enderecoLogico);
        }

        //private int tempoCompartilhadoSegundos = 3;
    }
}
