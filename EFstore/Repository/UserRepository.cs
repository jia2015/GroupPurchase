using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;
using System.Data.Entity;

namespace EFstore.Repository
{
    public interface IUserRepository
    {
        decimal GetUserFundAccountBalance(string userName);
        bool UpdateFundAccount(string userName, decimal balance);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseFactory _datafactory;

        private AccDbContext _dataContext;

        public UserRepository(IDatabaseFactory datafactory)
        {
            this._datafactory = datafactory;
            this._dataContext = datafactory.Get();
            _userdbset = DataContext.Set<UserModel>();
        }

        private readonly IDbSet<UserModel> _userdbset;
        protected IDbSet<UserModel> UserDbSet
        {
            get { return _userdbset; }
        }
        public decimal GetUserFundAccountBalance(string userName)
        {
            var user = UserDbSet.Include(t => t.FundAccount).Where(t => t.Username == userName).FirstOrDefault();
            //var user = UserDbSet.Where(t => t.Username == userName).FirstOrDefault();
            //var saving = UserDbSet.Include(t => t.FundAccount).Where(t => t.UserID == int.Parse(user.FundAccount.UserID)).FirstOrDefault();

            return user.FundAccount.Balance;
        }
        public bool UpdateFundAccount(string userName, decimal balance)
        {
            try
            {
                var userfund = _userdbset.Include(t => t.FundAccount).Where(t => t.Username == userName).FirstOrDefault();
                userfund.FundAccount.Balance = balance;
                _userdbset.Attach(userfund);
                _dataContext.Entry(userfund).State = EntityState.Modified;
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                
            }
            return false;
        }

        protected AccDbContext DataContext
        {
            get { return _dataContext; }
        }

        #region
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_dataContext == null) return;
            _dataContext.Dispose();
        }
        #endregion
    }
}