using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class Job_I18n
	{
		public int Id { get; set; }
		public LanguageName Language { get; set; }
		public string CompanyName { get; set; }
		public string Tittle { get; set; }
		public string Location { get; set; }
		public Job Job { get; set; }
	}
}
