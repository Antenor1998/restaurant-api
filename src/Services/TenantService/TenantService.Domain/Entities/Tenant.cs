namespace TenantService.Domain.Entities;

public class Tenant {
	public int Id { get; set; }
	public int SubscriptionId { get; set; }
	public string? Name { get; set; }
	public string? BusinessName { get; set; }
	public string? DatabaseConnectionString { get; set; }
	public int Status { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? TrialEndsAt { get; set; }

	public virtual ICollection<TenantSubscription>? Subscriptions { get; set; }
}
