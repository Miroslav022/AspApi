﻿namespace watchShopApi.Core
{
    public interface ISendEmail
    {

        Task SendEmailAsync(string email, string subject, string message);


    }
}
