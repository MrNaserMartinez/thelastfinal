using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thelastofus.datanice
{
    internal class final
    {

       
            private string connectionString = "Server=localhost;Database=thelast;Uid=root;Pwd=trabajosmysql12";

            public bool ProbarConexion()
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        public DataTable LeerPersonajes()
        {
            DataTable consolasbonitas = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM catalogo_consolas";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(consolasbonitas);
                    }
                }
            }

            return consolasbonitas;
        }

        public DataTable BuscarPersonajePorId(int id)
        {
            DataTable personaje = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM catalogo_consolas WHERE id = @id";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(personaje);
                    }
                }
            }

            return personaje;
        }
        public int CrearPersonaje(string nombre_consola, string compania, int anio_lanzamiento, int generacion)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string sql = "INSERT INTO catalogo_consolas (nombre_consola, compania, anio_lanzamiento, generacion) VALUES (@nombre_consola,@compania,@anio_lanzamiento,@generacion) ";
                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@nombre_consolas", nombre_consola);
                    command.Parameters.AddWithValue("@compania", compania);
                    command.Parameters.AddWithValue("@anio_lanzamiento", anio_lanzamiento);
                    command.Parameters.AddWithValue("@generacion", generacion);

                    return command.ExecuteNonQuery();
                }
            }
        }
    }

}
