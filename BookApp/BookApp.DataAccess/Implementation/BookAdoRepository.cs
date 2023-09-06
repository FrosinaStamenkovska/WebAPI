using BookApp.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DataAccess.Implementation
{
    public class BookAdoRepository : IRepository<Book>
    {
        private readonly string sqlConnectionString = "Server=.;Database=bookAppDb;Trusted_Connection=True;Encrypt=False";
        public void Add(Book entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book entity)
        {
            throw new NotImplementedException();
        }

        public Book Filter(string author, string title)
        {
            if(string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
            {
                return GetAll().FirstOrDefault();
            }

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;

            if(!string.IsNullOrEmpty(author) && string.IsNullOrEmpty(title))
            {
                command.CommandText = $"Select * From dbo.Books Where Author = @param1";
                
            }
            else if (string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(title))
            {
                command.CommandText = $"Select * From dbo.Books Where Title = @param2";

            }
            else
            {
                command.CommandText = $"Select * From dbo.Books Where Author = @param1 AND Title = @param2";
            }

            command.Parameters.AddWithValue("@param1", author);
            command.Parameters.AddWithValue("@param2", title);

            List<Book> books = new List<Book>();

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Book book = new Book
                {
                    Id = (int)sqlDataReader["Id"],
                    Title = (string)sqlDataReader["Title"],
                    Author = (string)sqlDataReader["Author"],
                };

                books.Add(book);
            }

            sqlConnection.Close();

            return books.FirstOrDefault();
        }

        public List<Book> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = $"Select * From dbo.Books";

            List<Book> books = new List<Book>();

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Book book = new Book
                {
                    Id = (int)sqlDataReader["Id"],
                    Title = (string)sqlDataReader["Title"],
                    Author = (string)sqlDataReader["Author"], 
                };

                books.Add(book);
            }

            sqlConnection.Close();

            return books;
        }

        public Book GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionString);
            sqlConnection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = $"Select * From dbo.Books Where Id = @param1";
            command.Parameters.AddWithValue("@param1", id);

            List<Book> books = new List<Book>();

            SqlDataReader sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Book book = new Book
                {
                    Id = (int)sqlDataReader["Id"],
                    Title = (string)sqlDataReader["Title"],
                    Author = (string)sqlDataReader["Author"],
                };

                books.Add(book);
            }

            sqlConnection.Close();

            return books.FirstOrDefault();
        }

        public void Update(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
