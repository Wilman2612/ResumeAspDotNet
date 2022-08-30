using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Resume.Models;

namespace Resume.Areas.Admin.Models
{
	public class CVModel_JobResp
	{

		public string CVModelId { get; set; }
		public CVModel CVModel { get; set; }
		public int JobResponsibilityId { get; set; }
		public JobResponsibility JobResponsibility { get; set; }

	}
}
