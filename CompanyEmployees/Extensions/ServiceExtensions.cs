using Contracts;
using Service.Contracts;
using Service;
using LoggerService;
using Microsoft.Extensions.Options;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Extensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder.AllowAnyHeader()
						   .AllowAnyMethod()
						   .AllowAnyHeader();
				});
			});

		public static void ConfigureIISIntegration(this IServiceCollection services) =>
			services.Configure<IISOptions>(options => { });

		public static void ConfigureLoggerService(this IServiceCollection services) =>
			services.AddSingleton<ILoggerManager, LoggerManager>();

		public static void ConfigureRepositoryManager(this IServiceCollection services) =>
			services.AddScoped<IRepositoryManager, RepositoryManager>();
		public static void ConfigureServiceManager(this IServiceCollection services) =>
			services.AddScoped<IServiceManager, ServiceManager>();
		public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
			services.AddDbContext<RepositoryContext>(opts =>
				opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
		public static void ConfigureApiBehaviourOptions(this IServiceCollection services) =>
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
		public static void ConfigureControllers(this IServiceCollection services) =>
			services.AddControllers(config => { 
									config.RespectBrowserAcceptHeader = true;
									config.ReturnHttpNotAcceptable = true;
					})
					.AddXmlDataContractSerializerFormatters()
					.AddCustomCSVFormatter()
					.AddApplicationPart(typeof(CompanyEmployees.Presentation.AssemblyReference).Assembly);
		public static IMvcBuilder AddCustomCSVFormatter(this IMvcBuilder builder) =>
			 builder.AddMvcOptions(config => config.OutputFormatters.Add(new CsvOutputFormatter()));
	}
}
