using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration) => Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "SimpleCalculator", Description = "Gestamp Programming Challenge", Contact = new OpenApiContact() { Name = "Andrew Lumley", Email = "andrewjlumley@outlook.com" } });
				c.EnableAnnotations();

				var filePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
				try { c.IncludeXmlComments(filePath, includeControllerXmlComments: true); }
				catch (Exception) { }
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			//if (env.IsDevelopment())
			//{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web v1"));
			//}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseStaticFiles(new StaticFileOptions()
			{
				FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "WWWRoot")),
				RequestPath = new PathString("/html")
			});
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
