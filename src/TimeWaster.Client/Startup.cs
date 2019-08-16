using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using Smab.DiceAndTiles;

namespace TimeWaster.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
			services.AddTransient<IBoggleDice, BoggleDice>();
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
