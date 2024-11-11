namespace BillingService.Domain.Entities;

public class Payment {
	public int Id { get; set; }
	public string? PaymentNumber { get; set; }
	public decimal Amount { get; set; }
	public DateTime PaymentDate { get; set; }
	public DateTime CreatedAt { get; set; }
	public int Status { get; set; }
	public int InvoiceId { get; set; }
}
