using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using playground.Models;

namespace playground.Repositories
{
    public class InvocadorRepository : BaseRepository, IInvocadorRepository
    {
        public InvocadorRepository(DbContextMysql context) : base(context)
        { }
        public Invocador getInvocador(String nick)
        {
            return _dbContext.Invocadores.Where(i => i.nick == nick).FirstOrDefault();
        }

        public Invocador saveInvocador(Invocador invocador)
        {
            {
                _dbContext.Invocadores.Add(invocador);
                _dbContext.SaveChanges();
                return getInvocador(invocador.nick);
            }
        }
    }
}
