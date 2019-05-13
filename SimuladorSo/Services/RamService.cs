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

        public string Alocar(Processo processo)
        {
            return _ramRepository.Alocar(processo);
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _ramRepository.RetornarTodosProcessos();
        }
    }
}
