using BurgerApp.DataAcess.Implementations;
using BurgerApp.DataAcess.Interfaces;
using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;
using BurgerApp.Mappers.Orders;
using BurgerApp.Services.Interfaces;
using BurgerApp.ViewModels.Orders;

namespace BurgerApp.Services.Implementations
{
	public class OrderService : IOrderService
	{

		private IRepository<Order> _orderRepository;
		private IRepository<Burger> _burgerRepository;

        public OrderService()
        {
			_orderRepository = new OrderRepository();
			_burgerRepository = new BurgerRepository();
		}
		public void AddOrder(CreateOrderViewModel model)
		{
			Order orderDb = model.AddOrder();
			_orderRepository.Insert(orderDb);

		}

		public void DeleteOrder(int id)
		{
			_orderRepository.Delete(id);
		}

		public List<OrderListViewModel> GetAllOrders()
		{
			List<Order> ordersDb = _orderRepository.GetAll();
			List<OrderListViewModel> orderListViewModels = ordersDb.Select(x => x.ToOrderListViewModel()).ToList();
			return orderListViewModels;
		}

		public OrderDetailsViewModel GetOrderDetails(int id)
		{
			Order orderdb = _orderRepository.GetById(id);
			if(orderdb == null)
			{
				throw new Exception($"Order with id {id} was not found!");
			}
			OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderdb);
			return orderDetailsViewModel;
		}

		public void MakeOrder(CreateOrderViewModel model)
		{
			Burger burgerDb = _burgerRepository.GetById(model.BurgerId);
			if(model.BurgerId == null)
			{
				throw new Exception("Burger doesn't exist");
			}
			Order orderDb = _orderRepository.GetById(model.OrderId);
			if(model.OrderId == null)
			{
				throw new Exception("Order doesn't exist");
			}
			orderDb.BurgersOrders.Add(new BurgerOrder
			{
				OrderId = model.OrderId,
				BurgerId = model.BurgerId,
				Orders = orderDb,
				Burger = burgerDb
			});
		}
	}
}
