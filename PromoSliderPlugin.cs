using Nop.Core;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.PromoSlider.Data;
using Nop.Services.Cms;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.PromoSlider
{
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin
    {
        private readonly PromoSliderObjectContext _context;
        private readonly IWebHelper _webHelper;

        private const string COMPONENT_NAME = "WidgetsPromoSlider";

        public PromoSliderPlugin(PromoSliderObjectContext context, IWebHelper webHelper)
        {
            _context = context;
            _webHelper = webHelper;
        }

        public override string GetConfigurationPageUrl()
        {
            return $"{_webHelper.GetStoreLocation()}Admin/{COMPONENT_NAME}/Configure";
        }

        public string GetWidgetViewComponentName(string widgetZone)
        {
            return COMPONENT_NAME;
        }

        public IList<string> GetWidgetZones()
        {
            return new List<string>();
        }

        public override void Install()
        {
            _context.Install();
            base.Install();
        }

        public override void Uninstall()
        {
            _context.Uninstall();
            base.Uninstall();
        }
    }
}
