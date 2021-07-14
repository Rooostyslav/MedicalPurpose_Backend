using MedicalPurpose.Auth.Common;
using MedicalPurpose.BLL.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalPurpose.Auth.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			var authOptionConfiguration = Configuration.GetSection("Auth");
			services.Configure<AuthOptions>(authOptionConfiguration);

			string connectionString = Configuration.GetConnectionString("MedicalPurposeDefault");
			services.AddContext(connectionString);

			services.AddServices();
			services.AddAutoMapper();
			services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowAnyOrigin();
				});
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseCors();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
