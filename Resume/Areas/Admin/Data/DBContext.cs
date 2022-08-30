using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Areas.Admin.Models;
using Resume.Models;

namespace CV.Data
{
	public class DBContext : DbContext
	{

		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CVModel_JobResp>().HasKey(sc => new { sc.CVModelId, sc.JobResponsibilityId });
		}

		public DbSet<CVModel> CVModels { get; set; }

		public DbSet<Job> Jobs { get; set; }

		public DbSet<JobResponsibility> JobResponsibility { get; set; }

		public DbSet<CVModel_JobResp> CVModel_JobResp { get; set; }

		public DbSet<PersonalInfo> PersonalInfo { get; set; }

		public DbSet<Skill> Skills { get; set; }
	}
}
