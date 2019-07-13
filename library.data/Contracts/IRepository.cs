using System;
using System.Collections.Generic;
using library.domain;

namespace library.data.Contracts
{
    public interface IRepository<T>
    {
        int Save(T entity);
        T GetById(int id);
        List<T> GetAll();
    }
}
