using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nexos.BLL.DTOs;
using Nexos.BLL.Repositories;
using Nexos.DAL.Models;
using System.Net;

namespace Nexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        readonly IAuthorRepository authorRepository;
        readonly IMapper mapper;

        public AuthorController(IAuthorRepository authorRepository, 
            IMapper mapper)
        {
            this.authorRepository = authorRepository;
            this.mapper = mapper;          

        }

        /// <summary>
        /// Metodo para obtener todos los autores
        /// </summary>
        /// <remarks>
        /// Detalle del metodo para obtener todos los autores
        /// </remarks>
        /// <returns>Resultado de la operacion</returns>
        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var authors = authorRepository.GetAllAsync().Result;
            var authorsDTO = authors.Select(x => mapper.Map<AuthorDTO>(x));
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = authorsDTO });
        }

        /// <summary>
        /// Metodo para obtener un Autor por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByIdAsync/{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            var author = authorRepository.GetByIdAsync(id).Result;
            var authorDTO = mapper.Map<AuthorDTO>(author);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = authorDTO });
        }

        /// <summary>
        /// Metodo para crear un Autor
        /// </summary>
        /// <param name="authorDTO">Objeto del autor</param>
        /// <returns>Resultado de la operacion</returns>
        [HttpPost("InsertAsync")]
        public IActionResult InsertAsync(AuthorDTO authorDTO)
        {
            try
            {
                var author = mapper.Map<Author>(authorDTO);
                author = authorRepository.InsertAsync(author).Result;
                authorDTO.IdAuthor = author.IdAuthor;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = authorDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para actualizar un cliente
        /// </summary>
        /// <param name="authorDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateAsync/{id}")]
        public IActionResult UpdateAsync(AuthorDTO authorDTO, int id)
        {
            try
            {
                var author = authorRepository.GetByIdAsync(id).Result;
                if (author == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                author = mapper.Map<Author>(authorDTO);//objeto
                author = authorRepository.UpdateAsync(author).Result;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = authorDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para eliminar un Author
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var author = authorRepository.GetByIdAsync(id).Result;
                if (author == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                await authorRepository.DeleteAsync(id);

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

    }
}
