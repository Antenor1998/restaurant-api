namespace TenantService.Domain.Entities;

public class PlanFeature {
	public int Id { get; set; }
	public int PlanId { get; set; }
	public int FeatureId { get; set; }
	public int? LimitValue { get; set; }
	public bool IsUnlimited { get; set; } = false;

	public virtual Plan? Plan { get; set; }
	public virtual Feature? Feature { get; set; }
}
