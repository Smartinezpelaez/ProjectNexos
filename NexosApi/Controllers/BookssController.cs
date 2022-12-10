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
    public class BookssController : ControllerBase
    {
        readonly IBookssRepository booksRepository;
        readonly IMapper mapper;

        public BookssController(IBookssRepository booksRepository,
            IMapper mapper)
        {
            this.booksRepository = booksRepository;
            this.mapper = mapper;

        }

        /// <summary>
        /// Metodo para obtener todos los Libros
        /// </summary>
        /// <remarks>
        /// Detalle del metodo para obtener todos los Libros
        /// </remarks>
        /// <returns>Resultado de la operacion</returns>
        [HttpGet("GetAllAsync")]
        public IActionResult GetAllAsync()
        {
            var books =booksRepository.GetAllAsync().Result;
            var booksDTO = books.Select(x => mapper.Map<BookssDTO>(x));
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = booksDTO });
        }

        /// <summary>
        /// Metodo para obtener un Libro por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetByIdAsync/{id}")]
        public IActionResult GetByIdAsync(int id)
        {
            var books = booksRepository.GetByIdAsync(id).Result;
            var booksDTO = mapper.Map<BookssDTO>(books);
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = booksDTO });
        }

        /// <summary>
        /// Metodo para crear un Libro
        /// </summary>
        /// <param name="booksDTO">Objeto del Libro</param>
        /// <returns>Resultado de la operacion</returns>
        [HttpPost("InsertAsync")]
        public IActionResult InsertAsync(BookssDTO booksDTO)
        {
            try
            {
                var books = mapper.Map<Bookss>(booksDTO);
                books = booksRepository.InsertAsync(books).Result;
                booksDTO.IdBook = books.IdBook;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = booksDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para actualizar un Libro
        /// </summary>
        /// <param name="booksDTO"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("UpdateAsync/{id}")]
        public IActionResult UpdateAsync(BookssDTO booksDTO, int id)
        {
            try
            {
                var books = booksRepository.GetByIdAsync(id).Result;
                if (books == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                books = mapper.Map<Bookss>(booksDTO);//objeto
                books = booksRepository.UpdateAsync(books).Result;

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = booksDTO });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }

        /// <summary>
        /// Método para eliminar un libro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteAsync/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var books = booksRepository.GetByIdAsync(id).Result;
                if (books == null)
                    return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NotFound, Message = "Not Found" });

                await booksRepository.DeleteAsync(id);

                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.NoContent });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseDTO { Code = (int)HttpStatusCode.InternalServerError, Message = ex.Message });
            }
        }





    }
}
