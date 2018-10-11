using System;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class CuentaBancaria
    {
        [Key]
        public int CuentaId { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public decimal Balance { get; set; }

        public CuentaBancaria(int cuentaId, DateTime fecha, string nombre, decimal balance)
        {
            CuentaId = cuentaId;
            Fecha = fecha;
            Nombre = nombre;
            Balance = balance;
        }

        public CuentaBancaria()
        {
            CuentaId = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Balance = 0;
        }
    }
}
