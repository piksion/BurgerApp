using BurgerApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Burgers
{
	public class BurgerOrder : BaseEntity
	{
		public int BurgerId { get; set; }
		public Burger Burger { get; set; }
		public int OrderId { get; set; }
		public Order Orders { get; set; }
	}
}
