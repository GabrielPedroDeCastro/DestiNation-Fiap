using DestiNation.Models;
using DestiNation.Repository;
using DestiNation.Repository.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Security;

namespace DestiNation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private readonly CountryRepository countryRepository;

        public CountryController(DataBaseContext context)
        {
            countryRepository = new CountryRepository(context);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CountryModel> Get([FromRoute] int id)
        {
            try
            {
                var countryModel = countryRepository.Consultar(id);

                if (countryModel != null)
                {
                    return Ok(countryModel);
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
        public ActionResult<List<CountryModel>> Get()
        {
            try
            {
                var lista = countryRepository.Listar();

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
        public ActionResult<CountryModel> Post([FromBody] CountryModel countryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                countryRepository.Inserir(countryModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + countryModel.CountryId);
                return Created(location, countryModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Registration error - Unable to register the country. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<CountryModel> Delete([FromRoute] int id)
        {
            
                var countryModel = countryRepository.Consultar(id);

                if (countryModel != null)
                {
                    countryRepository.Excluir(countryModel);
                    // Retorno Sucesso.
                    // Efetuou a exclusão, porém sem necessidade de informar os dados.
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            
           
        }

        [HttpPut("{id:int}")]
        public ActionResult<CountryModel> Put([FromRoute] int id, [FromBody] CountryModel countryModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (countryModel.CountryId != id)
            {
                return NotFound();
            }


            try
            {
                countryRepository.Alterar(countryModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Change error - Unable to change the country information. Detalhes: {error.Message}" });
            }
        }

    }
}
