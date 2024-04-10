using TakenbeheerDAL;

namespace TakenbeheerSysteem
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(ITask), typeof(TakenbeheerCore.Task.Task));
            services.AddSingleton(typeof(ITaskRepository), typeof(TaskRepository));
        }
    }
}
