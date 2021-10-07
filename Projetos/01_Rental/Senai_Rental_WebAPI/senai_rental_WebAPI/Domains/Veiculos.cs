using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Domains
{
    public class Veiculos
    {
        public string placa { get; set; }
        public int idVeiculo { get; set; }
        public int idLocadora { get; set; } 

        public Locadoras locadora { get; set; }

        public int idModelo { get; set; }

        public Modelos modelo { get; set; }

    }
}
