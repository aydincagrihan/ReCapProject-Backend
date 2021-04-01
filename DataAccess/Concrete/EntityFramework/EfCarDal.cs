using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : ICarDal
	{
		public void Add(Car entity)
		{
			using ReCapContext context = new ReCapContext();
			var addedEntity = context.Entry(entity);
			addedEntity.State = EntityState.Added;
			context.SaveChanges();
		}

		public void Delete(Car entity)
		{
			using ReCapContext context = new ReCapContext();
			var deletedEntity = context.Entry(entity);
			deletedEntity.State = EntityState.Deleted;
			context.SaveChanges();
		}

		public Car Get(Expression<Func<Car, bool>> filter)
		{
			throw new NotImplementedException();
		}

		public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public void Update(Car entity)
		{
			using ReCapContext context = new ReCapContext();
			var updatedEntity = context.Entry(entity);
			updatedEntity.State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}
