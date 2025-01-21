namespace BudgetMan.RestAPI
{
    using System.Reflection;
    using Microsoft.Extensions.Options;
    using Microsoft.OpenApi.Models;
    using Dao.Interface;
    using Dao.MongoDb;
    using Service;
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"BudgetMan {groupName}",
                    Version = groupName,
                    Description = "BudgetMan API"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            services.AddSingleton<IBudgetManService, BudgetManService>();
            services.AddSingleton<IBudgetManDao, BudgetManDao>();
            services.Configure<DatabaseSetting>(Configuration.GetSection("DatabaseSetting"));
            services.AddSingleton<IDatabaseSetting>(sp => sp.GetRequiredService<IOptions<DatabaseSetting>>().Value);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyOrigin();
                options.AllowAnyHeader();
                options.AllowAnyMethod();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseExceptionHandler("/error");
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BudgetMan Service V1");
            });
        }
    }
}