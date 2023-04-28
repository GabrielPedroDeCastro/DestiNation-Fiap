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
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(DataBaseContext context)
        {
            userRepository = new UserRepository(context);
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserModel> Get([FromRoute] int id)
        {
            try
            {
                var userModel = userRepository.Consultar(id);

                if (userModel != null)
                {
                    return Ok(userModel);
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
        public ActionResult<List<UserModel>> Get()
        {
            try
            {
                var lista = userRepository.Listar();

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
        public ActionResult<UserModel> Post([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                userRepository.Inserir(userModel);
                var location = new Uri(Request.GetEncodedUrl() + "/" + userModel.UserId);
                return Created(location, userModel);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Registration error - Unable to register the user. Detalhes: {error.Message}" });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserModel> Delete([FromRoute] int id)
        {
            try
            {
                var userModel = userRepository.Consultar(id);

                if (userModel != null)
                {
                    userRepository.Excluir(userModel);
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
        public ActionResult<UserModel> Put([FromRoute] int id, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (userModel.UserId != id)
            {
                return NotFound();
            }


            try
            {
                userRepository.Alterar(userModel);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Changing error - Unable to change the user information. Detalhes: {error.Message}" });
            }
        }


    }
}
