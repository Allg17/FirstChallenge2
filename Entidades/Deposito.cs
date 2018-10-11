using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entidades
{
    public class Deposito
    {
        [Key]
        public int DepositoId { get; set; }
        public DateTime Fecha { get; set; }
        public int CuentaId { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }

        public Deposito(int depositoId, DateTime fecha, int cuentaId, string concepto, decimal balance)
        {
            DepositoId = depositoId;
            Fecha = fecha;
            CuentaId = cuentaId;
            Concepto = concepto;
            Monto = balance;
        }

        public Deposito()
        {
            DepositoId = 0;
            Fecha = DateTime.Now;
            CuentaId = 0;
            Concepto = string.Empty;
            Monto = 0;
        }
    }
}
