using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public partial class CVModel
	{
		public string Id { get; set; }
		public string Remark { get; set; }
		[Required]
		public string AboutMeEn { get; set; }
		[Required]
		public string AboutMeEs { get; set; }
		public List<CVModel_JobResp> CVModel_JobResp { get; set; }
	}
}
