using System;
using System.Collections.Generic;

namespace TicketsNetBackend.Models;

public partial class TotalNumberOfTicketsPerCategory
{
    public int TicketCategoryId { get; set; }

    public int? SumaBilete { get; set; }

    public decimal? ValoareTotala { get; set; }
}
