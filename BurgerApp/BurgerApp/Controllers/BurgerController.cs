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
		public IActionResult Delete(int id)
		{
			if(id <= 0)
			{
				throw new Exception("Id must not be negative!");
			}
			try
			{
				BurgerDetailsViewModel burgerDetailsViewModel = _burgerService.GetBurgerDetails(id);
				_burgerService.DeleteOrder(id);
				return View(burgerDetailsViewModel);
			}
			catch(Exception ex)
			{
				return View(ex);
			}
		}

		public IActionResult CreateBurger()
		{
			CreateBurgerViewModel createBurgerViewModel = new CreateBurgerViewModel();

			ViewBag.Burgers = _burgerService.GetBurgerDropDowns();

			return View(createBurgerViewModel);
		}
		[HttpPost]
		public IActionResult CreateBurgerPost(CreateBurgerViewModel model)
		{
				_burgerService.CreateBurger(model);
				return RedirectToAction("Index");
		}
	}
}
