using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureWebProject.Controllers
{
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;
		private readonly IValidator<Address> _validator;

		public AddressController(IAddressService addressService, IValidator<Address> validator)
		{
			_addressService = addressService;
			_validator = validator;
		}

		public IActionResult Index()
		{
			var values = _addressService.TGetListAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddAddress()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddAddress(Address address)
		{
			ValidationResult result = _validator.Validate(address);
			if (result.IsValid)
			{
				_addressService.TInsert(address);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		[HttpGet]
		public IActionResult EditAddress(int id)
		{
			var value = _addressService.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult EditAddress(Address address)
		{
			ValidationResult result = _validator.Validate(address);
			if (result.IsValid)
			{
				_addressService.TUpdate(address);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult DeleteAddress(int id)
		{
			var value = _addressService.TGetByID(id);
			_addressService.TDelete(value);
			return RedirectToAction("Index");
		}
	}
}
