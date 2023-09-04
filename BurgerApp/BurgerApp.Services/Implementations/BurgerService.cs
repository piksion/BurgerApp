using BurgerApp.DataAcess;
using BurgerApp.DataAcess.Implementations;
using BurgerApp.DataAcess.Interfaces;
using BurgerApp.Domain.Burgers;
using BurgerApp.Mappers.Burgers;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Implementations
{
	public class BurgerService : IBurgerService
	{
		private IRepository<Burger> _burgerRepository;
        public BurgerService()
        {
            _burgerRepository = new BurgerRepository();
        }

        public void CreateBurger(CreateBurgerViewModel model)
		{
			Burger burgerDb = model.CreateBurger();
			_burgerRepository.Insert(burgerDb);
		}

		public List<BurgerListViewModel> GetAllBurgers()
		{
			List<Burger> burgerDb = _burgerRepository.GetAll();
			List<BurgerListViewModel> burgerListViewModels = burgerDb.Select(x => x.ToBurgerListViewModel()).ToList();
			return burgerListViewModels;
		}
		public BurgerDetailsViewModel GetBurgerDetails(int id)
		{
			if(id <= 0)
			{
				throw new Exception($"Burger with id {id} was not found!");
			}

			Burger burgerDb = _burgerRepository.GetById(id);
			if (burgerDb == null)
			{
				throw new Exception($"Burger with id {id} was not found!");
			}
			BurgerDetailsViewModel burgerDetailsViewModel = BurgerMapper.ToBurgerDetailsViewModel(burgerDb);
		    return burgerDetailsViewModel;
		}

		public List<BurgerDropDownViewModel> GetBurgerDropDowns()
		{
			List<Burger> burgerDb = _burgerRepository.GetAll();
			List<BurgerDropDownViewModel> burgerDropDownViewModels = burgerDb.Select(x => x.ToBurgerDropDown()).ToList();
			return burgerDropDownViewModels;
		}
		public void DeleteOrder(int id)
		{
			_burgerRepository.Delete(id);
		}
		public List<string> MostPopularBurger()
		{
			var burgers = StaticDb.Orders
				.SelectMany(order => order.BurgersOrders)
				.GroupBy(burgers => burgers.BurgerId)
				.OrderByDescending(group => group.Count())
				.FirstOrDefault();

			if(burgers == null)
			{
				return new List<string> ();
			}

			var mostPopularBurger = burgers
				.Select(burgers => burgers.Burger.Name)
				.ToList();
			return mostPopularBurger;
		}

	}
}
