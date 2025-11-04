using CreditCardAPI.Models;

namespace CreditCardAPI.Services
{
    public interface ILuhnService
    {
        CreditCardResp IsValid(string cardNumber);
    }
}
