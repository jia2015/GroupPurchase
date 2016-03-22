using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory dbFactory;
        private AccDbContext dbContext;
 
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
 
        public AccDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
 
        public void Commit()
        {
            DbContext.Commit();
        }
    }

}
