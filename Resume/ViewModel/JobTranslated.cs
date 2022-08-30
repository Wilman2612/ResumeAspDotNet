using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModel
{
	public class JobTranslated
	{
		public string Id { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public string CompanyName { get; set; }
		public string Tittle { get; set; }
		public string Location { get; set; }
		public List<string> Responsibilities { get; set; }
	}
}
