﻿using SimuladorSo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorSo.Services.Interfaces
{
    public interface IRamService
    {
        List<Processo> RetornarTodosProcessos();
    }
}
