using BurgerApp.Domain.Burgers;
using BurgerApp.Domain.Orders;
using BurgerApp.ViewModels.Burgers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers.Burgers
{
	public static class BurgerMapper
	{
		public static BurgerListViewModel ToBurgerListViewModel(this Burger burger)
		{
			return new BurgerListViewModel
			{
				BurgerId = burger.Id,
				BurgerName = burger.Name,
				BurgerPrice = burger.Price,	
				IsVegetarian = burger.IsVegetarian,
				IsVegan = burger.IsVegan,
				HasFries = burger.HasFries,
			};
		}
		public static Burger CreateBurger(this CreateBurgerViewModel model)
		{
			return new Burger
			{
				Name = model.BurgerName,
				Price = model.BurgerPrice,
				Id = model.BurgerId,
				IsVegetarian = model.IsVegetarian,
				IsVegan = model.IsVegan,
				HasFries = model.HasFries,
			};
		}
		public static BurgerDetailsViewModel ToBurgerDetailsViewModel(Burger burger)
		{
			return new BurgerDetailsViewModel
			{
				BurgerId = burger.Id,
				BurgerName = burger.Name,
				BurgerPrice = burger.Price,
				IsVegetarian = burger.IsVegetarian,
				IsVegan = burger.IsVegan,
				HasFries = burger.HasFries
			};
		}
		public static BurgerDropDownViewModel ToBurgerDropDown(this Burger burger)
		{
			return new BurgerDropDownViewModel
			{
				Id = burger.Id,
				Name = burger.Name,
			};
		}
	}

	
}
