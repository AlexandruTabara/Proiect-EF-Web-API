using Data.Models;
using Proiect__EF___Web_API_.Dtos;
using System.Diagnostics;

namespace Proiect__EF___Web_API_.Utils
{
    public static class  MarkUtils
    {
        public static MarksToCreateDto ToDto(this Mark grade)
        {
            if (grade == null)
            {
                return null;
            }
            return new MarksToCreateDto
            {
                CourseId = grade.Id,
                StudentId = grade.StudentId,
                Value = grade.Value,
            };
        }
    }
}

