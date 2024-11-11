namespace BillingService.Domain.Entities;

public class Invoice {
	public int Id { get; set; }
	public string? InvoiceNumber { get; set; }
	public decimal Amount { get; set; }
	public DateTime DueDate { get; set; }
	public DateTime CreatedAt { get; set; }
	public int Status { get; set; }
	public int TenantId { get; set; }
	// public Tenant Tenant { get; set; }
}
