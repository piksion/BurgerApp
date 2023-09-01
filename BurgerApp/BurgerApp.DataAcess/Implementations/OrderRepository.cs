using BurgerApp.DataAcess.Interfaces;
using BurgerApp.Domain.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAcess.Implementations
{
	public class OrderRepository : IRepository<Order>
	{
		public void Delete(int id)
		{
			Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
			if (orderDb == null) 
			{
				throw new Exception($"Order with id {id} does not exist!");
			}
			StaticDb.Orders.Remove(orderDb);
		}

		public List<Order> GetAll()
		{
			return StaticDb.Orders;
		}

		public Order GetById(int id)
		{
			return StaticDb.Orders.FirstOrDefault(x => x.Id == id);
		}

		public void Insert(Order entity)
		{
			entity.Id = ++StaticDb.OrderId;
			StaticDb.Orders.Add(entity);
		}

		public void Update(Order entity)
		{
			Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == entity.Id);
			int index = StaticDb.Orders.IndexOf(entity);
			StaticDb.Orders[index] = entity;
		}
	}
}
