using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class Job
	{
		public int Id { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public List<JobResponsibility> Responsibilities { get; set; }
		public List<Job_I18n> JobTranslations { get; set; }
	}
}
