using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public  partial class Job
	{
		public string Tittle(LanguageName language)
		{
			if (language == LanguageName.English)
				return TittleEn;
			return TittleEs;
		}
		public string Location(LanguageName language)
		{
			if (language == LanguageName.English)
				return LocationEn;
			return LocationEs;
		}
	}
}
