using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
	public class CVModel_I18n
	{
		public string Id { get; set; }
		public string CVModelId { get; set; }
		public LanguageName  Language {get; set;}
		public string About { get; set; }
		public CVModel CVModel { get; set; }
	}
}
