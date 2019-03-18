using Nop.Core;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.PromoSlider.Data;
using Nop.Services.Cms;
using Nop.Web.Framework.Menu;
using System.Collections.Generic;
using System.Linq;

namespace Nop.Plugin.Widgets.PromoSlider
{
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
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

        public void ManageSiteMap(SiteMapNode rootNode)
        {
            var createUpdateNode = new SiteMapNode()
            {
                Visible = true,
                Title = "New Slider",
                SystemName = "New Slider",
                IconClass= "fa-genderless",
                Url = "/PromoSlider/CreateUpdatePromoSlider"
            };

            var manageSliders = new SiteMapNode()
            {
                Visible = true,
                Title = "Manage Sliders",
                SystemName = "Manage Sliders",
                IconClass= "fa-genderless",
                Url = "/PromoSlider/ManagePromoSliders"
            };

            var parentNode = new SiteMapNode()
            {
                Visible = true,
                Title = "Promo Slider",
                SystemName = "Promo Slider",
                IconClass= "fa-dot-circle-o"
            };

            parentNode.ChildNodes.Add(createUpdateNode);
            parentNode.ChildNodes.Add(manageSliders);

            var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
            if (pluginNode != null)
                pluginNode.ChildNodes.Add(parentNode);
            else
                rootNode.ChildNodes.Add(parentNode);
        }
    }
}
