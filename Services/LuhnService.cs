using CreditCardAPI.Models;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace CreditCardAPI.Services
{
    public class LuhnService : ILuhnService
    {
        public CreditCardResp IsValid(string cardNumber)
        {

            CreditCardResp resp = new CreditCardResp();

            if(string.IsNullOrEmpty(cardNumber))
            {
                resp.IsValid = false;
                resp.RespMessage = "Card Number is Empty";
                return resp;
            }

            var cleanedCardNumber = Regex.Replace(cardNumber, @"[\s-]", "");

            if (!cleanedCardNumber.All(char.IsDigit))
            {
                resp.IsValid = false;
                resp.RespMessage = "Card Number contains characters";
                return resp;
            }

            int sum = 0;
            bool counter = false;

            for (int i = cleanedCardNumber.Length - 1; i >= 0; i--)
            {

                int num = cleanedCardNumber[i] - '0';

                if (counter)
                {
                    num = num * 2;
                    if (num > 9) 
                        num = num - 9;
                }

                sum = sum + num;
                counter = !counter;
            }


            if (sum % 10 == 0)
            {
                resp.IsValid = true;
                resp.RespMessage = "Valid Credit Card Number";
                return resp;
            }

            else
            {
                resp.IsValid = false;
                resp.RespMessage = "Invalid Credit Card Number";
                return resp;
            }
        }
    }
}
