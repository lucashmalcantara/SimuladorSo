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
    public class RamService : IRamService
    {
        private IRamRepository _ramRepository;
        public RamService(float tamanhoPaginaMB, float espacoReservadoSoMB)
        {
            _ramRepository = new RamRepository(tamanhoPaginaMB, espacoReservadoSoMB);
        }

        public string Alocar(string enderecoFisico, Processo processo)
        {
            return _ramRepository.Alocar(enderecoFisico, processo);
        }

        public float RetornarEspacoDisponivelMB()
        {
            return _ramRepository.RetornarEspacoDisponivelMB();
        }

        public string RetornarEnderecoFisicoDisponivel()
        {
            return _ramRepository.RetornarEnderecoFisicoDisponivel();
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _ramRepository.RetornarTodosProcessos();
        }

        public Processo Desalocar(string enderecoFisico)
        {
            return _ramRepository.Desalocar(enderecoFisico);
        }

        Dictionary<string, Processo> IRamService.RetornarPosicoesMemoria()
        {
            return _ramRepository.RetornarPosicoesMemoria();
        }

        public float RetornarEspacoReservadoSoMB()
        {
            return _ramRepository.RetornarEspacoReservadoSoMB();
        }
    }
}
