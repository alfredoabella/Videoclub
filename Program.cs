using System;
using System.Data.SqlClient;

namespace Videoclub
{
    class Program
    {
        static String connectionString = "Server=localhost,1433;Database=VideoClub;User Id=SA;Password=Bootcamp2018;";
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        static void Main(string[] args)
        {

            //INSERTAR REGISTRO A TABLA PELICULA
            //conexion.Open();

            //cadena = "INSERT INTO peliculas(ID,Nombre,Edad_Recomendada,FechaEstreno, Genero, Descripcion,Disponibilidad_Pelicula) VALUES( ";
            //comando = new SqlCommand(cadena, conexion);
            //comando.ExecuteNonQuery();

            //conexion.Close();

            //EDITAR UN REGISTRO DE LA TABLA PELICULA
            //conexion.Open();

            //string respuesta = Console.ReadLine();
            //cadena = "UPDATE peliculas SET Disponibilidad_Pelicula = false WHERE ID LIKE '"+ respuesta +"'";
            //comando = new SqlCommand(cadena, conexion);
            //comando.ExecuteNonQuery();

            //conexion.Close();

            //HACER UNA CONSULTA A LA TABLA PELICULA. Sirve para mostrar las películas desde el SQL según su edad.
            conexion.Open();
            cadena = "SELECT * FROM peliculas where Edad_Recomendada < " + 99;
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["ID"].ToString() + "\t" + registros["Nombre"].ToString() + "\t" + registros["Edad_Recomendada"].ToString() + "\t" + registros["FechaEstreno"].ToString() + "\t" + registros["Genero"].ToString() + "\t" + registros["Descripcion"].ToString() + "\t" + registros["Disponibilidad_Pelicula"].ToString());
                Console.WriteLine();
            }

            conexion.Close();

            Console.ReadLine();
        }


    }

}
