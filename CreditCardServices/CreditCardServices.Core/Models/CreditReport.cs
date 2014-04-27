using System;

namespace CreditCardServices.Core.Models
{
    public class CreditReport
    {
        public Guid CreditApplicationId { get; set; }
        public int CreditScore { get; set; }
        public bool Bankruptcy { get; set; }
    }
}