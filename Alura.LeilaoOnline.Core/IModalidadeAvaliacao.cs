﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.Core
{
    public interface IModalidadeAvaliacao
    {
        Lance Avalia(Leilao leilao);
    }
}
