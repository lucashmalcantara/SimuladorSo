using SimuladorSo.Models;
using SimuladorSo.Repositories;
using SimuladorSo.Repositories.Interfaces;
using SimuladorSo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services
{
    public class MmuService : IMmuSerivce
    {
        public const float TAMANHO_PAGINA_MB = 8.0f;

        private readonly IRamService _ramService;
        private readonly ISsdService _ssdService;

        public MmuService(IRamService ramService, ISsdService ssdService)
        {
            _ssdService = ssdService;
            _ramService = ramService;
        }
        public void Alocar(Processo processo)
        {
            if (_ramService.RetornarEspacoDisponivelMB() < processo.TamanhoEmMB)
                RealizarSwapIn(processo.TamanhoEmMB);

            var enderecoFisico = _ramService.RetornarEnderecoFisicoDisponivel();
            _ramService.Alocar(enderecoFisico, processo);
        }

        private void RealizarSwapIn(float tamanhoNecessarioMB)
        {
            var processos = AplicarAlgoritmoLru(_ramService.RetornarTodosProcessos());
            var enderecosLogicosProcessos = new Queue<string>(processos.Select(p => p.EnderecoLogico));

            do
            {
                var enderecoLogico = enderecosLogicosProcessos.Dequeue();
                var enderecoFisico = RetornarEnderecoFisicoMemoriaPrincipal(enderecoLogico);

                var processo = _ramService.Desalocar(enderecoFisico);
                _ssdService.Alocar(processo);
            } while (_ramService.RetornarEspacoDisponivelMB() < tamanhoNecessarioMB);
        }

        private List<Processo> AplicarAlgoritmoLru(IEnumerable<Processo> processos)
        {
            return processos.OrderBy(p => p.UltimaExecucao).ToList();
        }

        public string RetornarEnderecoFisicoMemoriaPrincipal(string enderecoLogico)
        {
            var posicoesMemoria = _ramService.RetornarPosicoesMemoria();

            return posicoesMemoria
                .Where(p => p.Value.EnderecoLogico.Equals(enderecoLogico))
                .Select(p => p.Key).FirstOrDefault();
        }

        public void RealizarSwapOut()
        {
            var espacoNecessarioMB = _ssdService.RetornarEspacoNecessarioMB();

            if (espacoNecessarioMB > 0 && _ramService.RetornarEspacoDisponivelMB() >= espacoNecessarioMB)
            {
                var processo = _ssdService.Desalocar();
                Alocar(processo);
            }
        }

        public void AbortarProcesso(string enderecoLogico)
        {
            var enderecoFisicoMemoriaPrincipal = RetornarEnderecoFisicoMemoriaPrincipal(enderecoLogico);

            if (enderecoFisicoMemoriaPrincipal != null)
                AbortarProcessoMemoriaPrincipal(enderecoLogico);
            else
                AbortarProcessoMemoriaSecundaria(enderecoLogico);
        }

        private void AbortarProcessoMemoriaSecundaria(string enderecoLogico)
        {
            _ssdService.Desalocar(enderecoLogico);
        }

        private void AbortarProcessoMemoriaPrincipal(string enderecoLogico)
        {
            var enderecoFisico = RetornarEnderecoFisicoMemoriaPrincipal(enderecoLogico);
            _ramService.Desalocar(enderecoFisico);
        }

        private bool ProcessoEstaMemoriaSecundaria(string enderecoLogico)
        {
            return _ssdService.RetornarTodosProcessos().Exists(p => p.EnderecoLogico.Equals(enderecoLogico));
        }
    }
}
