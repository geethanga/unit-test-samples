using System;
using System.Collections.Generic;
using library.data.Contracts;
using library.domain;
using library.service.Contracts;

namespace library.service
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        public BookService(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book CreateBook(string name, string author, int price)
        {
            var book = new Book
            {
                Name = name,
                Author = author,
                Price = price
            };
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price should be greater than or equal to 0");
            }
            if (price < 100)
            {
                book.Category = BookCategory.Cheap;
            }
            else if (price >= 100 && price < 500)
            {
                book.Category = BookCategory.Expensive;
            }
            else
            {
                book.Category = BookCategory.Rare;
            }

            book.Id = _bookRepository.Save(book);
            return book;
        }

        public List<Book> GetAvailableBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
