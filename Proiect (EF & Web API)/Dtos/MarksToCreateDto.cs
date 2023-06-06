using System.ComponentModel.DataAnnotations;

namespace Proiect__EF___Web_API_.Dtos
{
    public class MarksToCreateDto
    {
        [Range(1,10)]
        public int Value { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}
