using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TDDApp.Models;

namespace TDDApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private bool _disposed = false;
        private AppDbContext _db;

        public List<Person> GetList()
        {
            return _db.Persons.ToList();
        }

        public Person Get(int id)
        {
            return _db.Persons.Find(id);
        }

        public void Create(Person item)
        {
            _db.Persons.Add(item);
        }

        public void Update(Person item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var person = _db.Persons.FirstOrDefault(p => p.Id == id);
            if (person != null)
            {
                _db.Persons.Remove(person);
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (NotDisposed())
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

            _disposed = true;
        }

        private bool NotDisposed()
        {
            return !_disposed;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}