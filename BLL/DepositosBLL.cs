using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DepositosBLL : RepositorioBase<Deposito>
    {
        public override bool Guardar(Deposito entity)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                _contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Monto;
                _contexto.Depositos.Add(entity);
                if (_contexto.SaveChanges() > 0)
                    paso = true;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;
            _contexto = new DAL.Contexto();

            try
            {
                var Deposito = _contexto.Depositos.Find(id);
                _contexto.Cuenta.Find(Deposito.CuentaId).Balance -= Deposito.Monto;
                _contexto.Entry(Deposito).State = System.Data.Entity.EntityState.Deleted;
                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }


        public override bool Modificar(Deposito entity)
        {
            var BaseDatos = base.Buscar(entity.DepositoId);
            bool paso = false;
            _contexto = new DAL.Contexto();
            try
            {
                
                _contexto.Cuenta.Find(entity.CuentaId).Balance -= BaseDatos.Monto;
                _contexto.Cuenta.Find(entity.CuentaId).Balance += entity.Monto;

                _contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
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
