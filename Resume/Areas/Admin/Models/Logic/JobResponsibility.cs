using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public partial class JobResponsibility
	{
		 public string Description(LanguageName language)
		{
			if (language == LanguageName.English)
				return DescriptionEn;
			return DescriptionEs;
		}
	}
}
