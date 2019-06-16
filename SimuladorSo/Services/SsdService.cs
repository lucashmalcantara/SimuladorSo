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
    public class SsdService : ISsdService
    {
        private ISsdRepository _ssdRepository = new SsdRepository();

        public void Alocar(Processo processo)
        {
            _ssdRepository.Alocar(processo);
        }

        public Processo Desalocar()
        {
            return _ssdRepository.Desalocar();
        }

        public Processo Desalocar(string enderecoLogico)
        {
            return _ssdRepository.Desalocar(enderecoLogico);
        }

        public float RetornarEspacoNecessarioMB()
        {
            return _ssdRepository.RetornarEspacoNecessarioMB();
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _ssdRepository.RetornarTodosProcessos();
        }
    }
}
