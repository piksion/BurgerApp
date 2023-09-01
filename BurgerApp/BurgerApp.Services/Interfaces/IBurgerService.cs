using BurgerApp.ViewModels.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
	public interface IBurgerService
	{
		List<BurgerListViewModel> GetAllBurgers();
		void CreateOrder(CreateBurgerViewModel model);
		BurgerDetailsViewModel GetBurgerDetails(int id);
		List<BurgerDropDownViewModel> GetBurgerDropDowns();
		void DeleteOrder(int id);
	} 
}
