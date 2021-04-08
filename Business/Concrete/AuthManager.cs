using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
	        HashingHelper.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
	        var userToCheck = _userService.GetByMail(userForLoginDto.Email).Data;
	        if (userToCheck == null)
	        {
		        return new ErrorDataResult<User>(Messages.UserNotFound);
	        }

	        if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
	        {
		        return new ErrorDataResult<User>(Messages.PasswordError);
	        }

	        return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
	        if (_userService.GetByMail(email).Data != null)
	        {
		        return new ErrorResult(Messages.UserAlreadyExists);
	        }
	        return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
	        var claims = _userService.GetClaims(user);
	        var accessToken = _tokenHelper.CreateToken(user, claims.Data);
	        return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        [SecuredOperation("user")]
        public IResult IsAuthenticated(string userMail, List<string> requiredRoles)
        {
	        if (requiredRoles != null)
	        {
		        var user = _userService.GetByMail(userMail).Data;
		        var userClaims = _userService.GetClaims(user).Data;
		        var doesUserHaveRequiredRoles =
			        requiredRoles.All(role => userClaims.Select(userClaim => userClaim.Name).Contains(role));
		        if (!doesUserHaveRequiredRoles) return new ErrorResult(Messages.AuthorizationDenied);
	        }

	        return new SuccessResult();
        }
    }
}

