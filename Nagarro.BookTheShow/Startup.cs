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
using Nagarro.BookTheShow.BL;
using Nagarro.BookTheShow.DAL.Data.DbContexts;
using Nagarro.BookTheShow.DAL.Repository;
using Nagarro.BookTheShow.Interfaces.Repositories;
using Nagarro.BookTheShow.Interfaces.Service;


namespace Nagarro.BookTheShow
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
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nagarro.BookTheShow", Version = "v1" });
            });


            services.AddDbContext<BookTheShowContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IMovieSlotRepository, MovieSlotRepository>();
            services.AddScoped<IMovieSlotService, MovieSlotService>();
            services.AddScoped<IUserMovieBookRepository, UserMovieBookRepository>();
            services.AddScoped<IUserMovieBookService, UserMovieBookService>();
            services.AddScoped<IMovieListingRepository, MovieListingRepository>();
            services.AddScoped<IMovieListingService, MovieListingService>();
            services.AddCors((setup) => {
                setup.AddPolicy("default", (options) => {
                    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });

            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.ClearProviders();  // Remove default providers
                loggingBuilder.AddConsole();      // Log to console
                loggingBuilder.AddDebug();        // Log to Debug window in Visual Studio
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nagarro.BookTheShow v1"));
            }

            // Log an information message when the application starts
            logger.LogInformation("Application has started successfully!");
            app.UseCors("default");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
