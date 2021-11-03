﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Palavra
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Pontuacao { get; set; }

        public DateTime Cirado { get; set; }

        public DateTime Atualizado { get; set; }

    }
}