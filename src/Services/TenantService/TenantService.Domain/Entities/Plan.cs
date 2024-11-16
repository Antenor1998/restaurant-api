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

	public virtual ICollection<PlanFeature>? PlanFeatures { get; set; }
	public virtual ICollection<TenantSubscription>? TenantSubscriptions { get; set; }
}
