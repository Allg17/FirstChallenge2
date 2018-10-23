using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PrestamoBLL : RepositorioBase<Prestamo>
    {
        public override bool Modificar(Prestamo entity)
        {
            _contexto = new DAL.Contexto();
            decimal montoBaseDatos = 0;
            decimal montoEntidad = 0;
            bool paso = false;
            try
            {
                //Busca el detalle anterior en base de datos
                var detalleAnterior = _contexto.Cuotas.Where(x => x.IdPrestamo == entity.IdPrestamo).AsNoTracking().ToList();

                //Agrega a la variable montoBaseDatos el monto del capital mas el interes
                foreach (var item in detalleAnterior)
                {
                    montoBaseDatos += item.Capital + item.Interes;
                }

                //Agrega a la variable montoEntidad el monto del capital mas el interes
                foreach (var item in entity.Detalle)
                {
                    montoEntidad += item.Capital + item.Interes;
                }

                _contexto.Cuenta.Find(entity.IdCuenta).Balance -= montoBaseDatos;
                _contexto.Cuenta.Find(entity.IdCuenta).Balance += montoEntidad;

                //Marca como borrado alguna cuota que este en base de datos y no en la lista detalle

                if (entity.Detalle.Count < detalleAnterior.Count)
                {
                    foreach (var item in detalleAnterior)
                    {
                        if (!entity.Detalle.Exists(x => x.IdCuota.Equals(item.IdCuota)))
                        {
                            _contexto.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                }

                //Modifica o agrega una nueva cuota 
                foreach (var item in entity.Detalle)
                {
                    _contexto.Entry(item).State = item.IdCuota == 0 ? EntityState.Added : EntityState.Modified;
                }

                //modifica la entidad
                _contexto.Entry(entity).State = EntityState.Modified;

                //Guarda
                paso = _contexto.SaveChanges() > 0 ? true : false;


            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public List<Cuota> CalcularCuotas(int meses, double Montocapital, double interes)
        {
            List<Cuota> cuota = new List<Cuota>();
            decimal intere = 0;
            decimal valor = Convert.ToDecimal((Montocapital * interes) / (1 - Math.Pow((1 + interes), -meses)));
            decimal capital = 0;
            decimal balance = 0;
            for (int i = 0; i < meses; i++)
            {
                if (i == 0)
                    intere = Convert.ToDecimal(interes * Montocapital);
                else
                    intere = balance * Convert.ToDecimal(interes);

                capital = valor - intere;
                if (i == 0)
                {
                    balance = Convert.ToDecimal(Montocapital) - capital;
                }
                else
                {
                    balance = balance - capital;
                }
                if (balance < 0)
                    balance = 0;
                cuota.Add(new Cuota(0, 0, i + 1, decimal.Round(intere, 2), decimal.Round(capital, 2), decimal.Round(valor, 2), decimal.Round(balance, 2)));

            }




            return cuota;
        }

        public List<Cuota> CalcularCuotasModificadas(List<Cuota> cuotas, int idprestamo, int meses, double Montocapital, double interes)
        {
            List<Cuota> cuota = new List<Cuota>();
            int inicio = cuotas.ElementAt(0).IdCuota, k = 0;
            decimal intere = 0;
            decimal valor = Convert.ToDecimal((Montocapital * interes) / (1 - Math.Pow((1 + interes), -meses)));
            decimal capital = 0;
            decimal balance = 0;
            for (int i = 0; i < meses; i++)
            {


                if (i == 0)
                    intere = Convert.ToDecimal(interes * Montocapital);
                else
                    intere = balance * Convert.ToDecimal(interes);

                capital = valor - intere;
                if (i == 0)
                {
                    balance = Convert.ToDecimal(Montocapital) - capital;
                }
                else
                {
                    balance = balance - capital;
                }
                if (balance < 0)
                    balance = 0;
                if (k == cuotas.Count)
                    cuota.Add(new Cuota(0, idprestamo, i + 1, decimal.Round(intere, 2), decimal.Round(capital, 2), decimal.Round(valor, 2), decimal.Round(balance, 2)));
                else
                    cuota.Add(new Cuota(inicio, idprestamo, i + 1, decimal.Round(intere, 2), decimal.Round(capital, 2), decimal.Round(valor, 2), decimal.Round(balance, 2)));
                inicio += 1; k += 1;
            }




            return cuota;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            decimal monto = 0;
            try
            {
                var prestamo = _contexto.Prestamos.Find(id);


                foreach (var item in prestamo.Detalle)
                {
                    monto += item.Capital + item.Interes;
                }
                _contexto.Cuenta.Find(prestamo.IdCuenta).Balance -= monto;

                _contexto.Prestamos.Remove(prestamo);
                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public override bool Guardar(Prestamo entity)
        {
            bool paso = false;
            decimal monto = 0;
            _contexto = new DAL.Contexto();
            try
            {
                foreach (var item in entity.Detalle)
                {
                    monto += item.Capital + item.Interes;
                }
                _contexto.Cuenta.Find(entity.IdCuenta).Balance += monto;
                _contexto.Prestamos.Add(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }



    }
}
