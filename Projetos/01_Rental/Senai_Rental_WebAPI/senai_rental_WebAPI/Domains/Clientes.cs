using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Domains
{
    public class Clientes
    {
        public string nomeCliente { get; set; }
        public string sobrenomeCliente { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigátorio")]
        public int CPF { get; set; }
        public int idCliente { get; set; }
        public int idLocadora { get; set; }
         
        public Locadoras locadora { get; set; }  
    }
}
