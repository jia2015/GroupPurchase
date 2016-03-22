using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Data.Infrastructure
{
    public interface IDatabaseFactory
    {
        AccDbContext Init();
    }

    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AccDbContext dbContext;

        public AccDbContext Init()
        {
            return dbContext ?? (dbContext = new AccDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
