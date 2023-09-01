using BurgerApp.DataAcess.Interfaces;
using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAcess.Implementations
{
	public class BurgerRepository : IRepository<Burger>	
	{
		private IRepository<Burger> _burgerRepository;
		private IRepository<Order> _orderRepository;
		public void Delete(int id)
		{
			_burgerRepository.Delete(id);
		}

		public List<Burger> GetAll()
		{
			return StaticDb.Burgers;
		}

		public Burger GetById(int id)
		{
			return StaticDb.Burgers.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(Burger entity)
		{
			throw new NotImplementedException();
		}

		public void Update(Burger entity)
		{
			throw new NotImplementedException();
		}
	}
}
