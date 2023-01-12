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
    public class TemaController : ControllerBase
    {
        private ITemaRepository _ITemaRepository { get; set; }

        public TemaController()
        {
            _ITemaRepository = new TemaRepository();
        }

        /// <summary>
        /// Cadastra um novo tema
        /// </summary>
        /// <param name="NovoTema">Objeto do tipo Tema</param>
        /// <returns>Status Code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Tema NovoTema)
        {
            try
            {
                _ITemaRepository.Create(NovoTema);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

               return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os temas
        /// </summary>
        /// <returns>Status Code 200 - Ok E Uma lista de temas</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITemaRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Um tema
        /// </summary>
        /// <param name="Id">Id do tema buscado</param>
        /// <returns>Status Code 200 - Ok E Um tema</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_ITemaRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza as os dados de um tema
        /// </summary>
        /// <param name="Id">Id do tema que será atualizado</param>
        /// <param name="TemaAtualizado">Objeto do tipo Tema contendo os novos dados</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Tema TemaAtualizado)
        {
            try
            {
                _ITemaRepository.Update(Id, TemaAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui um tema
        /// </summary>
        /// <param name="Id">Id do tema que será excluído</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _ITemaRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
