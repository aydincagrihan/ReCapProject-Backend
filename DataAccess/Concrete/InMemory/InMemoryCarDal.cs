using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		private List<Car> _cars;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car{CarId = 1,BrandId = 1,ColorId = 1,ModelYear = 2010,DailyPrice = 1000,Description = "Golf GTI"},
				new Car{CarId = 2,BrandId = 2,ColorId = 1,ModelYear = 2011,DailyPrice = 2000,Description = "Mercedes SClass"},
				new Car{CarId = 3,BrandId = 3,ColorId = 2,ModelYear = 2020,DailyPrice = 14444,Description = "BMW 429"},
				new Car{CarId = 4,BrandId = 4,ColorId = 2,ModelYear = 2019,DailyPrice = 123123,Description = "Mercedes Maybach"},
				new Car{CarId = 5,BrandId = 5,ColorId = 3,ModelYear = 2003,DailyPrice = 999,Description = "TOROS"}
			};
		}

		public List<Car> GetByCarId(int carId)
		{
			return _cars.Where(c => c.CarId == carId).ToList();
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(carToDelete);

		}

		public List<Car> GetAll()
		{
			return _cars;
		}

	

		public void Update(Car car)
		{
			Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.ModelYear = car.ModelYear;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
			carToUpdate.BrandId = car.BrandId;
		}

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			throw new NotImplementedException();
		}
	}
}
