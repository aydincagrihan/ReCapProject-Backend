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
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCapContext context=new ReCapContext())
			{
				var result = from c in context.Cars
					join b in context.Brands
						on c.BrandId equals b.BrandId
					select new CarDetailDto
						{BrandName = b.BrandName, CarName = c.CarName, DailyPrice = c.DailyPrice };

				return result.ToList();
			}
		}
	}
}
	
	
