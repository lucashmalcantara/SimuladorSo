using SimuladorSo.Models;
using SimuladorSo.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Repositories
{
    public class SsdRepository : ISsdRepository
    {
        private const int INDICE_DESALOCAMENTO = 0;
        private List<Processo> _armazenamento = new List<Processo>();

        public void Alocar(Processo processo)
        {
            _armazenamento.Add(processo);
        }

        public Processo Desalocar()
        {
            var processo = _armazenamento[INDICE_DESALOCAMENTO];
            _armazenamento.RemoveAt(INDICE_DESALOCAMENTO);
            return processo;
        }

        public float RetornarEspacoNecessarioMB()
        {
            if (_armazenamento.Count == 0)
                return 0f;

            return _armazenamento[INDICE_DESALOCAMENTO].TamanhoEmMB;
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _armazenamento;
        }
    }
}
