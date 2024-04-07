using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicamParadigmi.Models.Entities;

namespace UnicamParadigmi.Test.Examples
{
    public class AdoNetExample
    {
        public void RunExample()
        {
            AggiuntaLibro();
        }

        private List<Libro> GetLibri()
        {
            List<Libro> list = new List<Libro>();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=localhost; Database=Paradigmi; User Id=AdParadigmi; Password=AdParadigmi;";
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT ISBN,Nome,Autore,Editore,DatadiPubblicazione,Categoria FROM Libri";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var libro = new Libro();
                            libro.ISBN = (string)reader["ISBN"];
                            libro.Nome = (string)reader["Nome"];
                            libro.Autore = (string)reader["Autore"];
                            libro.Editore = (string)reader["Editore"];
                            libro.DatadiPubblicazione = (DateTime)reader["DatadiPubblicazione"];
                            libro.Categoria = (string)reader["Categoria"];
                            list.Add(libro);
                        }
                    }
                }
            }
            return list;
        }

        private void AggiuntaLibro()
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=localhost; Database=Paradigmi; User Id=AdParadigmi; Password=AdParadigmi;";
                connection.Open();

                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Libri(ISBN,Nome,Autore,Editore,DatadiPubblicazione,Categoria) VALUES(@ISBN,@Nome,@Autore,@Editore,@DatadiPubblicazione,@Categoria);";
                cmd.Parameters.AddWithValue("@ISBN", "978-88-347-3835-1");
                cmd.Parameters.AddWithValue("@Nome", "La grande Caccia");
                cmd.Parameters.AddWithValue("@Autore", "Robert Jordan");
                cmd.Parameters.AddWithValue("@Editore", "Fanucci Editore");
                cmd.Parameters.AddWithValue("@DatadiPubblicazione", "31/03/2000");
                cmd.Parameters.AddWithValue("@Categoria", "Fantasy");
                cmd.ExecuteNonQuery();
            }
        }

    }
}
