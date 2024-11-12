namespace TenantService.Domain.Entities;

public class AddOn {
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Identifier { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsActive { get; set; } = true;
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

	public List<AddOnFeature>? AddOnFeatures { get; set; }
    public List<Pricing>? Pricings { get; set; }
}
