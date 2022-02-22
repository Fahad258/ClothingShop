using clothingshopproject.Models;
using System.Threading.Tasks;

namespace clothingshopproject.Service
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);

        Task SendEmailForEmailConfirmation(UserEmailOptions userEmailOptions);


       Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}