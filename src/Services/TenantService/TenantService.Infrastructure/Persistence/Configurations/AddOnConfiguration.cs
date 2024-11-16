using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class AddOnConfiguration : IEntityTypeConfiguration<AddOn> {
	public void Configure(EntityTypeBuilder<AddOn> builder) {
		builder.ToTable("AddOns", TenantDbContext.DEFAULT_SCHEMA);

		builder.HasKey(a => a.Id);
		
		builder.Property(a => a.Id).HasColumnName("id");
		builder.Property(a => a.Name).IsRequired().HasColumnName("name");
		builder.Property(a => a.Identifier).HasColumnName("identifier");
		builder.Property(a => a.Description).HasColumnName("description");
		builder.Property(a => a.IsActive).HasColumnName("is_active");
		builder.Property(a => a.CreatedAt).HasColumnName("created_at");
		builder.Property(a => a.UpdatedAt).HasColumnName("updated_at");

	 	builder.HasMany(a => a.AddOnFeatures)
			   .WithOne(aof => aof.AddOn)
			   .HasForeignKey(aof => aof.AddOnId)
			   .OnDelete(DeleteBehavior.Cascade);


		// Add Data
		builder.HasData(
			new AddOn { Id = 1, Name = "Usuarios Adicionales", Identifier = "EXTRA_USER", Description = "Agrega más usuarios al sistema", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
			new AddOn { Id = 2, Name = "Sucursales Adicionales", Identifier = "EXTRA_BRANCH", Description = "Agrega más sucursales al sistema", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
			new AddOn { Id = 3, Name = "Almacenamiento Adicional", Identifier = "EXTRA_STORAGE", Description = "Agrega más almacenamiento al sistema", IsActive = true, CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
		);
	}
}
