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
        void ExibirProcessosMemoriaSecundaria(List<ProcessoDto> processos);
        void ExibirProcessoCpu(ProcessoDto processo);

        void ExibirEspacoReservadoSo(float espacoMB);
        void ExibirEspacoLivre(float espacoMB);
    }
}
