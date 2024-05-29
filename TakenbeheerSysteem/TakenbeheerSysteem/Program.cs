using Microsoft.Extensions.DependencyInjection;
using System.Text;
using TakenbeheerCore.Employee;
using TakenbeheerCore.Task;
using TakenbeheerCore.Team;
using TakenbeheerDAL;

namespace TakenbeheerSysteem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            

            // Add services to the container.
            builder.Services.AddRazorPages();
            //More extensive injection allowing for passing other interfaces along and other services like logger.
            builder.Services.AddScoped<ITaskRepository>(sp =>
            {
                //The following line will allow me to use subtask repo in task repo
                //var subtaskRepository = sp.GetRequiredService<ISubtaskRepository>();
                var logger = sp.GetRequiredService<ILogger<TaskRepository>>();
                return new TaskRepository(logger);
            });
            builder.Services.AddScoped<IEmployeeRepository>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<EmployeeRepository>>();
                return new EmployeeRepository(logger);
            });
            builder.Services.AddScoped<ITeamRepository, TeamRepository>();
            //builder.Services.AddScoped<ISubtaskRepository, SubtaskRepository>();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

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
            app.UseSession();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();

            app.Run();
        }
    }
}
