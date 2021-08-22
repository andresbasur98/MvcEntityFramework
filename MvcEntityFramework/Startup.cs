using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcEntityFramework.Data;
using MvcEntityFramework.Models;
using MvcEntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
      
        IConfiguration Configuration { get; set; }
        // Para acceder al fichero APPSETTINGS.JSON
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            String cadena = Configuration.GetConnectionString("casasqlhospital");
            services.AddTransient<RepositoryDoctores>();

            services.AddTransient<RepositoryEmpleados>();
            services.AddDbContext<EmpleadosContext>(options =>
            options.UseSqlServer(cadena));

            services.AddTransient<RepositoryPlantilla>();
            services.AddTransient<RespositoryEmpleadosHospital>();
            services.AddTransient<RepositoryTodosEmpleados>();
            services.AddDbContext<HospitalContext>(options =>
            options.UseSqlServer(cadena));

            //String cadena = Configuration.GetConnectionString("casamysqlhospital");
            //string cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Integrated Security=True";
            services.AddSingleton<IDepartamentosContext, DepartamentosContextMySql>(context => new DepartamentosContextMySql(cadena));
            //services.AddTransient<Coche>(); Crea uno nuevo por petición

            services.AddSingleton<ICoche>(z => new Deportivo("Ferrari", "Testarrosa","ferrari.jpg", 300)); // Crea uno único
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
