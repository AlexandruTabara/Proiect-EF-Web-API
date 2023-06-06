using Data;
using Data.DAL;
using Data.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proiect__EF___Web_API_.Dtos;
using Proiect__EF___Web_API_.Utils;
using System.Runtime.Serialization;

namespace Proiect__EF___Web_API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDataAccessLayerService dal;
        public StudentsController(IDataAccessLayerService dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Returns all students in our DB
        /// </summary>
        [HttpGet]
        public IEnumerable<StudentToGetDto> GetAllStudents() 
        {
            var allStudents = dal.GetAllStudents();
            return allStudents.Select(s=> s.ToDto()).ToList();
        }

        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id">ID of the student</param>
        /// <returns>student info</returns>
        [HttpGet("/id/{id}")]
        public StudentToGetDto GetStudentById(int id) =>
            dal.GetStudentById(id).ToDto();

        /// <summary>
        /// Creates a student
        /// </summary>
        /// <param name="studentToCreate">student to create info</param>
        /// <returns>student info</returns>
        [HttpPost]
        public StudentToGetDto CreateStudent([FromBody] StudentToCreateDto studentToCreate) =>
             dal.CreateStudent(studentToCreate.ToEntity()).ToDto();

        /// <summary>
        /// Updates a student
        /// </summary>
        /// <param name="studentToUpdate"></param>
        /// <returns></returns>
        [HttpPatch]
        public StudentToGetDto UpdateStudent([FromBody] StudentToUpdateDto studentToUpdate) =>
             dal.UpdateStudent(studentToUpdate.ToEntity()).ToDto();

        /// <summary>
        /// Updates the address / Creates the address
        /// </summary>
        /// <param name="id">student id</param>
        /// <param name="addressToUpdate">address info</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdateStudentAddress([FromRoute] int id, [FromBody] AddressToUpdateDto addressToUpdate)
        {

            if (dal.UpdateOrCreateStudentAddress(id, addressToUpdate.ToEntity()))
            {
                return Created("succeess", null);
            }
            return Ok();
        }

        /// <summary>
        /// Deletes a student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        { 
            if (id == 0 ) 
            {
                return BadRequest("id cannot be 0");
            }
            try
            {
                dal.DeleteStudent(id);
            }
            catch (InvalidIdException ex) 
            {
                return NotFound(ex.Message);
            }
            return Ok();
        }
    }
}
