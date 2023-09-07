using BurgerApp.DataAcess.Implementations;
using BurgerApp.DataAcess.Interfaces;
using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;
using BurgerApp.Services.Implementations;
using BurgerApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Helpers
{
	public static class DependencyInjectionHelper
	{
		public static void InjectRepositories(this IServiceCollection services)
		{
			services.AddTransient<IRepository<Order>, OrderRepository>();
			services.AddTransient<IRepository<Burger>, BurgerRepository>();
		}

		public static void InjectServices( IServiceCollection services) 
		{
			services.AddTransient<IOrderService, OrderService>();
			services.AddTransient<IBurgerService, BurgerService>();

		}
	}
}
