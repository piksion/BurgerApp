using BurgerApp.Domain.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Orders
{
	public class Order : BaseEntity
	{
		public string FullName { get; set; }
		public string Address { get; set; }
		public bool IsDelivered { get; set; }
		public int BurgerId { get; set; }
		public Burger Burger { get; set; }
		public string Location { get; set; }

		public List<BurgerOrder> BurgersOrders { get; set; }
		public Order() 
		{
			BurgersOrders = new List<BurgerOrder>();
		}
	
	}
}
