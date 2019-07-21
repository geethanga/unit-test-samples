using System;
using System.Collections.Generic;
using library.data.Contracts;
using library.domain;
using MongoDB.Driver;

namespace library.data
{
    public class BookRepositoryMongoDb : IRepository<Book>
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
            //Try to write a generic MongoDB helper class
            var client = new MongoClient("mongodb+srv://root:root@cluster0-5chcr.mongodb.net/test?retryWrites=true&w=majority");
            var database = client.GetDatabase("test");

            var booksCollection = database.GetCollection<Book>("Books");
            
            if (booksCollection.CountDocuments(doc => doc.Author != "") == 0)
            {
                database.CreateCollection("Books");
            }
            var id = new Random().Next(1, 5000);
            entity.Id = id;
            booksCollection.InsertOne(entity);
            return id;
        }
    }
}
