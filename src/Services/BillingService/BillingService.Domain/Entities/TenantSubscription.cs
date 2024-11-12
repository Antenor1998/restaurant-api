namespace BillingService.Domain.Entities;

public class TenantSubscription {
	public int Id { get; set; }
    public int TenantId { get; set; }
    public int PlanId { get; set; }
    public string Interval { get; set; } = "monthly";
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime? EndDate { get; set; }
    public DateTime? NextBillingDate { get; set; }
    public DateTime? TrialEndsAt { get; set; }
    public bool AutoRenewal { get; set; } = true;
    public string Status { get; set; } = "Active";
    public decimal TotalAmount { get; set; }
    public string Currency { get; set; } = "USD";
    public int ExtraUsers { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public Tenant? Tenant { get; set; }
    public Plan? Plan { get; set; }
}
