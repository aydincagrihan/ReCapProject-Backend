using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface IUserService
	{
		IDataResult<User> GetById(int id);

		IDataResult<List<User>> GetAll();

		IDataResult<User> GetByMail(string userMail);

		IDataResult<UserDetailDto> GetUserDetailByMail(string userMail);

		IResult Add(User user);

		IResult Update(User user);

		IResult Delete(User user);


	}
}
