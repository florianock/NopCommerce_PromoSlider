using Microsoft.AspNetCore.Mvc;
using Nop.Core.Caching;
using Nop.Core.Data;
using Nop.Plugin.Widgets.PromoSlider.Domain;
using Nop.Services.Events;
using Nop.Services.Media;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.PromoSlider.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    public class WidgetsPromoSliderController : BasePluginController
    {
        #region Fields

        private readonly IRepository<PromoSliderRecord> _sliderRepo;
        private readonly IRepository<PromoImageRecord> _imageRepo;
        private readonly IPictureService _pictureService;
        private readonly ICacheManager _cacheService;
        private readonly IEventPublisher _eventPublisher;

        #endregion

        #region Ctor

        public WidgetsPromoSliderController(IRepository<PromoSliderRecord> sliderRepo,
                IRepository<PromoImageRecord> imageRepo,
                IPictureService pictureService,
                ICacheManager cacheService,
                IEventPublisher eventPublisher)
        {
            _sliderRepo = sliderRepo;
            _imageRepo = imageRepo;
            _pictureService = pictureService;
            _cacheService = cacheService;
            _eventPublisher = eventPublisher;
        }

        #endregion

        #region Methods

        public IActionResult Configure()
        {
            return View("~/Plugins/Widgets.PromoSlider/Views/Configure.cshtml");
        }
        #endregion
    }
}