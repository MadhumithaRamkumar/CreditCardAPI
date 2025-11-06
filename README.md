**Overview**

This project implements an API for credit card number validation using the Luhn algorithm. It accepts a credit card number as input (in string format) and returns a response indicating the validation status and related details of the card number.You can test the API directly using the Swagger UI once the application is running.

**FrameWorks**
1.  .Net 9 Framework - C# .NET Framework
2.  ASP.NET Web API
3.  Swagger / Swashbuckle

**SETUP INSTRUCTION**

1.  Open Visual Studio.
2.  Click on "Clone on repository".
3.  Paste the Git repo URL in the Repository location field.
4.  Choose a local path where the repo will be saved.
5.  Select Clone.
6.  Build and run the project. Swagger UI will launch automatically.
7.  Also clone the CreditCardAPI.test to the local path using the same above steps to run the unit test.

**Error Handling**

The API handles:

1.  Empty or null input
2.  Non-numeric characters
3.  Unexpected exceptions
