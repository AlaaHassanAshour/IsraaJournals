namespace IsraaJournals.Services.Email
{
    public interface IMailHelper
    {
       // void SendEmail(InputEmailMessage inputEmailMessage);
        Task SendEmailAsync(InputEmailMessage inputEmailMessage);
    }
}
