using System;
using System.Collections.Generic;

namespace tickets_net_backend.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int TicketCategoryId { get; set; }

    public int? SumaBilete { get; set; }

    public decimal? ValoareTotala { get; set; }
}
