using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AgricultureWebProject.Controllers
{
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;
		private readonly IValidator<Announcement> _validator;


		public AnnouncementController(IAnnouncementService announcementService, IValidator<Announcement> validator)
		{
			_announcementService = announcementService;
			_validator = validator;
		}

		public IActionResult Index()
		{
			var values = _announcementService.TGetListAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddAnnouncement()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddAnnouncement(Announcement announcement)
		{
			ValidationResult result = _validator.Validate(announcement);
			if (result.IsValid)
			{
				announcement.Status = true;
				announcement.Date = DateTime.Parse(DateTime.Now.ToString());
				_announcementService.TInsert(announcement);
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
		public IActionResult EditAnnouncement(int id)
		{
			var value = _announcementService.TGetByID(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult EditAnnouncement(Announcement announcement)
		{
			ValidationResult result = _validator.Validate(announcement);
			if (result.IsValid)
			{
				announcement.Date = DateTime.Parse(DateTime.Now.ToString());
				_announcementService.TUpdate(announcement);
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

		public IActionResult DeleteAnnouncement(int id)
		{
			var value = _announcementService.TGetByID(id);
			_announcementService.TDelete(value);
			return RedirectToAction("Index");
		}

		public IActionResult ChangeStatus(int id)
		{
			_announcementService.TChangeAnnouncementStatus(id);
			return RedirectToAction("Index");
		}
	}
}
