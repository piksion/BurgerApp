using BurgerApp.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services.Interfaces
{
	public interface IOrderService
	{
		List<OrderListViewModel> GetAllOrders();
		void CreateOrder(CreateOrderViewModel model);
		OrderDetailsViewModel GetOrderDetails(int id);
		void DeleteOrder(int id);	
		void AddBurgerToOrder(AddBurgerViewModel model);
	}
}
