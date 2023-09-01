using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Burgers;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Controllers
{
	public class BurgerController : Controller
	{
		private readonly IBurgerService _burgerService;
		private readonly IOrderService _orderService;

        public BurgerController()
        {
            _burgerService = new BurgerService();
			_orderService = new OrderService();
        }
        public IActionResult Index()
		{
			try
			{
				List<BurgerListViewModel> burgers = _burgerService.GetAllBurgers();
				return View(burgers);
			}
			catch
			(Exception ex)
			{
				return View(ex);
			}
		}
		public IActionResult Details(int id)
		{
			
			BurgerDetailsViewModel burgers = _burgerService.GetBurgerDetails(id);
			return View(burgers);
		}
	}
}
