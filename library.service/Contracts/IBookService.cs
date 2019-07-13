﻿using System;
using System.Collections.Generic;
using library.domain;

namespace library.service.Contracts
{
    public interface IBookService
    {
        Book CreateBook(string name, string author, int price);
        List<Book> GetAvailableBooks();
        Book GetBook(int id);
    }
}
