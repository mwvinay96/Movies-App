using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movies.Infrastructure.Data;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;
using System.IO;
using Movies.Domain;
using Movies.API.Helpers;
using System.Text.RegularExpressions;
using System.Reflection;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Movies.API
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

            //Since reading from json, keeping it singleton for performance reasons.
            services.AddDbContext<IMoviesContext, MoviesContext>(options => options.UseInMemoryDatabase("movies"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movies.API", Version = "v1" });
            });
            var rootDir = GetApplicationRoot();
            var filePath = Path.Combine(rootDir, Configuration.GetSection("FilePath").Value);
            var fileContent = File.ReadAllText(filePath);
            var root = JsonConvert.DeserializeObject<Root>(fileContent);

            Seeder.Seed(services.BuildServiceProvider().GetRequiredService<IMoviesContext>(), root.Movies);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movies.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public string GetApplicationRoot()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            var appRoot = appPathMatcher.Match(exePath).Value;
            return appRoot;
        }
    }
}
