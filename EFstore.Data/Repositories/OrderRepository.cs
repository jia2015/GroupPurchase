using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFstore.Entities;
using EFstore.Data.Infrastructure;
using System.Data.Entity;

namespace EFstore.Data.Repositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetailModel>
    {
        List<OrderDetailModel> GetOrderDetailByIds(string[] ids);

        void UpdateOrderDetails(List<OrderDetailModel> orderDetails);
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetailModel>, IOrderDetailRepository
    {

        public OrderDetailRepository(IDatabaseFactory dbFactory)
            : base(dbFactory) { }

        public List<OrderDetailModel> GetOrderDetailByIds(string[] ids)
        {
            var orderDetails = this.DbContext.OrderDetails.Include(t => t.Order).Where(t => ids.Contains<string>(t.OrderID)).ToList();
            return orderDetails;
        }
        public void UpdateOrderDetails(List<OrderDetailModel> orderDetails)
        {
            orderDetails.ForEach(t =>
            {
                //this.DbContext.OrderDetails.Attach(t);
                //DataContext.Entry(t).State = EntityState.Modified;
                base.Update(t);
            }
            );
            //DataContext.SaveChanges();
        }

    }

}
