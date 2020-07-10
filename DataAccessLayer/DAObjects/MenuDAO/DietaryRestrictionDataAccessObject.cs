using Microsoft.EntityFrameworkCore;
using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts;
using Recodme.Rd.JadeRest.DataLayer.MenuData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO
{
    public class DietaryRestrictionDataAccessObject
    {
        private RestaurantContext _context;
        public DietaryRestrictionDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region Create
        public void Create(DietaryRestriction dietaryRestriction)
        {
            _context.DietaryRestrictions.Add(dietaryRestriction);
            _context.SaveChanges();
        }

        public async Task CreateAsync(DietaryRestriction dietaryRestriction)
        {
            await _context.DietaryRestrictions.AddAsync(dietaryRestriction);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Read
        public DietaryRestriction Read (Guid id)
        {
            return _context.DietaryRestrictions.FirstOrDefault(x => x.Id == id);
        }

        public async Task<DietaryRestriction> ReadAsync (Guid id)
        {
            return await new Task<DietaryRestriction>(() => _context.DietaryRestrictions.FirstOrDefault(x => x.Id == id));
        }
        #endregion

        #region Update
        public void Update(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task UpdateAsync(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public void Delete(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            Update(dietaryRestriction);
        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);
        }

        public async Task DeleteAsync(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            await UpdateAsync(dietaryRestriction);
        }

        public async Task DeleteAsync(Guid id)
        {
            var item = await ReadAsync(id);
            if (item == null) return;
            await DeleteAsync(item);
        }
        #endregion

        #region List
        public List<DietaryRestriction> List()
        {
            return _context.Set<DietaryRestriction>().ToList();
        }

        public async Task<List<DietaryRestriction>> ListAsync()
        {
            return await _context.Set<DietaryRestriction>().ToListAsync();
        }
        #endregion
    }
}
