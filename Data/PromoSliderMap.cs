using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using Nop.Plugin.Widgets.PromoSlider.Domain;

namespace Nop.Plugin.Widgets.PromoSlider.Data
{
    public partial class PromoSliderMap : NopEntityTypeConfiguration<PromoSliderRecord>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<PromoSliderRecord> builder)
        {
            builder.ToTable("PromoSlider_PromoSliders");

            builder.HasKey(m => m.PromoSliderId);

            builder.Property(m => m.PromoSliderName);
            builder.Property(m => m.ZoneName);
            builder.Property(m => m.Interval);
            builder.Property(m => m.Keyboard);
            builder.Property(m => m.PauseOnHover);
            builder.Property(m => m.Wrap);
        }

        #endregion
    }
}
