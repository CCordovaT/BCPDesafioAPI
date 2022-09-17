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
        protected readonly string connectionString;

        public BaseRepositoryImp()
        {
            connectionString = ConfigurationManager.ConnectionStrings["BcpVentasConexion"].ConnectionString;
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
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
            throw new NotImplementedException();
        }

        public T GetByKey(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
