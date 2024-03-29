﻿using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services.Interfaces
{
    public interface IMmuSerivce
    {
        void Alocar(Processo processo);
        string RetornarEnderecoFisicoMemoriaPrincipal(string enderecoLogico);
        void RealizarSwapOut();
        void AbortarProcesso(string enderecoLogico);
    }
}
