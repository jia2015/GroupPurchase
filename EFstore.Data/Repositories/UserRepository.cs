using EFstore.Data.Infrastructure;
using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EFstore.Data.Repositories
{
    public interface IUserRepository : IRepository<UserModel>
    {
        decimal GetUserFundAccountBalance(string userName);
        bool UpdateFundAccount(string userName, decimal balance);
    }

    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(IDatabaseFactory dbFactory)
            : base(dbFactory) { }

        public decimal GetUserFundAccountBalance(string userName)
        {
            var user = this.DbContext.Users.Include(t => t.FundAccount).Where(t => t.Username == userName).FirstOrDefault();

            return user.FundAccount.Balance;
        }

        public bool UpdateFundAccount(string userName, decimal balance)
        {
            try
            {
                UserModel user = this.DbContext.Users.Include(t => t.FundAccount).Where(t => t.Username == userName).FirstOrDefault();
                user.FundAccount.Balance = balance;
                //_userdbset.Attach(userfund);
                //_dataContext.Entry(userfund).State = EntityState.Modified;
                //_dataContext.SaveChanges();
                base.Update(user);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }

}
