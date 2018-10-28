using System;
namespace Videoclub
{
    public class Peliculas
    {
        private int ID;
        private string nombre;
        private int edadRecomendada;
        private DateTime Fecha_Estreno;
        private string genero;
        private string descripcion;
        private string disponibilidad;

        public Peliculas(int ID, string nombre, int edadRecomendada, DateTime Fecha_Estreno, string genero, string descripcion, string disponibilidad)
        {
            this.ID = ID;
            this.nombre = nombre;
            this.edadRecomendada = edadRecomendada;
            this.Fecha_Estreno = Fecha_Estreno;
            this.genero = genero;
            this.descripcion = descripcion;
            this.disponibilidad = disponibilidad;
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
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }


        public int GetEdadRecomendada()
        {
            return edadRecomendada;
        }
        public void SetEdadRecomendada(int edadRecomendada)
        {
            this.edadRecomendada = edadRecomendada;
        }


        public DateTime GetFecha_Estreno()
        {
            return Fecha_Estreno;
        }
        public void SetFecha_Estreno(DateTime Fecha_Estreno)
        {
            this.Fecha_Estreno = Fecha_Estreno;
        }


        public string GetGenero()
        {
            return genero;
        }
        public void SetGenero(string genero)
        {
            this.genero = genero;
        }


        public string GetDescripcion()
        {
            return descripcion;
        }
        public void SetDescripcion(string descripcion)
        {
            this.descripcion = descripcion;
        }


        public string GetDisponibilidad()
        {
            return disponibilidad;
        }
        public void SetDisponibilidad(string disponibilidad)
        {
            this.disponibilidad = disponibilidad;
        }

    }
}
