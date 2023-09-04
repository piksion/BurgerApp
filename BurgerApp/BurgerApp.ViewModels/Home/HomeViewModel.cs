using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.Home
{
	public class HomeViewModel
	{
		public List<string> MostPopularBurger { get; set; }
		public int NumberOfOrders { get; set; }
		public int AveragePrice { get; set; }
		public List<string> Locations { get; set; }

	}
}
