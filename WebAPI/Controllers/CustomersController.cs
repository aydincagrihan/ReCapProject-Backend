using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomersController(ICustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _customerService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _customerService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Customer customer)
		{
			var result = _customerService.Add(customer);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Customer customer)
		{
			var result = _customerService.Update(customer);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Customer customer)
		{
			var result = _customerService.Delete(customer);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
	}
}
