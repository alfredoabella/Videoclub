using System;
namespace Videoclub
{
    public class Alquiler
    {
        private int ID;
        private int IDCliente;
        private int IDPelicula;
        private DateTime Fecha_Inicio;
        private DateTime Fecha_Fin;

        public Alquiler(int ID, int IDCliente, int IDPelicula, DateTime Fecha_Inicio, DateTime Fecha_Fin)
        {
            this.ID = ID;
            this.IDCliente = IDCliente;
            this.IDPelicula = IDPelicula;
            this.Fecha_Inicio = Fecha_Inicio;
            this.Fecha_Fin = Fecha_Fin;
        }

        public int GetID()
        {
            return ID;
        }
        public void SetID(int ID)
        {
            this.ID = ID;
        }

        public int GetIDCliente()
        {
            return IDCliente;
        }
        public void SetIDCliente(int IDCliente)
        {
            this.IDCliente = IDCliente;
        }

       
        public DateTime GetFecha_Inicio()
        {
            return Fecha_Inicio;
        }
        public void SetFecha_Inicio(DateTime Fecha_Inicio)
        {
            this.Fecha_Inicio = Fecha_Inicio;
        }

        public DateTime GetFecha_Fin()
        {
            return Fecha_Fin;
        }
        public void SetFecha_Fin(DateTime Fecha_Fin)
        {
            this.Fecha_Fin = Fecha_Fin;
        }

    }
}
