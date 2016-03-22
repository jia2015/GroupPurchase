using EFstore.Data.Infrastructure;
using EFstore.Data.Repositories;
using EFstore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFstore.Services
{
    public interface IOrderDetailService
    {
        ValidationResult UserPayment(string userName, string[] orderDetailsIds);
        void SaveOrderDetail();
    }

    public class OrderDetailService : IOrderDetailService
    {
        private IUserRepository _userRepository;
        private IOrderDetailRepository _odRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUserRepository userRepository, IOrderDetailRepository odRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._odRepository = odRepository;
            this._unitOfWork = unitOfWork;
            
        }

        public ValidationResult UserPayment(string userName, string[] orderDetailsIds)
        {
            var result = new ValidationResult();
            var userBlance = _userRepository.GetUserFundAccountBalance(userName);
            var orderDetails = _odRepository.GetOrderDetailByIds(orderDetailsIds);
            var total = orderDetails.Select(t => t.UnitPrice).Sum();
            if (userBlance < total)
            {
                result.IsValid = false;
                result.Message = "对不起，账户余额不足，无法完成购买";
                return result;
            }
            _userRepository.UpdateFundAccount(userName, userBlance - total);
            //设定交易完成
            orderDetails.ForEach(t => t.IsClosed = false);
            _odRepository.UpdateOrderDetails(orderDetails);
            result.IsValid = true;
            result.Message = "付款完成！";
            return result;
        }

        public void SaveOrderDetail()
        {
            _unitOfWork.Commit();
        }


    }
}
