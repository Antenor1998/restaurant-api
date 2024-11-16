namespace TenantService.Domain.Entities;

public class Feature {
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Identifier { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

	public virtual ICollection<PlanFeature>? PlanFeatures { get; set; }
    public virtual ICollection<AddOnFeature>? AddOnFeatures { get; set; }
}
