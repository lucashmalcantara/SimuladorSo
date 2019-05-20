using SimuladorSo.Models;
using SimuladorSo.Repositories;
using SimuladorSo.Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services.Interfaces
{
    public interface ISsdService
    {
        float RetornarEspacoNecessarioMB();
        void Alocar(Processo processo);
        Processo Desalocar();
        Processo Desalocar(string enderecoLogico);
        List<Processo> RetornarTodosProcessos();
    }
}
