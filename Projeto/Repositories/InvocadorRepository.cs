using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto.Models;

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
            try
            {
                _dbContext.Invocadores.Add(invocador);
                _dbContext.SaveChanges();
                return this.getInvocador(invocador.nick);
            }
            catch
            {
                throw;
            }
        }

        public List<Invocador> GetAllInvocadores()
        {
            try
            {
                _dbContext.Invocadores.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Invocador UpdateInvocador(Invocador invocador)
        {
            try
            {
                _dbContext.Entry(invocador).State = EntityState.Modifield;
                _dbContext.SaveChanges();
                return this.GetInvocadorById(invocador.id);
            }
            catch
            {
                throw;
            }
        }

        public boolean DeleteInvocador(int id)
        {
            try
            {
                Invocador invocador = this.GetInvocadorById(id);
                _dbContext.Invocador.Remove(invocador);
                _dbContext.SaveChanges();
                return true;
            } 
            catch
            {
                return false;
            }
        }

        public Invocador GetInvocadorById(int id)
        {
            try
            {
                Invocador invocador = _dbContext.Invocador.find(id);
                return invocador;
            } catch
            {
                throw;
            }
        }
    }
}
