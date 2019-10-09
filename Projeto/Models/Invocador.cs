using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
        public class Invocador
    {
        public class Invocador()
        {
            partidas = new List<Partida>();
        }

        [key]
        public String accountId { get; set; }
        
        public String nick { get; set; }
        
        public ICollection<Partida> partidas { get; set; }
    }
}
