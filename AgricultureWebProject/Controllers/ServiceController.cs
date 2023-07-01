using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureWebProject.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;
		private readonly IValidator<Service> _validator;

		public ServiceController(IServiceService serviceService, IValidator<Service> validator)
		{
			_serviceService = serviceService;
			_validator = validator;
		}

		public IActionResult Index()
		{
			var values = _serviceService.TGetListAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddService()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddService(Service service)
		{
			ValidationResult result = _validator.Validate(service);
			if (result.IsValid)
			{
			_serviceService.TInsert(service);
			return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
			}
			return View();
		}

		public IActionResult DeleteService(int id)
		{
			var value = _serviceService.TGetByID(id);
			_serviceService.TDelete(value);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditService(int id)
		{
			var value = _serviceService.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult EditService(Service service)
		{
			ValidationResult result = _validator.Validate(service);
			if(result.IsValid)
			{
			_serviceService.TUpdate(service);
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
	}
}
