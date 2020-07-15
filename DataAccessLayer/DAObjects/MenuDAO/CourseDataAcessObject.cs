using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO
{
    public class CourseDataAcessObject
    {
        private RestaurantContext _context;

        public CourseDataAcessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Read

        public Course Read(Guid id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public async Task<Course> ReadAsync(Guid id)
        {
            return await _context.Courses.FirstOrDefaultAsync(x => x.Id == id);
        }

        #endregion

        #region Update

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Delete

        public void Delete(Course course)
        {
            course.IsDeleted = true;
            Update(course);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);

            if (item == null)
                return;

            Delete(item);
        }

        public async Task DeleteAsync(Course course)
        {
            course.IsDeleted = true;
            await UpdateAsync(course);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;

            if (item == null)
                return;

            await DeleteAsync(item);
        }

        #endregion

        #region List

        public List<Course> List()
        {
            return _context.Set<Course>().ToList();
        }
        public async Task<List<Course>> ListAsync()
        {
            return await _context.Set<Course>().ToListAsync();
        }

        #endregion
    }
}
