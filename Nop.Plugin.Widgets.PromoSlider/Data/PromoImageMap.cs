using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nop.Data.Mapping;
using Nop.Plugin.Widgets.PromoSlider.Domain;

namespace Nop.Plugin.Widgets.PromoSlider.Data
{
    public partial class PromoImageMap : NopEntityTypeConfiguration<PromoImageRecord>
    {
        #region Methods

        public override void Configure(EntityTypeBuilder<PromoImageRecord> builder)
        {
            builder.ToTable("PromoSlider_PromoImages");

            builder.HasKey(m => m.PromoImageId);

            builder.Property(m => m.PromoSliderId);
            builder.Property(m => m.Caption);
            builder.Property(m => m.DisplayOrder);
            builder.Property(m => m.Url);

            builder.HasOne(i => i.PromoSlider)
                    .WithMany(s => s.Images)
                    .HasForeignKey(i => i.PromoSliderId)
                    .IsRequired();
        }

        #endregion
    }
}
