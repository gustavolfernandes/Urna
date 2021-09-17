using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urna.Domain.Entities;
using Urna.Domain.Interfaces.Repositories;

namespace Urna.API.Controllers
{
    //https://localhost:5001/vote
    [Route("vote")]
    public class VoteController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromServices] IVoteRepository repository)
        {
            try
            {
                var result = await repository.Get();
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel encontrar nenhum voto." });
            }
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByCandidateId(
            [FromServices] IVoteRepository repository,
            int id)
        {
            try
            {
                var result = await repository.GetByCandidateId(id);
                if (result != null)
                return Ok(result);

                return BadRequest(new { message = "Não foi possivel encontrar nenhum voto para o candidato." });

            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel encontrar nenhum voto." });
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post(
            [FromBody] Vote model,
            [FromServices] IVoteRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { message = "Voto nulo realizado com sucesso." });

                try
            {
                await repository.Post(model);

                if (model.Nulo)
                return Ok(new { message = "Voto nulo realizado com sucesso." });

                return Ok(new { message = "Voto realizado com sucesso." });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível votar." });
            }
        }
    }
}
