using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
	public class UserManager:IUserService
	{
		private IUserDal _userDal;
		private readonly ICustomerService _customerService;

		public UserManager(IUserDal userDal,ICustomerService customerService)
		{
			_userDal = userDal;
			_customerService = customerService;
		}

		[SecuredOperation("user.get,moderator,admin")]
		public IDataResult<User> GetById(int id)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == id));
		}


		public IDataResult<List<OperationClaim>> GetClaims(User user)
		{
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
		}

		public IDataResult<User> GetByMail(string email)
		{
			return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
		}


		public IDataResult<UserDetailDto> GetUserDetailByMail(string userMail)
		{
			return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetail(userMail));
		}


		[SecuredOperation("user.get,moderator,admin")]
		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll());
		}


		public IResult Add(User user)
		{
			_userDal.Add(user);

			return new SuccessResult(Messages.UserAdded);
		}

		[SecuredOperation("user.update,moderator,admin")]
		public IResult Update(User user)
		{
			_userDal.Update(user);

			return new SuccessResult(Messages.UserUpdated);
		}
		[SecuredOperation("user.delete,moderator,admin")]
		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.UserDeleted);
		}

		public IResult UpdateUserDetails(UserDetailForUpdateDto userDetailForUpdate)
		{
			throw new NotImplementedException();
		}
	}
}
