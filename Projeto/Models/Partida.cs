using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Models
{
    public class Partida
    {
        public long id { get; set; }

        public Boolean resultado { get; set; }

        public String multiKill { get; set; }

        public TimeSpan duracao { get; set; }

        public String gameType { get; set; }

        public int nomeCampeao { get; set; }

        public List<Item> build { get; set; }

        public Invocador accountId { get; set; }

        public String kda { get; set; }

        public List<Spell> spells { get; set; }

        public long scoreVisao { get; set; }

        public int farm { get; set; }

        public int gold { get; set; }

        public int wards { get; set; }
    }
}
