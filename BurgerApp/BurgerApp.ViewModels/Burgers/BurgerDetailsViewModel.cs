using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.Burgers
{
	public class BurgerDetailsViewModel
	{
		public int BurgerId { get; set; }
		public string BurgerName { get; set; }
		public int BurgerPrice { get; set; }
		public bool IsVegetarian { get; set; }
		public bool IsVegan { get; set; }
		public bool HasFries { get; set; }
	}
}
