namespace TenantService.Domain.Entities;

public class Subscription {
	public int Id { get; set; }
	public int TenantId { get; set; }
	public decimal Amount { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime DueDate { get; set; }
	public bool IsActive { get; set; }

	public Tenant? Tenant { get; set; }
}
