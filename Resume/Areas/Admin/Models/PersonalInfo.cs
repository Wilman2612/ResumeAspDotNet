using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Areas.Admin.Models
{
	public class PersonalInfo
	{
		public int Id { get; set; }
		[Required]
		public string State { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		public string Photo { get; set; }
	}
}
