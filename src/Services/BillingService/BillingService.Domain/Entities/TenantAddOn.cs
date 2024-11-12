using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillingService.Domain.Entities;

public class TenantAddOn
{
	public int Id { get; set; }
    public int TenantSubscriptionId { get; set; }
    public int AddOnId { get; set; }
    public int Quantity { get; set; } = 1;
    public decimal TotalPrice { get; set; }
    public string Interval { get; set; } = "monthly";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public TenantSubscription? TenantSubscription { get; set; }
    public AddOn? AddOn { get; set; }

}
