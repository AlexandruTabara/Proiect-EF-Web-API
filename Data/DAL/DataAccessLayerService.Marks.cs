using Data.Exceptions;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public void AddMark(int value, int studentId, int courseId)
        {
            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"id student invalid {studentId}");
            }
            if (!ctx.Courses.Any(s => s.Id == courseId))
            {
                throw new InvalidIdException($"id curs invalid {courseId}");
            }

            ctx.Marks.Add(new Mark { Value = value, StudentId = studentId, CourseId = courseId });
            ctx.SaveChanges();
        }
    }
}
