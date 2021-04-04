using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		private readonly ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carService.GetAll();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _carService.GetById(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}


		[HttpPost("add")]
		public IActionResult Add(Car car)
		{
			var result = _carService.Add(car);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Car car)
		{
			var result = _carService.Update(car);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Car car)
		{
			var result = _carService.Delete(car);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcardetails")]
		public IActionResult GetCarDetails()
		{
			var result = _carService.GetCarDetails();
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcarsbybrandid")]
		public IActionResult GetCarsByBrandId(int id)
		{
			var result = _carService.GetCarsByBrandId(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcarsbycolorid")]
		public IActionResult GetCarsByColorId(int id)
		{
			var result = _carService.GetCarsByColorId(id);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcardetailsbybrandname")]
		public IActionResult GetCarDetailsByBrandName(string name)
		{
			var result = _carService.GetCarDetailsByBrandName(name);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcardetailsbycolorname")]
		public IActionResult GetCarDetailsByColorName(string name)
		{
			var result = _carService.GetCarDetailsByColorName(name);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}

		[HttpGet("getcardetailsbybrandnameandcolorname")]
		public IActionResult GetCarDetailsByBrandNameAndColorName(string brandName, string colorName)
		{
			var result = _carService.GetCarDetailsByBrandNameAndColorName(brandName, colorName);
			return result.Success ? (IActionResult) Ok(result) : BadRequest(result);
		}
	}
}
