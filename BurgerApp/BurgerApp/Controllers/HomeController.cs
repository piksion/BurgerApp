using BurgerApp.Models;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Home;
using BurgerApp.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BurgerApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IOrderService _orderService;
		private readonly IBurgerService _burgerService;

		public HomeController(ILogger<HomeController> logger, IOrderService orderService, IBurgerService burgerService)
		{
			_logger = logger;
			_orderService = orderService;
			_burgerService = burgerService;
		}

		public IActionResult Index()
		{
			List<OrderListViewModel> orderDb = _orderService.GetAllOrders();
			if(orderDb.Count == 0)
			{
				return RedirectToAction("Error");	
			}

			int totalPrice = orderDb.Sum(x => x.TotalPrice);
			int averagePrice = totalPrice / orderDb.Count;

			int totalOrders = _orderService.GetAllOrders().Count;

			List<string> locations = orderDb
				.Select(x => x.Location)
				.Distinct()
				.ToList();

			HomeViewModel homeViewModel = new HomeViewModel
			{
				NumberOfOrders = totalOrders,
				MostPopularBurger = _burgerService.MostPopularBurger(),
				AveragePrice = averagePrice,
				Locations = locations
			};
			return View(homeViewModel);

		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}