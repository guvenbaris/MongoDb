using System.Data;
using System.Data.SqlClient;
using DapperDataAccess.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDataAccess.DataAccess;
using MongoDataAccess.DataAccess.Concrete;
using MongoDb.DataOperation;

namespace MongoDb
{
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDb", Version = "v1" });
            });

            services.AddScoped<IDbConnection>(sp => new SqlConnection(Configuration.GetConnectionString("mssql")));

            services.AddScoped<GenreRepository>();
            services.AddScoped<ChoreDataAccess>();


            services.AddScoped<MongoChoreRepository>();
            services.AddScoped<MongoUserRepository>();

            services.AddScoped<DpChoreRepository>();
            services.AddScoped<DpUserRepository>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDb v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
