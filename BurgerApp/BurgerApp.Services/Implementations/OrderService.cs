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

		public void CreateOrder(CreateOrderViewModel model)
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

        public void AddBurgerToOrder(AddBurgerViewModel model)
        {
            Burger burgerDb = _burgerRepository.GetById(model.BurgerId);
            if (model.BurgerId == null)
            {
                throw new Exception("Burger doest exists");
            }
            Order orderDb = _orderRepository.GetById(model.OrderId);
            if (orderDb == null)
            {
                throw new Exception("Order not found");
            }
            orderDb.BurgersOrders.Add(new BurgerOrder
            {
                OrderId = model.OrderId,
                Burger = burgerDb,
                Orders = orderDb,
                BurgerId = model.BurgerId,
            });

            _orderRepository.Update(orderDb);
        }

    }
}
