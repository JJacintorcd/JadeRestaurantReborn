using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.WebApi.Models.MenuViewModels
{
    public class CourseViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Course ToCourse()
        {
            return new Course(Name);
        }

        public static CourseViewModel Parse(Course course)
        {
            return new CourseViewModel()
            {
                Id = course.Id,
                Name = course.Name
            };
        }
    }
}
