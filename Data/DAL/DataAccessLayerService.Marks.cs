using Data.Exceptions;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Mark AddMark(int value, int studentId, int courseId)
        {
            if (!ctx.Students.Any(s => s.Id == studentId))
            {
                throw new InvalidIdException($"id student invalid {studentId}");
            }
            if (!ctx.Courses.Any(s => s.Id == courseId))
            {
                throw new InvalidIdException($"id curs invalid {courseId}");
            }

            var course = ctx.Courses.FirstOrDefault(x => x.Id == courseId);
            var student = ctx.Students.FirstOrDefault(x => x.Id == studentId);

            var mark = new Mark { Value = value, StudentId = studentId, CourseId = courseId, TimeTheMarkWasGiven = DateTime.Now, Course = course, Student = student };
            ctx.Marks.Add(mark);
            ctx.SaveChanges();

            return mark;
        }
    }
}

