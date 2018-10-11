using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class RepositorioBase<T> :IDisposable, IRepository<T> where T:class
    {
        internal  Contexto _contexto;

        public RepositorioBase()
        {
            _contexto = new Contexto();
        }

        /// <summary>
        /// Permite guardar una entidad en la base de datos
        /// </summary>
        /// <param name="entity">Una instancia de la entidad a guardar</param>
        /// <returns>Retorna True si guardo o Falso si falló </returns>
        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            _contexto = new Contexto();
            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                {
                    _contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            } 
            return paso;
        }

        /// <summary>
        /// Permite Modificar una entidad en la base de datos 
        /// </summary>
        /// <param name="entity">Una instancia de la entidad a guardar</param>
        /// <returns>Retorna True si Modifico o Falso si falló </returns>
        public virtual bool Modificar(T entity)
        {
            _contexto = new Contexto();
            bool paso = false; 
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                if (_contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;        }

        /// <summary>
        /// Permite Eliminar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la entidad que se desea eliminar </param>
        /// <returns>Retorna True si Eliminó o Falso si falló </returns>
        public virtual bool Eliminar(int id)
        {
            _contexto = new Contexto();
            bool paso = false;             
            try {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);

                if (_contexto.SaveChanges() > 0)
                    paso = true;

                _contexto.Dispose();
            }
            catch (Exception)
            {   throw; }
            return paso;        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos
        /// </summary>
        ///<param name="id">El Id de la entidad que se desea encontrar </param>
        /// <returns>Retorna la persona encontrada </returns>
        public virtual T Buscar(int id)
        {
            _contexto = new Contexto();
            T entity  ;
            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entity;        }

        /// <summary>
        /// Permite extraer una lista de Personas de la base de datos
        /// </summary> 
        ///<param name="expression">Expression Lambda conteniendo los filtros de busqueda </param>
        ///// <returns>Retorna una lista de entidades</returns>
        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            _contexto = new Contexto();
            List<T> Lista = new List<T>(); 
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
