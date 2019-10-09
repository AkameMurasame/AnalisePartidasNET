﻿using playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playground.Repositories
{
    public interface IInvocadorRepository
    {
        public Invocador getInvocador(String nick);

        public Invocador saveInvocador(Invocador invocador);

        public List<Invocador> GetAllInvocadores();

        public Invocador UpdateInvocador(Invocador invocador);

        public boolean DeleteInvocador(int id);

        public Invocador GetInvocadorById(int id);
        
    }
}
