using Data.DAL;
using Data.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect__EF___Web_API_.Dtos;

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
        /// <param name="mark"></param>
        [HttpPost]
        public IActionResult AddMark([FromBody] MarksToCreateDto mark)
        {
            try
            {
                dataAccessLayerService.AddMark(mark.Value, mark.StudentId, mark.CourseId);
                return Ok();
            }
            catch (InvalidIdException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
