using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class PlanConfiguration : IEntityTypeConfiguration<Plan> {
	public void Configure(EntityTypeBuilder<Plan> builder) {
		builder.ToTable("Plans", TenantDbContext.DEFAULT_SCHEMA);
		builder.HasKey(p => p.Id);
		
		builder.Property(p => p.Id).HasColumnName("id");
		builder.Property(p => p.Name).IsRequired().HasColumnName("name");
		builder.Property(p => p.Identifier).HasColumnName("identifier");
		builder.Property(p => p.Description).HasColumnName("description");
		builder.Property(p => p.IsActive).HasColumnName("is_active");
		builder.Property(p => p.IsCustom).HasColumnName("is_custom");
		builder.Property(p => p.CreatedAt).HasColumnName("created_at");
		builder.Property(p => p.UpdatedAt).HasColumnName("updated_at");

	   builder.HasMany(p => p.PlanFeatures)
			   .WithOne(pf => pf.Plan)
			   .HasForeignKey(pf => pf.PlanId)
			   .OnDelete(DeleteBehavior.Cascade);



		// Plan data
		builder.HasData(
			new Plan { Id = 1, Name = "Básico", Identifier = "BASIC", Description = "Plan básico", IsActive = true, IsCustom = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
			new Plan { Id = 2, Name = "Estándar", Identifier = "STANDARD", Description = "Plan estándar", IsActive = true, IsCustom = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
			new Plan { Id = 3, Name = "Premium", Identifier = "PREMIUM", Description = "Plan premium", IsActive = true, IsCustom = false, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
			new Plan { Id = 4, Name = "Personalizado", Identifier = "CUSTOM", Description = "Plan personalizado", IsActive = true, IsCustom = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
		);
	}
}
