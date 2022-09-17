using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public class BaseRepositoryImp<T> : BaseRepository<T> where T : class
    {
        protected readonly string connectionSqlLiteBCP;

        public BaseRepositoryImp()
        {
            connectionSqlLiteBCP = ConfigurationManager.ConnectionStrings["BcpVentasConexion"].ConnectionString;
        }

        public bool Delete(T entity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Delete(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<T> GetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.GetList<T>().ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetByCompoundKey(object compoundKey)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Get<T>(compoundKey);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetByKey(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Get<T>(id);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return (int)connection.Insert(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionSqlLiteBCP))
                {
                    return connection.Update<T>(entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
