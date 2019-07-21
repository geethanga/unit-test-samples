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


        public Book CreateBook(string name, string author, int price, int totalQty)
        {
            var book = new Book
            {
                Name = name,
                Author = author,
                Price = price,
                TotalCopies = totalQty,
                AvailableCopies = totalQty
            };
            if (price < 10)
            {
                throw new ArgumentOutOfRangeException(nameof(price), "Price should be greater than or equal to 0");
            }

            if (totalQty < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(totalQty), "Total should be greater than 0");
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

        public bool ReturnBook(int bookId, int memberId)
        {
            var book = _bookRepository.GetById(bookId);

            if (book.TotalCopies >= book.AvailableCopies + 1)
            {
                book.AvailableCopies += 1;
            }
            else
            {
                return false;
            }

            _bookRepository.Save(book);

            return true;
        }
    }
}
