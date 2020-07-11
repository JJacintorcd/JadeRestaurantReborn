using Microsoft.EntityFrameworkCore;
using Recodme.Rd.JadeRest.DataLayer.UserData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recodme.Rd.JadeRest.DataAccessLayer.Contexts;

namespace Recodme.Rd.JadeRest.DataAccessLayer.DAOObjects.UserDAO
{
    public class PersonDataAccessObject
    {
        private RestaurantContext _context;

        public PersonDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region Create

        public void Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Read

        public Person Read(Guid id)
        {
            return _context.People.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Person> ReadAsync(Guid id)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Id == id);

        }

        #endregion

        #region Update

        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region Delete

        public void Delete(Person person)
        {
            person.IsDeleted = true;
            Update(person);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Person person)
        {
            person.IsDeleted = true;
            await UpdateAsync(person);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List
        public List<Person> List()
        {
            return _context.Set<Person>().ToList();
        }
        public async Task<List<Person>> ListAsync()
        {
            return await _context.Set<Person>().ToListAsync();
        }
        #endregion
    }
}
