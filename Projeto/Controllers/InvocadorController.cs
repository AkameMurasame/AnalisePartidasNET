using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Projeto.Models;
using Projeto.Services;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Projeto.Controllers
{
    [Route("api/invocador")]
    [Produces(MediaTypeNames.Application.Json)]
    public class InvocadorController : Controller
    {
        private readonly IInvocadorService _invocadorSerivice;

        public InvocadorController(IInvocadorService invocadorSerivice)
        {
            _invocadorSerivice = invocadorSerivice;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(Invocador), StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Invocador insertInvocador([FromBody] Invocador invocador)
        {
              return _invocadorSerivice.inserirInvocador(invocador);
        }

        [HttpGet]
        [Route("/by-nick/{nick}")]
        public ActionResult<Invocador> getInvocador(String nick)
        {
            Invocador invocador = _invocadorSerivice.getInvocador(nick);
            if(invocador == null)
            {
                return NotFound();
            }
            return invocador;
        }

        [HttpGet]
        [Route("/by-id/{id}")]
        public ActionResult<Invocador> getInvocador(int id)
        {
            Invocador invocador = _invocadorSerivice.GetInvocadorById(id);
            if (invocador == null)
            {
                return NotFound();
            }
            return invocador;
        }

        [HttpGet]
        public ActionResult<List<Invocador>> getAllInvocadores()
        {
            List<Invocador> invocadores = _invocadorSerivice.GetAllInvocadores();
            if (invocadores == null)
            {
                return NotFound();
            }
            return invocadores;
        }

        [HttpPut]
        public Invocador updateInvocador([FromBody] Invocador invocador)
        {
            Invocador invocador = _invocadorSerivice.UpdateInvocador(invocador);
            return invocador;
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public boolean deleteInvocador(int id)
        {
            boolean result = _invocadorSerivice.DeleteInvocador(invocador.id);
            return result;
        }
    }
}