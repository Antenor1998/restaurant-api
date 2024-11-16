namespace TenantService.Domain.Entities;

public class TenantSubscription {
	public int Id { get; set; }
	public int TenantId { get; set; }
	public int PlanId { get; set; }
	public string Interval { get; set; } = "monthly";
	public int Status { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime? EndDate { get; set; }
	public DateTime? TrialEndsAt { get; set; }
	public bool AutoRenewal { get; set; } = true;
	public decimal TotalAmount { get; set; }
	public string Currency { get; set; } = "MXN";
	public bool IsActive { get; set; } = true;

	public virtual Plan? Plan { get; set; }
	public virtual Tenant? Tenant { get; set; }
}
