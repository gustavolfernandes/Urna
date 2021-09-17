using Microsoft.AspNetCore.Mvc;
using System;

using System.Threading.Tasks;
using Urna.Domain.Entities;
using Urna.Domain.Interfaces.Repositories;

namespace Urna.API.Controllers
{
    //https://localhost:5001/candidate
    [Route("candidate")]
    public class CandidateController : Controller
    {
        [HttpGet]
        [Route("")]  
        public async Task<IActionResult> Get([FromServices] ICandidateRepository repository)
        {
            try
            {
                var result = await repository.Get();
                return Ok(result);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possivel encontrar nenhum candidato." });
            }
        }
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Candidate>> Post(
            [FromBody] Candidate model,
            [FromServices] ICandidateRepository repository)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await repository.Post(model);
                if (!(result == null))
                {
                    return Ok(result);
                }
                else
                {
                    return Conflict(new { message = "Candidato já existe." });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar candidato." });
            }
        }
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(
            int id,
            [FromServices] ICandidateRepository repository)
        {
            try
            {
                return Ok(await repository.Delete(id));
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível remover a candidato" });
            }
        }

    }
}
