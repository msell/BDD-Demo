using Headspring;

namespace CreditCardServices.Core.Models
{
    public class CreditRating : Enumeration<CreditRating, int>
    {
        public static readonly CreditRating Excellent = new CreditRating(6, "Excellent", 760, 850, true);
        public static readonly CreditRating VeryGood = new CreditRating(5,"Very Good",700, 759, true);
        public static readonly CreditRating Good = new CreditRating(4, "Good", 660, 669, true);
        public static readonly CreditRating Fair = new CreditRating(3, "Fair", 620, 659, true);
        public static readonly CreditRating Poor = new CreditRating(2, "Poor", 580, 619, false);
        public static readonly CreditRating VeryPoor = new CreditRating(1, "Very Poor", 0, 579, false);

        public CreditRating(int value, string displayName,int lowerBoundary, int upperBoundary, bool qualified) 
            : base(value, displayName)
        {
            UpperBoundary = upperBoundary;
            LowerBoundary = lowerBoundary;
            Qualified = qualified;
        }

        public int UpperBoundary { get; set; }
        public int LowerBoundary { get; set; }
        public bool Qualified { get; set; }

        public static CreditRating FromScore(int score)
        {
            if (score >= Excellent.LowerBoundary)
                return Excellent;
            if (score >= VeryGood.LowerBoundary)
                return VeryGood;
            if (score >= Good.LowerBoundary)
                return Good;
            if (score >= Fair.LowerBoundary)
                return Fair;
            if (score >= Poor.LowerBoundary)
                return Poor;

            return VeryPoor;
        }
    }
}
