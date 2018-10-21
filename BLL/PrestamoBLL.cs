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
            bool paso = false;
            try
            {
                var detalleAnterior = _contexto.Cuotas.Where(x => x.IdPrestamo == entity.IdPrestamo).AsNoTracking().ToList();
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

                foreach (var item in entity.Detalle)
                {
                    _contexto.Entry(item).State = item.IdCuota == 0 ? EntityState.Added : EntityState.Modified;
                }

                _contexto.Entry(entity).State = EntityState.Modified;
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
            try
            {
                var detalle = _contexto.Prestamos.Find(id).Detalle.Where(x => x.IdPrestamo == id);
                foreach (var item in detalle)
                {
                    int a = item.CuotaNum;

                }
                _contexto.Prestamos.Remove(_contexto.Prestamos.Find(id));
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
