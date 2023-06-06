using Data.Models;
using Proiect__EF___Web_API_.Dtos;

namespace Proiect__EF___Web_API_.Utils
{
    public static class StudentUtils
    {
        public static StudentToGetDto ToDto(this Student student)
        {
            if (student == null)
            {
                return null;
            }
            return new StudentToGetDto { Id = student.Id, Name = student.Name, Age = student.Age };
        }

        public static Student ToEntity(this StudentToCreateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student
            {
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Student ToEntity(this StudentToUpdateDto student)
        {
            if (student == null)
            {
                return null;
            }
            return new Student
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
            };
        }

        public static Address ToEntity(this AddressToUpdateDto addressToUpdate)
        {
            if (addressToUpdate == null)
                return null;

            return new Address
            {
                City = addressToUpdate.City,
                Street = addressToUpdate.Street,
                Number = addressToUpdate.Number,
            };
        }
    }
}
