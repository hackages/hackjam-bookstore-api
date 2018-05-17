using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BookstoreWebApi.Controllers;
using BookstoreWebApi.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace BookstoreWebApi
{
   
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreContext>(opt => opt.UseInMemoryDatabase("BookStore"));

            services
                .AddMvcCore()
                .AddApiExplorer()
                .AddCors();

            services.AddApiVersioning(options => { options.AssumeDefaultVersionWhenUnspecified = false; });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "BookStore", Description = "BookStore Api"});
                
                var xmlFile = $"{Assembly.GetEntryAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(builder =>
            {
                builder.WithOrigins("https://coucou");
                builder.WithHeaders("x-coucou");
                builder.WithMethods("post");
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My BookStore API V1");
            });

            app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<BookStoreContext>();
                SeedDatabase(context);
            }
            
        }

        private static void SeedDatabase(BookStoreContext context)
        {
            var books = GetMockData<BookEntity>("books.json");
            context.Books.AddRange(books);
            context.SaveChanges();
        }

        private static IList<T> GetMockData<T>(string filename)
        {
            var seed = File.ReadAllText("Assets/" + filename);
            return JsonConvert.DeserializeObject<List<T>>(seed);
        }
    }
}
