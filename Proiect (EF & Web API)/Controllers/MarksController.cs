using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect__EF___Web_API_.Dtos;
using Proiect__EF___Web_API_.Utils;
using System.ComponentModel.DataAnnotations;

namespace Proiect__EF___Web_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarksController : ControllerBase
    {
        private readonly IDataAccessLayerService dataAccessLayerService;
        public MarksController(IDataAccessLayerService dataAccessLayerService)
        {
            this.dataAccessLayerService = dataAccessLayerService;
        }
        /// <summary>
        /// Adding marks
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MarksToCreateDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        public MarksToCreateDto AddMark([FromBody] MarksToCreateDto grade) => dataAccessLayerService.AddMark(grade.Value, grade.StudentId, grade.CourseId).ToDto();
    }

}
