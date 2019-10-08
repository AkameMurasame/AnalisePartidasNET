using playground.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace playground.Services
{
    public interface IInvocadorService
    {
        Invocador inserirInvocador(Invocador invocador);

        Invocador getInvocador(String nick);
    }
}
