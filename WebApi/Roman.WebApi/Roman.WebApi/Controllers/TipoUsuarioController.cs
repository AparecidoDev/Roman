using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roman.WebApi.Domain;
using Roman.WebApi.Interface;
using Roman.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roman.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository _TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _TipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="NovoProjeto">Objeto do tipo TipoUsuario</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TipoUsuario NovoTipoUsuario)
        {
            try
            {
                _TipoUsuarioRepository.Create(NovoTipoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os tipos de usuários
        /// </summary>
        /// <returns>Status Code 200 - Ok E Uma lista de tipos de usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_TipoUsuarioRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de usuário pelo Id
        /// </summary>
        /// <param name="Id">Id do tipo de usuário buscado</param>
        /// <returns>Status Code 200 - Ok E Um tipo de usuário</returns>
        [HttpGet("{Id}")]
        public IActionResult GeById(int Id)
        {
            try
            {
                return Ok(_TipoUsuarioRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza os dados do tipo de usuário
        /// </summary>
        /// <param name="Id">Id do tipo de usuário que será atualizado</param>
        /// <param name="TipoUsuarioAtualizado">Objeto do tipo TipoUsuario contendo os novos dados</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, TipoUsuario TipoUsuarioAtualizado)
        {
            try
            {
                _TipoUsuarioRepository.Update(Id, TipoUsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui um tipo de usuário
        /// </summary>
        /// <param name="Id">Id do tipo de usuário que será excluído</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _TipoUsuarioRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
