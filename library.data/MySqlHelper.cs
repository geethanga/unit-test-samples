using System;
using MySql.Data.MySqlClient;

namespace library.data
{
    public class MySqlHelper
    {
        private const string CONNECTION_STRING = "Server=localhost;Port=3306;Database=library;Uid=root;Pwd=root;";

        private MySqlCommand GetCommand(string commandText)
        {
            MySqlConnection conn = new MySqlConnection(CONNECTION_STRING);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = commandText;

            return cmd;
        }

        public int ExecuteInsert(string insertCommand)
        {
            insertCommand += ";select last_insert_id();";
            var cmd = GetCommand(insertCommand);

            var id = cmd.ExecuteScalar();
            return int.Parse(id.ToString());
        }
    }
}
