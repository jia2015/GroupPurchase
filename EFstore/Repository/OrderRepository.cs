using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;
using System.Data.Entity;

namespace EFstore.Repository
{
    public interface IOrderDetailRepository
    {
        List<OrderDetailModel> GetOrderDetailByIds(string[] ids);

        void UpdateOrderDetails(List<OrderDetailModel> orderDetails);
    }

    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly IDatabaseFactory _datafactory;
        private readonly AccDbContext _dataContext;

        public OrderDetailRepository(IDatabaseFactory datafactory)
        {
            this._datafactory = datafactory;
            this._dataContext = datafactory.Get();
            _orderdetaildbset = DataContext.Set<OrderDetailModel>();
        }

        private readonly IDbSet<OrderDetailModel> _orderdetaildbset;
        protected IDbSet<OrderDetailModel> OrderDetailDbSet
        {
            get { return _orderdetaildbset; }
        }
        public List<OrderDetailModel> GetOrderDetailByIds(string[] ids)
        {
            var orderDetails = OrderDetailDbSet.Include(t => t.Order).Where(t => ids.Contains<string>(t.OrderID)).ToList();
            return orderDetails;
        }
        public void UpdateOrderDetails(List<OrderDetailModel> orderDetails)
        {
            orderDetails.ForEach(t =>
            {
                _orderdetaildbset.Attach(t);
                DataContext.Entry(t).State = EntityState.Modified;
            }
            );
            DataContext.SaveChanges();
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