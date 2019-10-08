using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using playground.Models;
using playground.Services;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    [Route("api/invocador")]
    public class InvocadorController : Controller
    {
        private readonly IInvocadorService _invocadorSerivice;

        public InvocadorController(IInvocadorService invocadorSerivice)
        {
            _invocadorSerivice = invocadorSerivice;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [Produces(MediaTypeNames.Application.Json)]
        public Invocador insertInvocador(Invocador invocador)
        {
            try
            {
                return _invocadorSerivice.inserirInvocador(invocador);
            }
            catch(Exception e)
            {
                _ = e.StackTrace;
                return null;
            }
        }

        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        public Invocador getInvocador(String nick)
        {
            return _invocadorSerivice.getInvocador(nick);
        }

    }
}