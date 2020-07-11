using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.RestaurantDAO
{
    public class StaffTitleDataAccessObject
    {
        private RestaurantContext _context;

        public StaffTitleDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region Create

        public void Create(StaffTitle client)
        {
            _context.StaffTitles.Add(client);
            _context.SaveChanges();

        }

        public async Task CreateAsync(StaffTitle client)
        {
            await _context.StaffTitles.AddAsync(client);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Read

        public StaffTitle Read(Guid id)
        {
            return _context.StaffTitles.FirstOrDefault(x => x.Id == id);

        }

        public async Task<StaffTitle> ReadAsync(Guid id)
        {
            return await
                new Task<StaffTitle>(() => _context.StaffTitles.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region Update

        public void Update(StaffTitle client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(StaffTitle client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Delete

        public void Delete(StaffTitle client)
        {
            client.IsDeleted = true;
            Update(client);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(StaffTitle client)
        {
            client.IsDeleted = true;
            await UpdateAsync(client);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List
        public List<StaffTitle> List()
        {
            return _context.Set<StaffTitle>().ToList();
        }
        public async Task<List<StaffTitle>> ListAsync()
        {
            return await _context.Set<StaffTitle>().ToListAsync();
        }
        #endregion
    }
}
