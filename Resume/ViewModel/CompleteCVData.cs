using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Areas.Admin.Models;

namespace Resume.ViewModel
{
	public class CompleteCVData
	{
		public string Id{ get; set; }
		public string About { get; set; }
		public PersonalInfo PersonalInfo { get; set; }

		public List<JobTranslated> Jobs { get; set; }
	}
}
