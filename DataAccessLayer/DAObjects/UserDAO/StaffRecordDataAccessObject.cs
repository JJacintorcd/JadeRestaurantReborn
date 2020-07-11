using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.UserDAO
{
    public class StaffRecordDataAccessObject
    {
        private RestaurantContext _context;

        public StaffRecordDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region Create

        public void Create(StaffRecord staffRecord)
        {
            _context.StaffRecords.Add(staffRecord);
            _context.SaveChanges();

        }

        public async Task CreateAsync(StaffRecord staffRecord)
        {
            await _context.StaffRecords.AddAsync(staffRecord);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Read

        public StaffRecord Read(Guid id)
        {
            return _context.StaffRecords.FirstOrDefault(x => x.Id == id);

        }

        public async Task<StaffRecord> ReadAsync(Guid id)
        {
            return await _context.StaffRecords.FirstOrDefaultAsync(x => x.Id == id);

        }

        #endregion

        #region Update

        public void Update(StaffRecord staffRecord)
        {
            _context.Entry(staffRecord).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(StaffRecord staffRecord)
        {
            _context.Entry(staffRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Delete

        public void Delete(StaffRecord staffRecord)
        {
            staffRecord.IsDeleted = true;
            Update(staffRecord);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(StaffRecord staffRecord)
        {
            staffRecord.IsDeleted = true;
            await UpdateAsync(staffRecord);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List

        public List<StaffRecord> List()
        {
            return _context.Set<StaffRecord>().ToList();

        }

        public async Task<List<StaffRecord>> ListAsync()
        {
            return await _context.Set<StaffRecord>().ToListAsync();

        }

        #endregion
    }
}
