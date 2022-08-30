using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public enum LanguageName
	{
		[EnumMember(Value = "En-US")]
		English,
		[EnumMember(Value = "Es-PE")]
		Spanish
	}
}
