using BurgerApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAcess.Interfaces
{
	public interface IRepository<T> where T : BaseEntity 
	{
		List<T> GetAll();
		T GetById(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
