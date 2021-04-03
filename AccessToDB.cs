using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MobilePhoneShop
{
    class AccessToDB
    {
        string connectionString = @"Data Source=ASUSROG;Initial Catalog=MobilePhoneDB;Integrated Security=True"; //подключение к БД
        public DataTable Select(string selectSQL) // select запрос
        {
            DataTable dataTable = new DataTable("dataBase");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectSQL, connection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                sqlDataAdapter.Fill(dataTable);
            }
            return dataTable; // результат select запроса
        }
        public void Insert(string insertSQL) // insert/update запрос
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(insertSQL, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}
