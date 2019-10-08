using playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playground.Repositories
{
    public interface IInvocadorRepository
    {
        Invocador getInvocador(String nick);

        Invocador saveInvocador(Invocador invocador);
    }
}
