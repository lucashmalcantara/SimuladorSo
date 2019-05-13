using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Repositories.Interfaces
{
    public interface IRamRepository
    {
        string Alocar(Processo processo);
        List<Processo> RetornarTodosProcessos();
    }
}
