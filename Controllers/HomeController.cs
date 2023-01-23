
using Indigo.Areas.Admin.Controllers;
using Indigo.Models;
using Indigo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Indigo.Controllers
{
	public class HomeController : Controller
	{
        private readonly DataContext _dataContext;

        public HomeController(DataContext dataContext)
		{
            _dataContext = dataContext;
        }
	
		public IActionResult Index()
		{

			HomeViewModel homeViewModel = new HomeViewModel
			{
				Sliders = _dataContext.Sliders.ToList(),
			};

			return View(homeViewModel);
		}

		
	}
}