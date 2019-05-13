using SimuladorSo.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Views.Interfaces
{
    public interface ISimuladorView
    {
        void ExibirProcessosMemoriaPrincipal(List<ProcessoDto> processos);
    }
}
