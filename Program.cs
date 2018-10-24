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

            Menu();
        }

        public static void Menu()
        {
            int elecciónMenu;
            const int LOGIN = 1, REGISTRO = 2, EXIT = 3;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Bienvenido, al VideoCamp:\n" +
                                  "1. Inicia Sesión\n" +
                                  "2. Registrese por primera vez\n" +
                                  "3. Salir\n");

                elecciónMenu = Convert.ToInt32(Console.ReadLine());
                if (elecciónMenu > 0 && elecciónMenu < 4)
                {
                    switch (elecciónMenu)
                    {
                        case LOGIN:
                            InicioCliente(); 
                            break;
                        case REGISTRO:
                            //RegistroCliente();
                            Console.WriteLine("Aquí entrariamos en registro cliente");
                            break;
                        case EXIT:
                            Console.WriteLine("Gracias por su tiempo, esperemos que vuelva pronto");
                            break;
                    }
                }
            } while (elecciónMenu != EXIT);
        }

        public static void InicioCliente()
        {
            string emailCliente, contraseniaCliente;//
            bool meterRegistro;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Introduzca su email: ");
                emailCliente = Console.ReadLine();

                conexion.Open();

                cadena = "SELECT * FROM Clientes WHERE Email LIKE '" + emailCliente + "';";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();
                meterRegistro = registros.Read();

                conexion.Close();

            } while (!meterRegistro);

            do
            {
                Console.WriteLine();
                Console.WriteLine("Email incorrecto, name (N) or surname (S) of the client? (N/S)");
                answer = Console.ReadLine().ToUpper();
            } while (answer != "N" && answer != "S");

            if (answer == "N")
            {
                conexion.Open();

                Console.WriteLine();
                Console.WriteLine("Enter the new name, please: ");
                nameClient = Console.ReadLine();
                cadena = "UPDATE CLIENTE SET Nombre = '" + nameClient + "' WHERE DNI LIKE '" + DNI + "';";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();

            }
            else if (answer == "S")
            {
                conexion.Open();

                Console.WriteLine();
                Console.WriteLine("Enter the new surname, please: ");
                surnameClient = Console.ReadLine();
                cadena = "UPDATE Clientes SET Apellidos = '" + surnameClient + "' WHERE DNI LIKE '" + DNI + "';";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            Console.WriteLine("User correction done.");
        }

        public static void RegistroCliente()
        {
            string emailCliente, contraseniaCliente, nombreCliente, ApellidosCliente;
            DateTime FechaNacimiento;

            Console.WriteLine();
            Console.WriteLine("Introduzca su email: ");
            emailCliente = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Introduzca su contraseña: ");
            contraseniaCliente = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Introduzca su nombre: ");
            nombreCliente = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Introduzca sus apellidos: ");
            ApellidosCliente = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Introduzca su fecha de nacimiento: ");
            FechaNacimiento = Convert.ToDateTime(Console.Read());
            conexion.Open();

            cadena = "INSERT INTO Clientes VALUES ('" + emailCliente + "','" + contraseniaCliente + "','" + nombreCliente + "','" + ApellidosCliente + "');";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();

            conexion.Close();

            Console.WriteLine("Registro realizado con éxito.");
        }

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








        ////HACER UNA CONSULTA A LA TABLA PELICULA. Sirve para mostrar las películas desde el SQL según su edad.
        //conexion.Open();
            //cadena = "SELECT * FROM peliculas where Edad_Recomendada < " + 99;
            //comando = new SqlCommand(cadena, conexion);
            //SqlDataReader registros = comando.ExecuteReader();
            //while (registros.Read())
            //{
            //    Console.WriteLine(registros["ID"].ToString() + "\t" + registros["Nombre"].ToString() + "\t" + registros["Edad_Recomendada"].ToString() + "\t" + registros["FechaEstreno"].ToString() + "\t" + registros["Genero"].ToString() + "\t" + registros["Descripcion"].ToString() + "\t" + registros["Disponibilidad_Pelicula"].ToString());
            //    Console.WriteLine();
            //}

            //conexion.Close();

            //Console.ReadLine();
        }


    }

}
