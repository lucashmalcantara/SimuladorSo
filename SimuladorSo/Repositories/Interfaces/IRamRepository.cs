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
        string Alocar(string enderecoFisico, Processo processo);
        Processo Desalocar(string enderecoFisico);
        List<Processo> RetornarTodosProcessos();
        float RetornarEspacoDisponivelMB();
        string RetornarEnderecoFisicoDisponivel();
        string RetornarEnderecoFisico(string enderecoLogico);
    }
}
