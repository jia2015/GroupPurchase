using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFstore.Models;
using System.Net;
using EFstore.Services;
using EFstore.ViewModels;
using System.Data.Entity;
using EFstore.Controllers;
using EFstore.Repository;

namespace EFstore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderDetailService _service;

        public OrderController(IOrderDetailService service)
        {
            this._service = service;
        }

        private AccDbContext db = new AccDbContext();

        // GET: /Order/
        public ActionResult Index()
        {
            var user = db.Users.Where(t => t.Username == User.Identity.Name).Single();
            var userorders = user.Orders;
            var userorderdetails = userorders.Select(t => t.OrderDetails).ToList();
            var orders = db.Orders.Where(o => o.UserID == user.UserID.ToString()).ToList();
            foreach (var o in orders)
            {
                db.Entry(o).Collection(t => t.OrderDetails).Load();
                var ods = o.OrderDetails;
            }
            var count = orders.Select(t => t.OrderDetails).Count();
            return View(orders);
        }

        public JsonResult Payment(string[] chkOrderDetailIDs)
        {
            var result = _service.UserPayment(User.Identity.Name, chkOrderDetailIDs);
            //可以根据操作结果成功与否的返回值：即result.IsValid，做一些视图逻辑。这里省略。
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: /Order/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Order order = db.Orders.Include(t => t.OrderDetails).Where(t => t.ID == id).FirstOrDefault();
            var orderDetails = db.OrderDetails.Where(t => t.OrderID == id).ToList();
            List<OrderDetailVM> models = new List<OrderDetailVM>();

            foreach (var d in orderDetails)
            {
                models.Add(
                    new OrderDetailVM
                    {
                        ActivityName = db.Activities.Find(int.Parse(d.ActivityId)).ProductTitle,
                        UnitPrice = d.UnitPrice,
                        OrderDetailID = d.OrderID
                    });
            }
            return View(models);
        }

        public ActionResult UpdateCart()
        {
            var userName = User.Identity.Name;
            var order = db.Orders.Include(t => t.OrderDetails).Where(o => o.Username == userName).FirstOrDefault();
            var count = order == null ? 0 : order.OrderDetails.Count();

            return PartialView("CartPartialView", count);
        }

        public ActionResult Create(int activityId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            string actId = activityId.ToString();
            var activity = db.Activities.Find(activityId);
            if (activity == null)
                return PartialView();

            var userName = User.Identity.Name;
            var orders = db.Orders.Include(o => o.OrderDetails);

            var order = orders.Where(t => (t.IsFinished == false && t.Username == User.Identity.Name)).FirstOrDefault();

            if (order != null && !order.IsValid(actId))
            {
                ModelState.AddModelError("", "同一活动只能参加一次。");
                //应该弹窗说明错误。
                return PartialView(order.OrderDetails.Count);
            }

            if (order == null)
            {
                order = new OrderModel();
                order.Username = userName;
                order.User = db.Users.Where(t => t.Username == User.Identity.Name).FirstOrDefault();
                order.UserID = order.User.UserID.ToString();
                order.DateCreated = DateTime.Now;
                order.IsFinished = false;

                db.Orders.Add(order);
            }

            var orderDetail = new OrderDetailModel { Order = order, OrderID = order.OrderID.ToString(), UnitPrice = activity.Price, ActivityId = actId };

            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();

            return PartialView(order.OrderDetails.Count);
        }

        // GET: /Order/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderModel order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: /Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            OrderModel order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}