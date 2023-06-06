using System;
using Data.Models;
using Data.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL 
{
    public partial class DataAccessLayerService : IDataAccessLayerService
    {
        public Course AddCourse(string courseName)
        {
            var cours = new Course { Name = courseName };
            ctx.Courses.Add(cours);
            ctx.SaveChanges();
            return cours;
        }
        public List<Course> GetAllCourses() =>
             ctx.Courses.ToList();
        
    }
}
