using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.Burgers
{
	public class CreateBurgerViewModel
	{
		public int BurgerId { get; set; }
		[Display (Name ="Burger Name")]
		public string BurgerName { get; set; }
		[Display (Name = "Burger Price")]
		public int BurgerPrice { get; set; }
		[Display(Name = "Burger is Vegetarian")]
		public bool IsVegetarian { get; set; }
		[Display(Name = "Burger is Vegan")]
		public bool IsVegan { get; set; }
		[Display(Name = "Burger has fries")]
		public bool HasFries { get; set; }
	}
}
