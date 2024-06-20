namespace watchShopApi.Core
{
    public interface ISendEmail
    {

        void SendEmail(string to, string subject, string body);


    }
}
