using System;
using System.Collections.Generic;
using library.data.Contracts;
using library.domain;
using MySql.Data.MySqlClient;

namespace library.data
{
    public class BookRepositoryMySql : IRepository<Book>
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
            MySqlConnection conn = new MySqlConnection("Server=localhost;Port=3306;Database=library;Uid=root;Pwd=root;");
            conn.Open();

            string command = "INSERT INTO `library`.`Book`(`Name`,`Author`,`Price`,`Category`,`TotalCopies`,`AvailableCopies`) VALUES" +
                                "('" + entity.Name + "','" + entity.Author + "'," + entity.Price + ",'" + entity.Category + "'," + entity.TotalCopies + "," + entity.AvailableCopies + ")";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = command;
            var id = cmd.ExecuteScalar();
            return int.Parse(id.ToString());
        }
    }
}
