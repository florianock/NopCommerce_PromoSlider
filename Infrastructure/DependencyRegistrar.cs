using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Widgets.PromoSlider.Data;
using Nop.Plugin.Widgets.PromoSlider.Domain;
using Nop.Web.Framework.Infrastructure.Extensions;

namespace Nop.Plugin.Widgets.PromoSlider.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        private const string CONTEXT_NAME = "nop_object_context_promo_slider";

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterPluginDataContext<PromoSliderObjectContext>(CONTEXT_NAME);

            builder.RegisterType<EfRepository<PromoSliderRecord>>()
                .As<IRepository<PromoSliderRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            builder.RegisterType<EfRepository<PromoImageRecord>>()
                .As<IRepository<PromoImageRecord>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }

        public int Order => 1;
    }
}
