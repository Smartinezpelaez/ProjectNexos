using AutoMapper;
using Nexos.BLL.DTOs;
using Nexos.BLL.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Nexos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordController : ControllerBase
    {
        readonly IRecordRepository recordRepository;
        readonly IMapper mapper;

        public RecordController(IRecordRepository recordRepository, IMapper mapper)
        {
            this.recordRepository = recordRepository;
            this.mapper = mapper;
        }


        /// <summary>
        /// Reporte estado de libros
        /// </summary>        
        /// <returns></returns>
        [HttpGet("AccountStatus")]
        public IActionResult GetAllAsync()
        {
            var record = recordRepository.GetAllAsync().Result;
            var recordDTO = record.Select(x => mapper.Map<BookssDTO>(x));
            return Ok(new ResponseDTO { Code = (int)HttpStatusCode.OK, Data = recordDTO });
        }




    }
}
