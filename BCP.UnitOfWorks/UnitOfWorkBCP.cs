using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCP.Models;
using BCP.Repositories;

namespace BCP.UnitOfWorks
{
    public class UnitOfWorkBCP : UnitOfWork
    {
        public BaseRepository<Agencia> Agencias => new BaseRepositoryImp<Agencia>();
    }
}
