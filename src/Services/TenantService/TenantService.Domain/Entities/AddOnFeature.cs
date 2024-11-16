namespace TenantService.Domain.Entities;

public class AddOnFeature {
	public int Id { get; set; }
	public int AddOnId { get; set; }
	public int FeatureId { get; set; }
	public int? IncrementValue { get; set; }

	public virtual AddOn? AddOn { get; set; }
	public virtual Feature? Feature { get; set; }
}
