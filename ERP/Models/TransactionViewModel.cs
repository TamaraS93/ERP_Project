using System;

namespace ERP.Models
{
    public class TransactionViewModel
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }

        public TransactionViewModel(int transactionId, DateTime transactionDate, decimal transactionAmount)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            TransactionAmount = transactionAmount;
        }
    }
}