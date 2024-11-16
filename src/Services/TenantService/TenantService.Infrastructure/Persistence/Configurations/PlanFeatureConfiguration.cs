using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class PlanFeatureConfiguration : IEntityTypeConfiguration<PlanFeature> {
	public void Configure(EntityTypeBuilder<PlanFeature> builder) {
		builder.ToTable("PlanFeatures", TenantDbContext.DEFAULT_SCHEMA);
		builder.HasKey(pf => pf.Id);

		builder.Property(pf => pf.Id).HasColumnName("id");
		builder.Property(pf => pf.PlanId).IsRequired().HasColumnName("plan_id");
		builder.Property(pf => pf.FeatureId).IsRequired().HasColumnName("feature_id");
		builder.Property(pf => pf.LimitValue).HasColumnName("limit_value");
		builder.Property(pf => pf.IsUnlimited).HasColumnName("is_unlimited");

		builder.HasOne(pf => pf.Plan)
			   .WithMany(p => p.PlanFeatures)
			   .HasForeignKey(pf => pf.PlanId)
			   .OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(pf => pf.Feature)
			   .WithMany(f => f.PlanFeatures)
			   .HasForeignKey(pf => pf.FeatureId)
			   .OnDelete(DeleteBehavior.Cascade);

		// PlanFeature data
		builder.HasData(
			// Plan Básico
			new PlanFeature { Id = 1, PlanId = 1, FeatureId = 1, LimitValue = 5, IsUnlimited = false },
			new PlanFeature { Id = 2, PlanId = 1, FeatureId = 2, LimitValue = 500, IsUnlimited = false },
			new PlanFeature { Id = 3, PlanId = 1, FeatureId = 3, LimitValue = null, IsUnlimited = false },
			new PlanFeature { Id = 4, PlanId = 1, FeatureId = 4, LimitValue = 2, IsUnlimited = false },
			// Plan Estándar
			new PlanFeature { Id = 5, PlanId = 2, FeatureId = 1, LimitValue = 10, IsUnlimited = false },
			new PlanFeature { Id = 6, PlanId = 2, FeatureId = 2, LimitValue = 1000, IsUnlimited = false },
			new PlanFeature { Id = 7, PlanId = 2, FeatureId = 3, LimitValue = null, IsUnlimited = false },
			new PlanFeature { Id = 8, PlanId = 2, FeatureId = 4, LimitValue = 5, IsUnlimited = false },
			// Plan Premium
			new PlanFeature { Id = 9, PlanId = 3, FeatureId = 1, LimitValue = 20, IsUnlimited = false },
			new PlanFeature { Id = 10, PlanId = 3, FeatureId = 2, LimitValue = null, IsUnlimited = true },
			new PlanFeature { Id = 11, PlanId = 3, FeatureId = 3, LimitValue = null, IsUnlimited = true },
			new PlanFeature { Id = 12, PlanId = 3, FeatureId = 4, LimitValue = null, IsUnlimited = true }
		);
	}
}
