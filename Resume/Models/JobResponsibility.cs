using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class JobResponsibility
	{
		public int Id { get; set; }
		public int JobId { get; set; }
		public Job Job { get; set; }

		public List<JobResponsibility_I18n> JobRsplbtyTranslations { get; set; }
}
}
