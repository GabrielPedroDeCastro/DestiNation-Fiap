using DestiNation.Models;
using DestiNation.Repository.Context;
using DestiNation.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace DestiNation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportController : ControllerBase
    {
        private readonly PassportRepository passportRepository;

        public PassportController(DataBaseContext context)
        {
            passportRepository = new PassportRepository(context);
        }

        [HttpGet("{id:int}")]
        public ActionResult<PassportModel> Get([FromRoute] int id)
        {
            try
            {
                var passportModel = passportRepository.Consultar(id);

                if (passportModel != null)
                {
                    return Ok(passportModel);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public ActionResult<List<PassportModel>> Get()
        {
            try
            {
                var lista = passportRepository.Listar();

                if (lista != null)
                {
                    return Ok(lista);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult<PassportModel> Post([FromBody] PassportModel passportModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                passportRepository.Inserir(passportModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + passportModel.PassportId);
                return Created(location, passportModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Registration error - Unable to register the passport grade. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<PassportModel> Delete([FromRoute] int id)
        {
            try
            {
                var passportModel = passportRepository.Consultar(id);

                if (passportModel != null)
                {
                    passportRepository.Excluir(passportModel);
                    // Retorno Sucesso.
                    // Efetuou a exclusão, porém sem necessidade de informar os dados.
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult<PassportModel> Put([FromRoute] int id, [FromBody] PassportModel passportModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (passportModel.PassportId != id)
            {
                return NotFound();
            }


            try
            {
                passportRepository.Alterar(passportModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Change error - Unable to change the passport grade information. Detalhes: {error.Message}" });
            }
        }
    }
}
