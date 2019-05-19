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
        private Queue<Processo> _armazenamento = new Queue<Processo>();

        public void Alocar(Processo processo)
        {
            _armazenamento.Enqueue(processo);
        }

        public Processo Desalocar()
        {
            return _armazenamento.Dequeue();
        }

        public List<Processo> RetornarTodosProcessos()
        {
            return _armazenamento.ToList();
        }
    }
}
