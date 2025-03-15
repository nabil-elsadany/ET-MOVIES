using movie_ticket.Repositories.IRepositories;
using movie_ticket.Repositories;
using ET_Movies.Data;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IActorMoviesRepository, ActorMoviesRepository>();
            builder.Services.AddScoped<IActorsRepository, ActorsRepository>();
            builder.Services.AddScoped<ICategoreisRepository, CategoreisRepository>();
            builder.Services.AddScoped<ICinemasRepository, CinemasRepository>();
            builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();
            builder.Services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
