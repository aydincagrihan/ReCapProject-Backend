using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
	{

		public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
		{
			using ReCapContext context = new ReCapContext();
			var result = from c in context.Cars
				join b in context.Brands
					on c.BrandId equals b.BrandId
				join cl in context.Colors
					on c.ColorId equals cl.ColorId
				select new CarDetailDto
				{
					CarId = c.CarId,
					CarName = c.Description,
					BrandName = b.BrandName,
					ColorName = cl.ColorName,
					DailyPrice = c.DailyPrice,
					ModelYear = c.ModelYear
				};
			return filter == null ? result.ToList() : result.Where(filter).ToList();
		}

	}


}





				//var result = from cr in context.Cars
				//			 join b in context.Brands on cr.BrandId equals b.BrandId
				//			 join cl in context.Colors on cr.ColorId equals cl.ColorId
				//			 select new CarDetailDto
				//			 {
				//				 CarId = cr.CarId,
				//				 CarName = cr.Description,
				//				 BrandName = b.BrandName,
				//				 ColorName = cl.ColorName,
				//				 DailyPrice = cr.DailyPrice

				//			 };
				//return result.ToList();
		

