using System;
using System.Collections.Generic;
using library.data.Contracts;
using library.domain;

namespace library.data
{
    public class BookRepository : IRepository<Book>
    {
        public List<Book> GetAll()
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
