using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class PricingConfiguration : IEntityTypeConfiguration<Pricing> {
	public void Configure(EntityTypeBuilder<Pricing> builder) {
		 builder.ToTable("Pricings", TenantDbContext.DEFAULT_SCHEMA);
		 builder.HasKey(e => e.Id);
		 
		 builder.Property(e => e.Id).HasColumnName("id");
		 builder.Property(e => e.EntityId).IsRequired().HasColumnName("entity_id");
		 builder.Property(e => e.EntityType).IsRequired().HasColumnName("entity_type");
		 builder.Property(e => e.Interval).IsRequired().HasColumnName("interval");
		 builder.Property(e => e.Price).IsRequired().HasColumnName("price");
		 builder.Property(e => e.Currency).IsRequired().HasColumnName("currency");
		 builder.Property(e => e.DiscountPercentage).HasColumnName("discount_percentage");




		builder.HasData(
			new Pricing { Id = 1, EntityId = 1, EntityType = "Plan", Interval = "monthly", Price = 100, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 2, EntityId = 2, EntityType = "Plan", Interval = "monthly", Price = 200, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 3, EntityId = 3, EntityType = "Plan", Interval = "monthly", Price = 300, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 4, EntityId = 4, EntityType = "Plan", Interval = "monthly", Price = 400, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 5, EntityId = 1, EntityType = "Plan", Interval = "yearly", Price = 1000, Currency = "MXM", DiscountPercentage = 10 },
			new Pricing { Id = 6, EntityId = 2, EntityType = "Plan", Interval = "yearly", Price = 2000, Currency = "MXM", DiscountPercentage = 10 },
			new Pricing { Id = 7, EntityId = 3, EntityType = "Plan", Interval = "yearly", Price = 3000, Currency = "MXM", DiscountPercentage = 10 },
			new Pricing { Id = 8, EntityId = 4, EntityType = "Plan", Interval = "yearly", Price = 4000, Currency = "MXM", DiscountPercentage = 10 },

			new Pricing { Id = 9, EntityId = 1, EntityType = "AddOn", Interval = "monthly", Price = 10, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 10, EntityId = 2, EntityType = "AddOn", Interval = "monthly", Price = 20, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 11, EntityId = 3, EntityType = "AddOn", Interval = "monthly", Price = 30, Currency = "MXM", DiscountPercentage = 0 },

			new Pricing { Id = 12, EntityId = 1, EntityType = "AddOn", Interval = "yearly", Price = 100, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 13, EntityId = 2, EntityType = "AddOn", Interval = "yearly", Price = 200, Currency = "MXM", DiscountPercentage = 0 },
			new Pricing { Id = 14, EntityId = 3, EntityType = "AddOn", Interval = "yearly", Price = 300, Currency = "MXM", DiscountPercentage = 0 }
		);
	}
}
