namespace TenantService.Domain.Entities;

public class Plan {
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Identifier { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsActive { get; set; } = true;
	public bool IsCustom { get; set; } = false;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

	public List<PlanFeature>? PlanFeatures { get; set; }
	public List<Pricing> Pricings { get; set; } = [];
	public List<Subscription>? Subscriptions { get; set; }
}
