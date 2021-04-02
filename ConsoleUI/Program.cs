using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			CarTest();
			//ColorName();
		}


		private static void ColorName()
		{
			ColorManager colorManager = new ColorManager(new EfColorDal());
			foreach (var color in colorManager.GetAll())
			{
				Console.WriteLine(color.ColorName);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());

			var result = carManager.GetCarDetails();
			if (result.Success)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.CarName + "/" + car.BrandName);
				}

			}
			else
			{
				Console.WriteLine(result.Message);
			}

			
		}
	}
}
