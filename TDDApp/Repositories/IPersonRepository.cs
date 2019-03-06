using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TDDApp.Models;

namespace TDDApp.Repositories
{
    public interface IPersonRepository : IDisposable
    {
        List<Person> GetList();
        Person Get(int id);
        void Create(Person item);
        void Update(Person item);
        void Delete(int id);
        void Save();
    }
}