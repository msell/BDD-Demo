#ACME credit card issuer.  We recieve credit card applications and based on the response from a credit bureau service and other business rules we decide whether or not to issue a credit card.

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
