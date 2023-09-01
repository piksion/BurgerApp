using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAcess
{
	public static class StaticDb
	{
		public static int BurgerId { get; set; }
		public static int OrderId { get; set; }
		public static List<Burger> Burgers { get; set; }
		public static List<Order> Orders { get; set; }

		static StaticDb()
		{
			BurgerId = 4;
			OrderId = 2;
			Burgers = new List<Burger>()
			{
				new Burger
				{
					Id = 1,
					Name = "Big Mac",
					Price = 250,
					IsVegetarian = false,
					IsVegan = false,
					HasFries = true,
					BurgerOrders = new List<BurgerOrder>
					{
					
					}
				},
				new Burger
				{
					Id = 2,
					Name = "McDouble",
					Price = 450,
					IsVegetarian = false,
					IsVegan = false,
					HasFries = true,
					BurgerOrders = new List<BurgerOrder>
					{
		
					}
				},
				new Burger
				{
					Id = 3,
					Name = "Cheeseburger",
					Price = 300,
					IsVegetarian = false,
					IsVegan = false,
					HasFries = true,
					BurgerOrders = new List<BurgerOrder> 
					{ 
					
					}
				},
				new Burger
				{
					Id = 4,
					Name = "Veggie Burger",
					Price = 400,
					IsVegetarian = true,
					IsVegan = true,
					HasFries = false,
					BurgerOrders = new List<BurgerOrder>
					{
						
					}
				}
			};
			Orders = new List<Order>()
			{
				new Order
				{
					Id = 1,
					FullName = "Petar Bozinoski",
					Address = "Some address 65",
					IsDelivered = false,
					Location = "Kicevo",
					BurgersOrders = new List<BurgerOrder>
					{
						new BurgerOrder
						{
							Id = 1,
							Burger = Burgers[0],
							OrderId = 1,
							BurgerId = Burgers[0].Id
						},
						new BurgerOrder
						{
							Id = 2,
							Burger = Burgers[1],
							OrderId = 2,
							BurgerId = Burgers[1].Id
						},
						new BurgerOrder
						{
							Id = 3,
							Burger = Burgers[2],
							OrderId = 3,
							BurgerId = Burgers[2].Id
						}
					},
					Burger = Burgers[1]
				},
				new Order
				{
					Id = 2,
					FullName = "Jovana Bozinoska",
					Address = "Some other address 66",
					IsDelivered = true,
					Location = "Skopje",
					BurgersOrders = new List<BurgerOrder>
					{
						new BurgerOrder
						{
							Id = 2,
							Burger = Burgers[4],
							OrderId = 2,
							BurgerId = Burgers[4].Id
						},
						new BurgerOrder
						{
							Id = 1,
							Burger = Burgers[3],
							OrderId = 1,
							BurgerId = Burgers[3].Id
						}
					},
					Burger = Burgers[2]

				},
				new Order
				{
					Id = 3,
					FullName = "Food Dude",
					Address = "Some other address 23",
					IsDelivered = true,
					Location = "Kratovo",
					BurgersOrders = new List<BurgerOrder>
					{
						new BurgerOrder
						{
							Id = 3,
							Burger = Burgers[4],
							OrderId = 2,
							BurgerId = Burgers[4].Id
						},
						new BurgerOrder
						{
							Id = 1,
							Burger = Burgers[3],
							OrderId = 1,
							BurgerId = Burgers[3].Id
						}
					},
					Burger = Burgers[2]

				}
			};
		}
	}
}
