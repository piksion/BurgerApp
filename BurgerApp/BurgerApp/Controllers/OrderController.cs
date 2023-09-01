using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
	public class OrderController : Controller
	{
		private IOrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService();
        }

        public IActionResult Index()
        {
            try
            {
                List<OrderListViewModel> orders = _orderService.GetAllOrders();
                return View(orders);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public IActionResult Details(int id) 
        {
            OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
            return View(orderDetailsViewModel);
        }
        public IActionResult Delete(int id) 
        {
            if(id == null) 
            {
                throw new Exception("You must enter an id!");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id);
                _orderService.DeleteOrder(id);
                return View(orderDetailsViewModel);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
