using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}


		[SecuredOperation("car.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		//[PerformanceAspect(5)]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		[SecuredOperation("admin,moderator")]
		public IResult Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}
		[SecuredOperation("admin,moderator")]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Update(Car car)
		{
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		[CacheAspect]
		[PerformanceAspect(5)]
		public IDataResult<List<Car>> GetAll()
		{
			Thread.Sleep(5000);
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
		}

		[CacheAspect]
		[CacheRemoveAspect("ICarService.Get")]
		[ValidationAspect(typeof(CarValidator))]
		//[PerformanceAspect(5)]
		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
		}


		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			if (DateTime.Now.Hour == 12)
			{
				return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
			}
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
		}


		public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
		}


		public IDataResult<List<Car>> GetCarsByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
		}


		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName));
		}


		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == colorName));
		}


		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c =>
				c.BrandName == brandName && c.ColorName == colorName));
		}

		//public IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto>> filter = null)
		//{
		//	return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		//}
	}
}
