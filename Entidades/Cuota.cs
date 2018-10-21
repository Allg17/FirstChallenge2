using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class Cuota
    {
        [Key]
        public int IdCuota { get; set; }
        public int IdPrestamo { get; set; }
        public decimal Interes { get; set; }
        public decimal Capital { get; set; }
        public decimal Valor { get; set; }
        public decimal Balance { get; set; }
        public int CuotaNum { get; set; }

        public Cuota(int idCuota,int idprestamo,int cuotasNu, decimal interes, decimal capital, decimal valor, decimal balance)
        {
            IdCuota = idCuota;
            Interes = interes;
            Capital = capital;
            Valor = valor;
            Balance = balance;
            CuotaNum = cuotasNu;
            IdPrestamo = idprestamo;

        }

        public Cuota()
        {
            IdCuota = 0;
            Interes = 0;
            Capital = 0;
            Valor =  0;
            Balance = 0;
            CuotaNum = 0;
            IdPrestamo = 0;
        }
    }
}
