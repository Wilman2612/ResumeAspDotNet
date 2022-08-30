using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public partial class CVModel
	{
		public string About(LanguageName language)
		{
			if (language == LanguageName.English)
				return AboutMeEn;
			return AboutMeEs;
		}
	}
}
