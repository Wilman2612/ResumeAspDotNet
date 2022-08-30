using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CV.Data;
using Resume.Areas.Admin.Models;
using Resume.Models;

namespace Resume
{
	public class DbInitializer
	{
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

			// Look for any students.
			if (context.PersonalInfo.Any())
			{
				return;   // DB has been seeded
			}

			PersonalInfo personalInfo = new PersonalInfo
            {
                Address = "Villa del Sol C-16",
                City = "Subtanjalla",
                Name = "Wilman",
                Surname="Vásquez",
                State= "Ica",
                //Id = 1
            };
            CVModel defCV = new CVModel
            {
                Id = "Default",
                Remark = "Información a mostrarse en la página principal",
                AboutMeEs = "Tengo 3+ años de experiencia en .net",
                AboutMeEn = "I have 3+ years of expirience in .net"
            };

            Job jobs = new Job
            {
                Id = "Ventura",
                CompanyName = "Ventura Soluciones",
                StartDate = new DateTime(2019, 5, 22),
                LocationEs = "Lima, Perú",
                TittleEs = "Desarrollador SAP Business One",
                LocationEn = "Peru, Lima",
                TittleEn = "SAP Business One Developer",
                Responsibilities = new List<JobResponsibility>
				{
					new  JobResponsibility{
                       DescriptionEn = "Programming",
                       DescriptionEs = "Programación"
					}
				}
            };

            context.PersonalInfo.Add(personalInfo);
			context.CVModels.Add(defCV);
            context.Jobs.Add(jobs);
            context.SaveChanges();
        }
    }
}
