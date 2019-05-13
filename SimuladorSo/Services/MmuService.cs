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

        private IRamService _ramService;

        private readonly Dictionary<string, string> _tabelaPaginas = new Dictionary<string, string>();
        public MmuService(IRamService ramService)
        {
            _ramService = ramService;
        }
        public void Alocar(Processo processo)
        {
            var enderecoFisico = _ramService.Alocar(processo);
            _tabelaPaginas.Add(processo.EnderecoLogico, enderecoFisico);
        }
    }
}
