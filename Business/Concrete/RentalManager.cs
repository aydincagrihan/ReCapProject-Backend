using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class RentalManager:IRentalService
	{
		private ICarService _carService;
		private IRentalDal _rentalDal;

		public RentalManager(IRentalDal rentalDal,ICarService carService)
		{
			_rentalDal = rentalDal;
			_carService = carService;
		}
		[ValidationAspect(typeof(RentalValidator))]
		public IResult Add(Rental rental)
		{

			var result = CheckReturnDateByCarId(rental.CarId);

			if (!result.Success)
			{
				return new ErrorResult(result.Message);
			}

			_rentalDal.Add(rental);
			return new SuccessResult(Messages.RentalAdded);

		}

		public IResult Update(Rental rental)
		{
			_rentalDal.Update(rental);

			return new SuccessResult(Messages.RentalUpdated);
		}

		public IResult Delete(Rental rental)
		{
			_rentalDal.Delete(rental);

			return new SuccessResult(Messages.RentalDeleted);
		}

		public IResult CheckReturnDateByCarId(int carId)
		{
			var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);

			if (result != null && result.Count > 0) return new ErrorResult(Messages.RentalUndeliveredCar);

			return new SuccessResult();
		}

		

		public IDataResult<List<Rental>> GetAll()
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
		}

		public IDataResult<List<Rental>> GetAllByCarId(int carId)
		{
			return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
		}

		public IDataResult<Rental> GetById(int id)
		{
			return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == id));
		}

		public IResult IsRentable(Rental rental)
		{
			var result = _rentalDal.GetAll(r => r.CarId == rental.CarId);

			foreach (var r in result)
			{
				if (r.RentEndDate >= rental.RentStartDate && r.RentStartDate <= rental.RentEndDate)

					return new ErrorResult(Messages.RentalNotAvailable);
			}

			return new SuccessResult();
		}

		
	}
}
