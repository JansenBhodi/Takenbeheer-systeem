using Microsoft.Extensions.DependencyInjection;
using System.Text;
using TakenbeheerCore.Task;
using TakenbeheerDAL;

namespace TakenbeheerSysteem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //IServiceCollection services = new ServiceCollection();

            //Startup startup = new Startup();
            //startup.ConfigureServices(services);

            //IServiceProvider serviceProvider = services.BuildServiceProvider();

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddSingleton<ITaskRepository, TaskRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
