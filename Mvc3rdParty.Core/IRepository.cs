using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc3rdParty.Core
{
    public interface IRepository<T> where T: class
    {
         T Get(int id);
         void Add(T newEntity);
         void Update(T entity);
         void Delete(T entity);
         IQueryable<T> GetAll();
         void Transaction(Action action);
    }
}
