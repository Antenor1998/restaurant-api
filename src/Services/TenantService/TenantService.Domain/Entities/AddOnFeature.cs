namespace TenantService.Domain.Entities;

public class AddOnFeature {
	public int AddOnId { get; set; }
	public int FeatureId { get; set; }
	public int? IncrementValue { get; set; }

	public AddOn? AddOn { get; set; }
	public Feature? Feature { get; set; }
}
