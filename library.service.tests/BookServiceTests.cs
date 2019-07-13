﻿using library.data.Contracts;
using library.domain;
using Moq;
using NUnit.Framework;

namespace library.service.tests
{
    [TestFixture()]
    public class BookServiceTests
    {
        [Test()]
        public void Test_CreateBook_WithPrice50_ShouldCategoryBeCheap()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            bookRepositoryMock.Setup(bookRepository => bookRepository.Save(It.IsAny<Book>())).Returns(10);
            var bookService = new BookService(bookRepositoryMock.Object);

            var newBook = bookService.CreateBook("Sherlock Holmes", "Sir Arthur Conan Doyle", 50);

            Assert.AreEqual(BookCategory.Cheap, newBook.Category);
        }

        [Test()]
        public void Test_CreateBook_WithPrice100_ShouldCategoryBeExpensive()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            bookRepositoryMock.Setup(bookRepository => bookRepository.Save(It.IsAny<Book>())).Returns(10);
            var bookService = new BookService(bookRepositoryMock.Object);

            var newBook = bookService.CreateBook("Lord of the Rings", "J.R.R. Tolkien", 100);

            Assert.AreEqual(BookCategory.Expensive, newBook.Category);
        }

        [Test()]
        public void Test_CreateBook_WithPrice350_ShouldCategoryBeExpensive()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            bookRepositoryMock.Setup(bookRepository => bookRepository.Save(It.IsAny<Book>())).Returns(10);
            var bookService = new BookService(bookRepositoryMock.Object);

            var newBook = bookService.CreateBook("2001", "Sir Arthur C. Clarke", 350);

            Assert.AreEqual(BookCategory.Expensive, newBook.Category);
        }

        [Test()]
        public void Test_CreateBook_WithPrice1000_ShouldCategoryBeRare()
        {
            var bookRepositoryMock = new Mock<IRepository<Book>>();
            bookRepositoryMock.Setup(bookRepository => bookRepository.Save(It.IsAny<Book>())).Returns(10);
            var bookService = new BookService(bookRepositoryMock.Object);

            var newBook = bookService.CreateBook("Jurrasic Park", "Michael Crichton", 1000);

            Assert.AreEqual(BookCategory.Rare, newBook.Category);
        }
    }
}
