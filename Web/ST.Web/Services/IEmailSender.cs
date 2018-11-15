﻿using System.Threading.Tasks;

namespace ST.Web.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}