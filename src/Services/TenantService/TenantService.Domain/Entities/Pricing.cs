namespace TenantService.Domain.Entities;

public class Pricing {
	public int Id { get; set; }
	public int EntityId { get; set; }
	public string EntityType { get; set; } = string.Empty; // "Plan" o "AddOn"
	public string Interval { get; set; } = "monthly";
	public decimal Price { get; set; }
	public string Currency { get; set; } = "MXN";
	public int DiscountPercentage { get; set; }	
}
