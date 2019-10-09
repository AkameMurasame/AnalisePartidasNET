using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using playground.Models;
using playground.Repositories;

namespace playground.Services
{
    public class InvocadorService : IInvocadorService
    {
        private readonly IInvocadorRepository _invocadorRepository;

        private readonly RiotApiService riotApiService;


        public InvocadorService(IInvocadorRepository invocadorRepository)
        {
            _invocadorRepository = invocadorRepository;
        }

        public Invocador getInvocador(String nick)
        {
            return _invocadorRepository.getInvocador(nick);
        }

        public Invocador saveInvocador(Invocador invocador)
        {
            return _invocadorRepository.saveInvocador(invocador);
        }

        public List<Invocador> GetAllInvocadores()
        {
            return _invocadorRepository.GetAllInvocadores();
        }

        public Invocador UpdateInvocador(Invocador invocador)
        {
            return _invocadorRepository.UpdateInvocador(invocador);
        }

        public boolean DeleteInvocador(int id)
        {
            return _invocadorRepository.DeleteInvocador(id);
        }

        public Invocador GetInvocadorById(int id)
        {
            return _invocadorRepository.GetInvocadorById(id);
        }
    }
}
