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
        static int id;

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
                Console.WriteLine("Registrate o inicia sesión en tu experiencia visual definitiva:\n" +
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
                            RegistroCliente();
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
            string emailCliente, contraseniaCliente;
            bool meterRegistro = false;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Introduzca su email: ");
                emailCliente = Console.ReadLine();
                Console.WriteLine("Introduzca su contraseña: ");
                contraseniaCliente = Console.ReadLine();
                conexion.Open();

                cadena = "SELECT ID FROM Clientes WHERE Email LIKE '" + emailCliente + "' and Pass LIKE '" + contraseniaCliente + "';";
                comando = new SqlCommand(cadena, conexion);
                SqlDataReader registros = comando.ExecuteReader();

                if (registros.Read())
                {
                    id = Convert.ToInt32(registros[0].ToString());
                    meterRegistro = true;
                }
                else
                {
                    meterRegistro = false;
                    Console.WriteLine("Email o contraseña incorrecto.");
                }

                conexion.Close();

            } while (!meterRegistro);

            Console.WriteLine();

            Console.WriteLine("Usuario conectado correctamente.");

            MenuBootVideo(emailCliente);
        }

        public static void MenuBootVideo(string emailCliente)
        {
            //VARIABLES MENU PRINCIPAL
            int opcion;
            const int VER_PELICULAS = 1, ALQUILAR = 2, MIS_ALQUILERES = 3, SALIR = 4;

            //MENU BOOTVIDEO
            string[] ver_peliculas =
            {
                "Listado de películas"
            };

            string[] alquilar =
            {
                "Películas disponibles"
            };

            string[] mis_alquileres =
            {
                "Películas para alquilar"
            };

            Console.WriteLine("¡Bienvenido a BootVideo! Nunca te sentirás solo.");

            do
            {
                // Menú principal
                Console.WriteLine("¿Qué quieres realizar?");
                Console.WriteLine("1- Ver películas");
                Console.WriteLine("2- Alquilar películas");
                Console.WriteLine("3- Ver mis alquileres");
                Console.WriteLine("4- Salir");
                opcion = Convert.ToInt32(Console.ReadLine());

                // Separar menú principal de las opciones siguientes
                Console.WriteLine();
                switch (opcion)
                {
                    case VER_PELICULAS:
                        //Muestra el listado de películas completo dependediendo de la edad del usuario que ha realizado login.
                        ListadoDePeliculas();
                        break;

                    case ALQUILAR:
                        //Muestra el listado total de películas disponibles para alquilar para el usuario según su edad.
                        AlquilarPeliculas();
                        break;

                    case MIS_ALQUILERES:
                        //Muestra el historico de alquileres realizados por el usuario logeado.
                        MisAlquileres();
                        break;

                    case SALIR:
                        break;

                    default:
                        Console.WriteLine("Opción no disponible. Volver a elegir.");
                        break;
                }

                // Separamos el menú de opciones al acabar la opción elegida
                Console.WriteLine();
            } while (opcion != SALIR);

        }

        public static int ConsultaEdad()
        {
            //CONSULTAR EDAD DEL CLIENTE SEGÚN SU ID.
            conexion.Close();
            conexion.Open();
            cadena = "SELECT DATEDIFF(YEAR,Fecha_Nacimiento,GETDATE()) FROM Clientes where ID= " + id;
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            int edad = 0;
            if (registros.Read())
            {
                edad = Convert.ToInt32(registros[0].ToString());

            }
            registros.Close();
            conexion.Close();

            return edad;
        }

        public static void ListadoDePeliculas()
        {

            //HACER UNA CONSULTA A LA TABLA PELICULA. Sirve para mostrar las películas desde el SQL según su edad.
            cadena = "SELECT * FROM Peliculas where Edad_Recomendada<= " + ConsultaEdad();
            conexion.Open();
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



        public static void AlquilarPeliculas()
        {
            int opcion;

            //HACER UNA CONSULTA A LA TABLA PELICULA. Alquilar la película que deseen siempre que esté disponible. Una vez alquilada, la película deberá pasar a modo no disponible.

            cadena = "SELECT * FROM peliculas WHERE Edad_Recomendada <= '" + ConsultaEdad() + "' and Disponibilidad_Pelicula = 'Disponible';";
            conexion.Open();
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["ID"].ToString() + "\t" + registros["Nombre"].ToString() + "\t" + registros["Edad_Recomendada"].ToString() + "\t" + registros["FechaEstreno"].ToString() + "\t" + registros["Genero"].ToString() + "\t" + registros["Descripcion"].ToString() + "\t" + registros["Disponibilidad_Pelicula"].ToString());
                Console.WriteLine();
            }

            conexion.Close();

            //preguntarle al cliente que película quiere alquilar por el ID de la película.

            Console.WriteLine("¿Qué pelicula desea alquilar?");
            opcion = Convert.ToInt32(Console.ReadLine());
            conexion.Open();
            cadena = "SELECT * FROM peliculas WHERE ID =" + opcion;
            comando = new SqlCommand(cadena, conexion);
            registros = comando.ExecuteReader();

            if (registros.Read())
            {
                // la pelicula con la id opcion, poner a no disponible
                //EDITAR UN REGISTRO DE LA TABLA PELICULA
                conexion.Close();
                conexion.Open();

                string respuesta = Console.ReadLine();
                cadena = "UPDATE peliculas SET Disponibilidad_Pelicula = 'No Disponible' WHERE ID = " + opcion;
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                //INSERTAR REGISTRO A TABLA ALQUILER con id cliente (variable id) y id pelicula (variable opcion)
                // y la fecha actual con new DateTime.Now

                conexion.Open();

                cadena = "INSERT INTO Alquiler (IDCliente, IDPelicula, Fecha_Inicio) VALUES ("
                    + id + ", " + opcion + ", GETDATE())";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }
            conexion.Close();
            Console.WriteLine("Ha alquilado la película");

        }

        public static void PeliculasParaAlquilar()
        {
            //HACER UNA CONSULTA A LA TABLA PELICULA. Sirve para mostrar el historico de películas de alquiladas por el usuario logeado. 
            conexion.Open();
            cadena = "SELECT * FROM peliculas WHERE Edad_Recomendada < " + ConsultaEdad();
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

        public static void MisAlquileres()
        {
            conexion.Open();
            cadena = "SELECT * FROM Alquiler WHERE IDCliente = " + id;
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();

            while (registros.Read())
            {
                if (registros["Fecha_Fin"].ToString() == "")
                {
                    // PELICULA SIN DEVOLVER
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pelicula: " + registros["IDPelicula"]
                                + " Fecha alquiler: " + registros["Fecha_Inicio"]
                                + " Pendiente de devolución");
                    Console.ResetColor();

                }
                else
                {
                    // PELICULA DEVUELTA
                    Console.WriteLine("Pelicula: " + registros["IDPelicula"]
                                + " Fecha alquiler: " + registros["Fecha_Inicio"]
                                + " Fecha devolución: " + registros["Fecha_Fin"]);
                }


            }

            conexion.Close();

            Console.WriteLine("¿Quieres devolver alguna película?");
            if (Console.ReadLine() == "si")
            {
                Console.WriteLine("¿Cuál es la película que quieres devolver?");
                string IDPelicula = (Console.ReadLine());

                conexion.Open();


                cadena = " UPDATE Alquiler SET Fecha_Fin = GETDATE() WHERE IDCliente= " + id
                    + " AND IDPelicula = " + IDPelicula
                    + " AND Fecha_Fin IS NULL";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();

                conexion.Open();

                cadena = " UPDATE Peliculas SET Disponibilidad_Pelicula = 'Disponible'";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();

                conexion.Close();
            }





        }
    }
}

