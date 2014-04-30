#Business Rules

|Credit Rating|Lower Boundary|Upper Boundary|
|-------------|--------------|--------------|
|Excellent|760|850|
|Very Good|700|759|
|Good|660|669|
|Fair|620|659|
|Poor|580|619|
|Very Poor|0|579|

- Generally speaking we will issue credit cards to anybody with a credit rating greater than Fair
- Not authorized to issue credit cards in the state of Oklahoma
- We do not issue credit cards to people with Bankruptcy on file


Excellent = new CreditRating(6, "Excellent", 760, 850, true);
        public static readonly CreditRating VeryGood = new CreditRating(5,"Very Good",700, 759, true);
        public static readonly CreditRating Good = new CreditRating(4, "Good", 660, 669, true);
        public static readonly CreditRating Fair = new CreditRating(3, "Fair", 620, 659, true);
        public static readonly CreditRating Poor = new CreditRating(2, "Poor", 580, 619, false);
        public static readonly CreditRating VeryPoor = new CreditRating(1, "Very Poor", 0, 579, false);