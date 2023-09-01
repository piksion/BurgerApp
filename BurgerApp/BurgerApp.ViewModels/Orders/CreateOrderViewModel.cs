using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.ViewModels.Orders
{
	public class CreateOrderViewModel
	{
		[Display (Name = "Burger")]
		public int BurgerId { get; set; }
		public int OrderId { get; set; }
		[Display (Name = "Order name")]
		public string OrderName { get; set; }
		[Display (Name = "Address")]
		public string OrderAddress { get; set; }
		[Display(Name = "Location")]
		public string OrderLocation { get; set; }
		[Display(Name = "Is Delivered")]
		public bool IsDelivered { get; set; }
		

	}
}
