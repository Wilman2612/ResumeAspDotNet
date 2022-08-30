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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string JobId { get; set; }
		public Job Job { get; set; }
		[Required]
		public string DescriptionEn { get; set; }
		[Required]
		public string DescriptionEs { get; set; }
		public List<CVModel_JobResp> CVModel_JobResp { get; set; }
	}
}
