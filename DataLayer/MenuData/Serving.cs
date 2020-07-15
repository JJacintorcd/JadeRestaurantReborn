using Recodme.Rd.JadeRest.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recodme.Rd.JadeRest.DataLayer.MenuData
{
    public class Serving : Entity
    {
        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }
        public virtual Menu Menu { get; set; }


        [ForeignKey("Dish")]
        public Guid DishId { get; set; }
        public virtual Dish Dish { get; set; }


        [ForeignKey("Course")]
        public Guid CourseId { get; set; }
        public virtual Course Course { get; set; }


        public Serving(Guid menuId, Guid dishId, Guid courseId)
        {
            MenuId = menuId;
            DishId = dishId;
            CourseId = courseId;
        }

        public Serving(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, Guid menuId, Guid dishId, Guid courseId) : base(id, createdAt, updatedAt, isDeleted)
        {
            MenuId = menuId;
            DishId = dishId;
            CourseId = courseId;
        }
    }
}