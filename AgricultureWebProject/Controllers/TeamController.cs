using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgricultureWebProject.Controllers
{
	public class TeamController : Controller
	{
		private readonly ITeamService _teamService;
		private readonly IValidator<Team> _validator;

		public TeamController(ITeamService teamService, IValidator<Team> validator)
		{
			_teamService = teamService;
			_validator = validator;
		}

		public IActionResult Index()
		{
			var values = _teamService.TGetListAll();
			return View(values);
		}

		[HttpGet]
		public IActionResult AddTeam()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddTeam(Team team)
		{
			ValidationResult result = _validator.Validate(team);
			if (result.IsValid)
			{
				_teamService.TInsert(team);
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
		public IActionResult EditTeam(int id)
		{
			var values = _teamService.TGetByID(id);
			return View(values);
		}

		[HttpPost]
		public IActionResult EditTeam(Team team)
		{
			ValidationResult result = _validator.Validate(team);
			if (result.IsValid)
			{
			_teamService.TUpdate(team);
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

		public IActionResult DeleteTeam(int id)
		{
			var value = _teamService.TGetByID(id);
			_teamService.TDelete(value);
			return RedirectToAction("Index");
		}
	}
}
