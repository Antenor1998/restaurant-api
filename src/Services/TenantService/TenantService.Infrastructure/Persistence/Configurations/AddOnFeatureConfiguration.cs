using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class AddOnFeatureConfiguration : IEntityTypeConfiguration<AddOnFeature> {
	public void Configure(EntityTypeBuilder<AddOnFeature> builder) {
		builder.ToTable("AddOnFeatures", TenantDbContext.DEFAULT_SCHEMA);
		builder.HasKey(af => af.Id);

		builder.Property(af => af.Id).HasColumnName("id");
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
			new AddOnFeature {Id = 1, AddOnId = 1, FeatureId = 1, IncrementValue = 1 },
			new AddOnFeature {Id = 2, AddOnId = 1, FeatureId = 2, IncrementValue = 1 },
			new AddOnFeature {Id = 3, AddOnId = 2, FeatureId = 1, IncrementValue = 1 }
		);
	}
}
