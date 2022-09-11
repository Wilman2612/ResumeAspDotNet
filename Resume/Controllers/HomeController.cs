using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Resume.Areas.Admin.Models;
using Resume.Models;
using Resume.ViewModel;

namespace Resume.Controllers
{
	public class HomeController : Controller
    {
		private const string LNG_COOKIE = "Language";
		private const string US_FORMAT = "En-US";
		private readonly ILogger<HomeController> _logger;
        private readonly DBContext _context;

        public HomeController(ILogger<HomeController> logger, DBContext context)
        {
            _context = context;
            _logger = logger;
        }

       public async Task<IActionResult> Index(string code= "Default")
		{
			var defaultCV = await _context.CVModels
				.Include(x => x.CVModel_JobResp)
					.ThenInclude(z => z.JobResponsibility)
					.ThenInclude(x => x.Job)
				.FirstOrDefaultAsync(x => x.Id == code);
			
			var language = GetLanguage();
			var data = new CompleteCVData
			{
				Id = code,
				About = defaultCV.About(language),
				PersonalInfo = await _context.PersonalInfo.FirstOrDefaultAsync(),
				Jobs = GetJobsTranslated(defaultCV, language)
			};
			return View(data);
		}

		private LanguageName GetLanguage()
		{
			var cookieLng = Request.Cookies[LNG_COOKIE] ?? US_FORMAT;
			return cookieLng == US_FORMAT ? LanguageName.English : LanguageName.Spanish;
		}

		private static List<JobTranslated> GetJobsTranslated(CVModel defaultCV, LanguageName language)
		{
			return defaultCV.CVModel_JobResp
				.GroupBy(x => x.JobResponsibility.JobId)
				.Select(x =>
			{
				var job = x.First().JobResponsibility.Job;
				return new JobTranslated
				{
					CompanyName = job.CompanyName,
					StartDate = job.StartDate,
					EndDate = job.EndDate,
					Id = job.Id,
					Location = job.Location(language),
					Tittle = job.Tittle(language),
					Responsibilities = x.Select(y => y.JobResponsibility.Description(language)).ToList()
				};
			}).ToList();
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
