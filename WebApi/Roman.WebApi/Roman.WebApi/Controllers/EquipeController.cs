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
    public class EquipeController : ControllerBase
    {
        private IEquipeRepository _IEquipeRepository { get; set; }


        public EquipeController()
        {
            _IEquipeRepository = new EquipeRepository();
        }

        /// <summary>
        /// Cadastra uma nova equipe
        /// </summary>
        /// <param name="NovaEquipe">Objeto do tipo Equipe</param>
        /// <returns>StatusCode 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(Equipe NovaEquipe)
        {
            try
            {
                _IEquipeRepository.Create(NovaEquipe);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Lista todas as equipes
        /// </summary>
        /// <returns>Status Code 200 - Ok E Lista de equipes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IEquipeRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca uma equipe pelo Id
        /// </summary>
        /// <param name="Id">Id da equipe buscada</param>
        /// <returns>Status Code 200 - Ok E Uma equipe</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IEquipeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza uma equipe
        /// </summary>
        /// <param name="Id"> Id da equipe que será atualizada</param>
        /// <param name="EquipeAtualizada">Objeto do tipo equipe contendo as novas informações</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, Equipe EquipeAtualizada)
        {
            try
            {
                _IEquipeRepository.Update(Id, EquipeAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui uma equipe
        /// </summary>
        /// <param name="Id">Id da equipe que será excluída</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IEquipeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
