namespace TenantService.Domain.Entities;

public class Tenant {
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Domain { get; set; }
	public int Status { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? TrialEndsAt { get; set; }

	public List<Subscription>? Subscriptions { get; set; }
}
