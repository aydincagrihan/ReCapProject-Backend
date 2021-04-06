using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _userService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _userService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(User user)
		{
			var result = _userService.Delete(user);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
		[HttpGet("getuserdetailbymail")]
		public IActionResult GetUserDetailByMail(string userMail)
		{
			var result = _userService.GetUserDetailByMail(userMail);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(User user)
		{
			var result = _userService.Update(user);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
	}
}
