using Data;
using Data.DAL;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proiect__EF___Web_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public CoursesController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }
        /// <summary>
        /// Intilizeaza DB
        /// </summary>
        [HttpPost]
        public void AddCourse([FromBody]string courseName) =>
             dal.AddCourse(courseName);
        [HttpGet()]
        public List<Course> GetAllCourses() =>
         dal.GetAllCourses();

    }
}
