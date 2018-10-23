using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }
        public int IdCuenta { get; set; }
        public decimal Interes { get; set; }
        public int Tiempo { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Capital { get; set; }
        public virtual List<Cuota> Detalle { get; set; }

        public Prestamo(int idPrestamo, decimal interes, int idCuenta,decimal capital, int tiempo, List<Cuota> detalle,DateTime fecha)
        {
            IdPrestamo = idPrestamo;
            IdCuenta = idCuenta;
            Tiempo = tiempo;
            Detalle = detalle;
            Fecha = Fecha;
            Capital = capital;
            Interes = interes;
        }

        public Prestamo()
        {
            IdPrestamo = 0;
            Capital = 0;
            IdCuenta = 0;
            Tiempo = 0;
            Detalle = new List<Cuota>();
            Fecha = DateTime.Now;
            Interes = 0;
        }

        public Prestamo(int idPrestamo, decimal interes, int idCuenta, decimal capital, int tiempo, DateTime fecha)
        {
            IdPrestamo = idPrestamo;
            IdCuenta = idCuenta;
            Tiempo = tiempo;
      
            Fecha = Fecha;
            Capital = capital;
            Interes = interes;
        }


    }
}
