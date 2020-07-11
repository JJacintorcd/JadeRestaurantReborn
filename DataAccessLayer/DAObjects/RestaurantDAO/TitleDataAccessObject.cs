using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts;
using Recodme.Rd.JadeRest.DataLayer.RestaurantData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.MenuDAO.DAObjects.TitleDAO
{
    public class TitleDataAccessObject
    {
        private RestaurantContext _context;

        public TitleDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Title Title)
        {
            _context.Titles.Add(Title);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Title Title)
        {
            await _context.Titles.AddAsync(Title);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Title Read(Guid id)
        {
            return _context.Titles.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Title> ReadAsync(Guid id)
        {
            return await
                new Task<Title>(() => _context.Titles.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Title Title)
        {
            _context.Entry(Title).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Title Title)
        {
            _context.Entry(Title).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Title Title)
        {
            Title.IsDeleted = true;
            Update(Title);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Title Title)
        {
            Title.IsDeleted = true;
            await UpdateAsync(Title);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List

        public List<Title> List()
        {
            return _context.Set<Title>().ToList();
        }
        public async Task<List<Title>> ListAsync()
        {
            return await _context.Set<Title>().ToListAsync();
        }

        #endregion
    }
}
