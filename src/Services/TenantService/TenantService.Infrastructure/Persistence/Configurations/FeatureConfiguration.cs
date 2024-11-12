using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature> {
	public void Configure(EntityTypeBuilder<Feature> builder) {
		builder.ToTable("Features");

		builder.HasKey(f => f.Id).HasName("id");
		builder.Property(f => f.Name).IsRequired().HasColumnName("name");
		builder.Property(f => f.Description).HasColumnName("description");
		builder.Property(f => f.Identifier).HasColumnName("identifier");
		builder.Property(f => f.CreatedAt).HasColumnName("created_at");
		builder.Property(f => f.UpdatedAt).HasColumnName("updated_at");

		builder.HasMany(f => f.PlanFeatures)
				.WithOne(pf => pf.Feature)
				.HasForeignKey(pf => pf.FeatureId);

		builder.HasMany(f => f.AddOnFeatures)
				.WithOne(aof => aof.Feature)
				.HasForeignKey(aof => aof.FeatureId);

		// AddOn data
		builder.HasData(
			new Feature { Id = 1, Name = "Usuarios", Description = "Número máximo de usuarios que pueden acceder al sistema", Identifier = "USERS", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
			new Feature { Id = 2, Name = "Almacenamiento", Description = "Espacio de almacenamiento en disco", Identifier = "STORAGE", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
			new Feature { Id = 3, Name = "Soporte", Description = "Soporte técnico", Identifier = "SUPPORT", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
			new Feature { Id = 4, Name = "Sucursales", Description = "Número máximo de sucursales que pueden gestionar", Identifier = "BRANCHES", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now }
		);
	}
}
