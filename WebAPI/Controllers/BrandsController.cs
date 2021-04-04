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
	public class BrandsController : ControllerBase
	{
		private IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _brandService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _brandService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Brand brand)
		{
			var result = _brandService.Add(brand);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Brand brand)
		{
			var result = _brandService.Update(brand);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Brand brand)
		{
			var result = _brandService.Delete(brand);
			return result.Success ? (IActionResult)Ok(result) : BadRequest(result);
		}
	}
}
