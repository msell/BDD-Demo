using System;

namespace CreditCardServices.Core.Models
{
    public class DecisionRequest
    {
        public DecisionRequest()
        {
            HomeAddress = new Address();
        }
        public Guid CreditApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Ssn { get; set; }
        public decimal Income { get; set; }
        public Address HomeAddress { get; set; }
    }
}