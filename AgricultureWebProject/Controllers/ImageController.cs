using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureWebProject.Controllers
{
	public class ImageController : Controller
	{
		private readonly IImageService _ımageService;
		private readonly IValidator<Image> _validator;

		public ImageController(IImageService ımageService, IValidator<Image> validator)
		{
			_ımageService = ımageService;
			_validator = validator;
		}

		public IActionResult Index()
		{
			var values = _ımageService.TGetListAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddImage()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddImage(Image ımage)
		{
			ValidationResult result = _validator.Validate(ımage);
			if (result.IsValid)
			{
				_ımageService.TInsert(ımage);
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
		public IActionResult EditImage(int id)
		{
			var value = _ımageService.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult EditImage(Image ımage)
		{
			ValidationResult result = _validator.Validate(ımage);
			if (result.IsValid)
			{
				_ımageService.TUpdate(ımage);
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

		public IActionResult DeleteImage(int id)
		{
			var value = _ımageService.TGetByID(id);
			_ımageService.TDelete(value);
			return RedirectToAction("Index");
		}
	}
}
