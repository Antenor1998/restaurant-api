using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class AddOnFeatureConfiguration : IEntityTypeConfiguration<AddOnFeature> {
	public void Configure(EntityTypeBuilder<AddOnFeature> builder) {
		builder.ToTable("AddOnFeatures");
		// Llave compuesta
		builder.HasKey(af => new { af.AddOnId, af.FeatureId });

		builder.Property(af => af.AddOnId).IsRequired().HasColumnName("add_on_id");
		builder.Property(af => af.FeatureId).IsRequired().HasColumnName("feature_id");
		builder.Property(af => af.IncrementValue).HasColumnName("increment_value");


		builder.HasOne(af => af.AddOn)
			   .WithMany(a => a.AddOnFeatures)
			   .HasForeignKey(af => af.AddOnId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(af => af.Feature)
			   .WithMany(f => f.AddOnFeatures)
			   .HasForeignKey(af => af.FeatureId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasData(
			new AddOnFeature { AddOnId = 1, FeatureId = 1, IncrementValue = 1 },
			new AddOnFeature { AddOnId = 1, FeatureId = 2, IncrementValue = 1 },
			new AddOnFeature { AddOnId = 2, FeatureId = 1, IncrementValue = 1 }
		);
	}
}
