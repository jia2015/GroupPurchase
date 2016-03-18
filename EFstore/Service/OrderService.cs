using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFstore.Models;
using EFstore.Repository;
using System.Diagnostics;

namespace EFstore.Service
{
    public interface IOrderDetailService
    {
        ValidationResult UserPayment(string userName, string[] orderDetailsIds);
    }

    public class OrderDetailService : IOrderDetailService
    {
        private IUserRepository _userRepository;
        private IOrderDetailRepository _odRepository;
        public OrderDetailService(IUserRepository UserRepository, IOrderDetailRepository OrderRepository)
        {
            _userRepository = UserRepository;
            _odRepository = OrderRepository;
        }
        public ValidationResult UserPayment(string userName, string[] orderDetailsIds)
        {
            var result = new ValidationResult();
            var userBalance = _userRepository.GetUserFundAccountBalance(userName);
            var orderDetails = _odRepository.GetOrderDetailByIds(orderDetailsIds);
            var total = orderDetails.Select(t => t.UnitPrice).Sum();
            if (userBalance < total)
            {
                result.IsValid = false;
                result.Message = "对不起，账户余额不足，无法完成购买";
                return result;
            }
            _userRepository.UpdateFundAccount(userName, userBalance - total);
            //设定交易完成
            orderDetails.ForEach(t => t.IsClosed = false);
            _odRepository.UpdateOrderDetails(orderDetails);
            result.IsValid = true;
            result.Message = "付款完成！";
            return result;
        }
    }
}