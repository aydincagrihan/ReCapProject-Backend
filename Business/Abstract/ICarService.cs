using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<Car> GetById(int carId);

		IDataResult<List<Car>> GetAll();

		IDataResult<List<CarDetailDto>> GetCarDetails();

		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);

		IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);

		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandNameAndColorName(string brandName, string colorName);

		//IDataResult<List<CarDetailDto>> GetCarDetails(Expression<Func<CarDetailDto>> filter = null);

		IDataResult<List<Car>> GetCarsByBrandId(int brandId);

		IDataResult<List<Car>> GetCarsByColorId(int colorId);

		




		IResult Add(Car car);

		IResult Delete(Car car);

		IResult Update(Car car);

	}
}
