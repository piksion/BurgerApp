using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;
using BurgerApp.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers.Orders
{
	public static class OrderMapper
	{
		public static OrderListViewModel ToOrderListViewModel(this Order order)
		{
			var price = CalculateOrderPrice(order);
			return new OrderListViewModel
			{
				OrderId = order.Id,
				OrderName = order.FullName,
				IsDelivered = order.IsDelivered,
				Address = order.Address,
				Location = order.Location,
				TotalPrice = price,
				burgerOrders = order.BurgersOrders.ToList()
			};
		}

		public static Order AddOrder(this CreateOrderViewModel model)
		{
			return new Order
			{
				FullName = model.OrderName,
				Address = model.OrderAddress,
				IsDelivered = model.IsDelivered,
				BurgerId = model.BurgerId,
				Id = model.OrderId,
				Location = model.OrderLocation
			};
		}
		public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
		{
			var price = CalculateOrderPrice(order);
			return new OrderDetailsViewModel
			{
				OrderId = order.Id,
				OrderName = order.FullName,
				IsDelivered = order.IsDelivered,
				Address = order.Address,
				Location = order.Location,
				TotalPrice = price,
				burgerOrders = order.BurgersOrders
			};
		}
		private static int CalculateOrderPrice(Order order)
		{
			var price = 0;
			foreach(BurgerOrder burgerOrder in order.BurgersOrders)
			{
				price += burgerOrder.Burger.Price;
			}
			return price;
		}
	}
}
