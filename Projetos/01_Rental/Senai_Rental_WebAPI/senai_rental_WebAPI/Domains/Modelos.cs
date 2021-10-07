using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Domains
{
    public class Modelos
    {
        public string modelo { get; set; }
        public int idModelo { get; set; }
        public int idMarca { get; set; }

        public Marcas marca { get; set; }
    }
}
