using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        private readonly StudentsDbContext ctx;
        public DataAccessLayerService(StudentsDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Student> GetAllStudents() => ctx.Students.ToList();

        public Student GetStudentById(int id)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new InvalidIdException($"invalid student id {id}");
            }
            return student;
        }


        public Student CreateStudent(Student student)
        {
            if (ctx.Students.Any(s => s.Id == student.Id))
            {
                throw new InvalidIdException($"duplicated student id");
            }

            ctx.Add(student);
            ctx.SaveChanges();

            return student;
        }

        public Student UpdateStudent(Student studentToUpdate)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentToUpdate.Id);
            if (student == null)
            {
                student = new Student();
                ctx.Add(student);
            }

            student.Name = studentToUpdate.Name;
            student.Age = studentToUpdate.Age;

            ctx.SaveChanges();

            return student;
        }

        public bool UpdateOrCreateStudentAddress(int studentId, Address newAddress)
        {
            var student = ctx.Students.Include(s => s.Address).FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                throw new InvalidIdException("Student does not exist");
            }

            var created = false;
            if (student.Address == null)
            {
                student.Address = new Address();
                created = true;
            }

            student.Address.City = newAddress.City;
            student.Address.Street = newAddress.Street;
            student.Address.Number = newAddress.Number;

            ctx.SaveChanges();
            return created;

        }

        public void DeleteStudent(int studentId)
        {
            var student = ctx.Students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new InvalidIdException($"student not found {studentId}");
            }

            ctx.Students.Remove(student);
            ctx.SaveChanges();
        }
    }
}
