using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class CVModel
	{
		public string Id { get; set; }
		public string Remark { get; set; }
		public List<Job> Jobs { get; set; }
		public List<CVModel_I18n> CVModelTranslations { get; set; }
	}
}
