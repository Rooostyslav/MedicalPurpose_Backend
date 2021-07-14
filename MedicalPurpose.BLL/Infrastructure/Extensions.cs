using AutoMapper;
using MedicalPurpose.BLL.Services;
using MedicalPurpose.BLL.Services.Implementation;
using MedicalPurpose.DAL.EF;
using MedicalPurpose.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalPurpose.BLL.Infrastructure
{
	public static class Extensions
	{
		public static void AddContext(this IServiceCollection services, string connectionString)
		{
			services.AddDbContext<MedicalPurposeContext>(options =>
				options.UseSqlServer(connectionString),
				ServiceLifetime.Transient);
		}

		public static void AddAutoMapper(this IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(config =>
			{
				config.AddProfile(new MappingProfile());
			});

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IDoctorService, DoctorService>();
			services.AddScoped<IPatientService, PatientService>();
			services.AddScoped<IVisitService, VisitService>();
			services.AddScoped<IPrescriptionService, PrescriptionService>();
			services.AddScoped<IMedicineService, MedicineService>();
			services.AddScoped<IQRCodeService, QRCodeService>();
		}
	}
}
