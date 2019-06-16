using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Repositories.Interfaces
{
    public interface ISsdRepository
    {
        float RetornarEspacoNecessarioMB();
        void Alocar(Processo processo);
        Processo Desalocar();
        Processo Desalocar(string enderecoLogico);
        List<Processo> RetornarTodosProcessos();
    }
}
