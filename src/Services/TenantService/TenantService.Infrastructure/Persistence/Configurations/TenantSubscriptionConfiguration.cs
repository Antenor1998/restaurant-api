using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantService.Domain.Entities;
using TenantService.Infrastructure.Persistence.Context;

namespace TenantService.Infrastructure.Persistence.Configurations;

public class TenantSubscriptionConfiguration : IEntityTypeConfiguration<TenantSubscription> {
	public void Configure(EntityTypeBuilder<TenantSubscription> builder) {
		builder.ToTable("TenantsSubscriptions", TenantDbContext.BILLING_SCHEMA, t => t.ExcludeFromMigrations());

		builder.HasKey(s => s.Id);
		
		builder.Property(a => a.Id).HasColumnName("id");
		builder.Property(s => s.TenantId).HasColumnName("tenant_id");
		builder.Property(s => s.PlanId).HasColumnName("plan_id");
		builder.Property(x => x.Interval).HasColumnName("interval");
		builder.Property(s => s.Status).HasColumnName("status");
		builder.Property(s => s.StartDate).HasColumnName("start_date");
		builder.Property(s => s.EndDate).HasColumnName("end_date");
		builder.Property(s => s.TrialEndsAt).HasColumnName("trial_ends_at");
		builder.Property(s => s.AutoRenewal).HasColumnName("auto_renewal");
		builder.Property(s => s.TotalAmount).HasColumnName("total_amount");
		builder.Property(s => s.Currency).HasColumnName("currency");
		builder.Property(s => s.IsActive).HasColumnName("is_active");

		builder.HasOne(s => s.Plan)
			   .WithMany(p => p.TenantSubscriptions)
			   .HasForeignKey(s => s.PlanId)
			   .OnDelete(DeleteBehavior.Cascade);

		// Subscription data
		builder.HasData(
			// new Subscription { Id = 1, TenantId = 1, PlanId = 1, Interval = "monthly", Status = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), TrialEndsAt = null, AutoRenewal = true, TotalAmount = 100, Currency = "MXM", IsActive = true }
		);
	}
}
