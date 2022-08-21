using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Resume.Models;

namespace CV.Data
{
	public class CVContext : DbContext
	{
		public CVContext(DbContextOptions<CVContext> options) : base(options)
		{
		}

		public DbSet<CVModel> CVModels { get; set; }
	}
}
