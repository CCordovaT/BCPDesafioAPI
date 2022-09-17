using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Repositories
{
    public interface BaseRepository<T> where T : class
    {
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetByKey(int id);
        T GetByCompoundKey(Object compoundKey);
        List<T> GetAll();
    }
}
