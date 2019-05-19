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
        public RamService(float tamanhoPaginaMB)
        {
            _ramRepository = new RamRepository(tamanhoPaginaMB);
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

        public string RetornarEnderecoFisico(string enderecoLogico)
        {
            return _ramRepository.RetornarEnderecoFisico(enderecoLogico);
        }
    }
}
