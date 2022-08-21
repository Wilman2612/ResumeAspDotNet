using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class JobResponsibility_I18n
	{
		public int Id { get; set; }
		public LanguageName Language { get; set; }
		public string Description { get; set; }
		public int JobResponsibilityId { get; set; }
		public JobResponsibility Job { get; set; }
	}
}
