using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimpleSkillsShowcase.Core.Entities;
using SimpleSkillsShowcase.Core.Implementations;
using SimpleSkillsShowcase.Core.Interfaces;
using SimpleSkillsShowcase.Core.ServiceRules;
using SimpleSkillsShowcase.Core.ServiceRules.Implementations;

namespace SimpleSkillsShowcase
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

            services.AddSwaggerGen();

            // Register Services
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<INoteServiceRule, NoteServiceRule>();

            // Register Data

            services.AddDbContext<NoteContext>(options =>
                options.UseSqlServer("Server=localhost;Initial Catalog=NoteDb;Trusted_Connection=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Note API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}