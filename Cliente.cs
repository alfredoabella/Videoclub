using System;
namespace Videoclub
{
    public class Cliente
    {
        private int ID;
        private string email;
        private string nombre;
        private string apellidos;
        private DateTime Fecha_Nacimiento;
        private static int contador = 0;
        private string contrasenia;

        public Cliente(int ID, string email, string nombre, string apellidos, DateTime Fecha_Nacimiento,string contrasenia)
        {
            this.ID = ID;
            this.email = email;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.Fecha_Nacimiento = Fecha_Nacimiento;
            this.contrasenia = contrasenia;
            contador++;
        }

        public int GetID()
        {
            return ID;
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }

        public string GetNombre()
        {
            return nombre;
        }
        public void SetNom(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetApellidos()
        {
            return apellidos;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }

        public DateTime GetFecha_Nacimiento()
        {
            return Fecha_Nacimiento;
        }
        public void SetEdad(DateTime Fecha_Nacimiento)
        {
            this.Fecha_Nacimiento = Fecha_Nacimiento;
        }

        public string Getcontrasenia()
        {
            return contrasenia;
        }
        public void Setcontrasenia(string contrasenia)
        {
            this.contrasenia = contrasenia;
        }

        public int GetContador()
        {
            return contador;
        }
        public void SetContador(int contador)
        {
            Cliente.contador = contador;
        }
    }
}
