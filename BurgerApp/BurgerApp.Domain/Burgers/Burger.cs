using BurgerApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Domain.Burgers
{
	public class Burger : BaseEntity
	{
		public string Name { get; set; }
		public int Price { get; set; }
		public bool IsVegetarian { get; set; }
		public bool IsVegan { get; set; }
		public bool HasFries { get; set; }
		public Order Order { get; set; }

		public List<BurgerOrder> BurgerOrders { get; set; }
        public Burger()
        {
            BurgerOrders  = new List<BurgerOrder>();
        }
    }
}
