using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mvc3rdParty.Data.Foundation
{
    public interface IRepository<T, in TId> where T: class
    {
        T Get(TId id);
        IQueryable<T> GetAll();
        void Add(T newEntity);
        void Update(T entity);
        void Delete(T entity);
        void Transaction(Action action);
    }
}
