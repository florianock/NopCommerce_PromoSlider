using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nop.Core.Infrastructure;
using Nop.Plugin.Widgets.PromoSlider.Data;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Nop.Plugin.Widgets.PromoSlider.Infrastructure
{
    public class PluginDbStartup : INopStartup
    {
        void INopStartup.ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PromoSliderObjectContext>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServerWithLazyLoading(services);
            });
        }

        void INopStartup.Configure(IApplicationBuilder application)
        {
        }

        int INopStartup.Order => 11;
    }
}
