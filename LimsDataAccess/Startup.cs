using GraphQL.Server.Ui.Voyager;
using LimsDataAccess.Data;
using LimsDataAccess.GraphQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimsDataAccess
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
            //services.AddControllers();
            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "LimsDataAccess", Version = "v1" });
            //});

            services.AddPooledDbContextFactory<LimsContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("LimsContext")));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LimsDataAccess v1"));
            }

            //Tar bort redirection f�r att kunna anropa localhost fr�n Java-projekt, Certifikat-problem annars
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});


            //https://localhost:44303/graphQL/
            //http://localhost:3627/graphql/
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });


            //https://localhost:44303/ui/voyager
            app.UseGraphQLVoyager(new VoyagerOptions());
        }
    }
}
