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
        public void Seed()
        {
            ctx.Add(new Student
            {
                Name = "Alex Tab",
                Age = 27,
                Address = new Address
                {
                    City = "Roman",
                    Street = "Anton Pann",
                    Number = 18,
                }
            });

            ctx.Add(new Student
            {
                Name = "Dan Pop",
                Age = 49,
                Address = new Address
                {
                    City = "Iasi",
                    Street = "Revolutiei Vechi",
                    Number = 333,
                }
            });

            ctx.Add(new Student
            {
                Name = "Madalina Honduras",
                Age = 26,
                Address = new Address
                {
                    City = "Petrosani",
                    Street = "Mineriadei",
                    Number = 99,
                }
            });

            ctx.Add(new Student
            {
                Name = "Catalin Cihai",
                Age = 19,
                Address = new Address
                {
                    City = "Timisoara",
                    Street = "Lemului",
                    Number = 111,
                }
            });

            ctx.Add(new Student
            {
                Name = "Bogdan Kosmos",
                Age = 19,
                Address = new Address
                {
                    City = "Oradea",
                    Street = "T.D. Braileanu",
                    Number = 37,
                }
            });

            ctx.SaveChanges();
        }
    }
}
