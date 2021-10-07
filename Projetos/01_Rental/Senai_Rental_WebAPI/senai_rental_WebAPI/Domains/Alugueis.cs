using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_rental_WebAPI.Domains
{
    public class Alugueis
    {
        public DateTime dataRetirada { get; set; }
        public DateTime dataDevolucao { get; set; }
        public int idAluguel { get; set; }
        public int idCliente { get; set; }

        public Clientes cliente { get; set; }

        public int idVeiculo { get; set; } 

        public Veiculos veiculo { get; set; }
    }
}
