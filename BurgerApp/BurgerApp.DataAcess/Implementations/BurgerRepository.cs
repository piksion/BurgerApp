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
		public void Delete(int id)
		{
			Burger burgerDb = StaticDb.Burgers.FirstOrDefault(b => b.Id == id);
			if (burgerDb == null)
			{
				throw new Exception($"Burger with id {id} does not exist!");

			}
			StaticDb.Burgers.Remove(burgerDb);
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
			entity.Id = ++StaticDb.BurgerId;
			StaticDb.Burgers.Add(entity);
		}

		public void Update(Burger entity)
		{
			Burger burgerDb = StaticDb.Burgers.FirstOrDefault(x=>x.Id == entity.Id);
			int index = StaticDb.Burgers.IndexOf(entity);
			StaticDb.Burgers[index] = entity;
		}
	}
}
