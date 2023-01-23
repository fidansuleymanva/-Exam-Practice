using Indigo.Helpers;
using Indigo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Indigo.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SliderController : Controller
	{
		private readonly DataContext _datacontext;
		private readonly IWebHostEnvironment _env;

		public SliderController(DataContext dataContext, IWebHostEnvironment env)
		{
			_datacontext = dataContext;
			_env = env;
		}
		public IActionResult Index()
		{
			List<Slider> sliderList = _datacontext.Sliders.ToList();	
			return View(sliderList);
		}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Slider slider)
        {
            if (slider.FormFile != null)
            {
                if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
                {
                    ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
                    return View();
                }
                if (slider.FormFile.Length > 3145728)
                {
                    ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
                    return View();
                }

                if (!ModelState.IsValid) return View();

                slider.Image = FileManage.SaveFile(_env.WebRootPath, "uploads/sliders", slider.FormFile);
                _datacontext.Sliders.Add(slider);
                _datacontext.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Slider slider = _datacontext.Sliders.Find(id);
                if (slider == null) return View();
                return View(slider);
        }
        [HttpPost]
        public IActionResult Update(Slider slider)
        {
            Slider exsistslider = _datacontext.Sliders.Find(slider.Id);
            if (exsistslider == null) return View();
            if(slider.FormFile !=null)
            {
				if (slider.FormFile.ContentType != "image/png" && slider.FormFile.ContentType != "image/jpeg")
				{
					ModelState.AddModelError("ImageFile", "But it can be png and jpeg!");
					return View();
				}
				if (slider.FormFile.Length > 3145728)
				{
					ModelState.AddModelError("ImageFile", "It can be 3 Mb!");
					return View();
				}
                string name = FileManage.SaveFile(_env.WebRootPath, "uploads/sliders", slider.FormFile);
                FileManage.DeleteFile(_env.WebRootPath, "uploads/sliders", exsistslider.Image);
                exsistslider.Image = name;

			}
            exsistslider.Title = slider.Title;
            exsistslider.Desc = slider.Desc;
            exsistslider.Button = slider.Button;
            exsistslider.URl = slider.URl;
            _datacontext.SaveChanges();
            return RedirectToAction("index");
		}
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }


    }
}
