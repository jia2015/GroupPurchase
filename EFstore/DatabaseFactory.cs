
using EFstore.Models;

namespace EFstore
{
    public interface IDatabaseFactory
    {
        AccDbContext Get();
    }
    public class DatabaseFactory : IDatabaseFactory
    {
        private AccDbContext dataContext;
        public AccDbContext Get()
        {
            return dataContext ?? (dataContext = new AccDbContext());
        }

    }
}