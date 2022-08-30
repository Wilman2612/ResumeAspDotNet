using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public partial class Job
	{
		public string Id { get; set; }
		[Required]
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		[Required]
		public string CompanyName { get; set; }
		[Required]
		public string TittleEs { get; set; }
		[Required]
		public string TittleEn { get; set; }
		[Required]
		public string LocationEn { get; set; }
		[Required]
		public string LocationEs { get; set; }
		public List<JobResponsibility> Responsibilities { get; set; }
	}
}
