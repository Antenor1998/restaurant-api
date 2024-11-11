using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class SubscriptionConfiguration : IEntityTypeConfiguration<Subscription> {
	public void Configure(EntityTypeBuilder<Subscription> builder) {

		builder.HasKey(s => s.Id);
		builder.Property(s => s.Amount).HasColumnType("decimal(18,2)");
		builder.Property(s => s.IsActive).HasDefaultValue(true);

		builder.HasOne(s => s.Tenant)
				.WithMany(t => t.Subscriptions)
				.HasForeignKey(s => s.TenantId);
	}
}
