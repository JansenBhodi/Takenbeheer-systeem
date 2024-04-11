using TakenbeheerCore.Task;
using TakenbeheerDAL;

namespace TakenbeheerSysteem
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ITaskRepository), typeof(TaskRepository));
        }
    }
}
