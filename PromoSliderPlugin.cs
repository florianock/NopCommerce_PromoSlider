using Nop.Core.Plugins;
using Nop.Services.Cms;
using System;
using System.Collections.Generic;

namespace Nop.Plugin.Widgets.PromoSlider
{
    public class PromoSliderPlugin : IWidgetPlugin
    {
        PluginDescriptor IPlugin.PluginDescriptor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        string IPlugin.GetConfigurationPageUrl()
        {
            throw new NotImplementedException();
        }

        string IWidgetPlugin.GetWidgetViewComponentName(string widgetZone)
        {
            throw new NotImplementedException();
        }

        IList<string> IWidgetPlugin.GetWidgetZones()
        {
            throw new NotImplementedException();
        }

        void IPlugin.Install()
        {
            throw new NotImplementedException();
        }

        void IPlugin.Uninstall()
        {
            throw new NotImplementedException();
        }
    }
}
