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

        public InvocadorService(IInvocadorRepository invocadorRepository)
        {
            _invocadorRepository = invocadorRepository;
        }

        public Invocador inserirInvocador(Invocador invocador)
        {
            return _invocadorRepository.saveInvocador(invocador);
        }

        public Invocador getInvocador(String nick)
        {          
           return _invocadorRepository.getInvocador(nick);
        }
    }
}
