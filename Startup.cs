using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MovieProject.Data;
using MovieProject.Interfaces;
using MovieProject.Interfaces.IMapper;
using MovieProject.Mapper;
using MovieProject.Repository;

namespace MovieProject
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUnitOfwork, UnitOfWork>();
            services.AddScoped<IActorMapper, ActorMapper>();
            services.AddScoped<IActorViewModelMapper, ActorViewModelMapper>();
            services.AddScoped<IMovieMapper, MovieMapper>();
            services.AddScoped<IMovieViewModelMapper, MovieViewModelMapper>();
            services.AddScoped<ICinemaMapper, CinemaMapper>();
            services.AddScoped<ICinemaViewModelMapper, CinemaViewModelMapper>();
            services.AddScoped<IProducerMapper, ProducerMapper>();
            services.AddScoped<IProducerViewModelMapper, ProducerViewModelMapper>();
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MovieProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Seed database
            AppDbInitializer.Seed(app);
        }
    }
}
