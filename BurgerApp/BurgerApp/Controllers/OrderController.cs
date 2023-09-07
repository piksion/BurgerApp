using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
	public class OrderController : Controller
	{
		private IOrderService _orderService;
        private IBurgerService _burgerService;

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
        public IActionResult CreateOrder()
        {
            CreateOrderViewModel orderViewModel = new CreateOrderViewModel();
            ViewBag.Orders = _burgerService.GetBurgerDropDowns();

            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult CreateBurgerPost(CreateOrderViewModel orderViewModel)
        {
            _orderService.CreateOrder(orderViewModel);
            return RedirectToAction("Index");   
        }

        public IActionResult MakeOrder(int id)
        {
            AddBurgerViewModel orderViewModel = new AddBurgerViewModel();
            orderViewModel.OrderId = id;

            ViewBag.Burgers = _burgerService.GetBurgerDropDowns();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult MakeOrderPost(AddBurgerViewModel orderViewModel)
        {
            _orderService.AddBurgerToOrder(orderViewModel);
            return RedirectToAction("Index", new { id = orderViewModel.OrderId });  
        }
    }
}
