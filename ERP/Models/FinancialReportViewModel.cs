using System.Collections.Generic;

namespace ERP.Models
{
    public class FinancialReportViewModel
    {
        public List<Transaction> Transactions { get; set; }
        public decimal TotalSum { get; set; }
    }
}