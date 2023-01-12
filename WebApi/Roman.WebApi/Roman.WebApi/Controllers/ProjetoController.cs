using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "2")]
    public class ProjetoController : ControllerBase
    {
        private IProjetoRepository _IProjetoRepository { get; set; }

        public ProjetoController()
        {
            _IProjetoRepository = new ProjetoRepository();
        }

        /// <summary>
        /// Cadastra um novo projeto
        /// </summary>
        /// <param name="NovoProjeto">Objeto do tipo Projeto</param>
        /// <returns>Status Code 201 - Created</returns>
        
        [HttpPost]
        public IActionResult Post(Projeto NovoProjeto)
        {
            try
            {
                _IProjetoRepository.Create(NovoProjeto);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todos os projetos
        /// </summary>
        /// <returns>Status Code 200 - Ok E Uma lista de projetos</returns>
        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IProjetoRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um projeto
        /// </summary>
        /// <param name="Id">Id do projeto buscado</param>
        /// <returns>Status Code 200 - Ok E Um projeto</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IProjetoRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um projeto
        /// </summary>
        /// <param name="Id">Id do projeto que será atualizado</param>
        /// <param name="ProjetoAtualizado">Objeto do tipo Projeto contendo as novas informações</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Projeto ProjetoAtualizado)
        {
            try
            {
                _IProjetoRepository.Update(Id, ProjetoAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui um projeto
        /// </summary>
        /// <param name="Id">Id do projeto que será excluído</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IProjetoRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
