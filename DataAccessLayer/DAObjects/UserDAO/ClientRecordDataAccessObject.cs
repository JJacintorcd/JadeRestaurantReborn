using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vRecodme.Rd.JadeRest.DataAccessLayer.DAObjects.MenuDAO.Contexts;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.MenuDAO.DAObjects.UserDAO
{
    public class ClientRecordDataAccessObject
    {
        private RestaurantContext _context;

        public ClientRecordDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region Create

        public void Create(ClientRecord client)
        {
            _context.ClientRecords.Add(client);
            _context.SaveChanges();

        }

        public async Task CreateAsync(ClientRecord client)
        {
            await _context.ClientRecords.AddAsync(client);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Read

        public ClientRecord Read(Guid id)
        {
            return _context.ClientRecords.FirstOrDefault(x => x.Id == id);

        }

        public async Task<ClientRecord> ReadAsync(Guid id)
        {
            return await
                new Task<ClientRecord>(() => _context.ClientRecords.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region Update

        public void Update(ClientRecord client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(ClientRecord client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Delete

        public void Delete(ClientRecord client)
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

        public async Task DeleteAsync(ClientRecord client)
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
        public List<ClientRecord> List()
        {
            return _context.Set<ClientRecord>().ToList();
        }
        public async Task<List<ClientRecord>> ListAsync()
        {
            return await _context.Set<ClientRecord>().ToListAsync();
        }
        #endregion
    }
}
