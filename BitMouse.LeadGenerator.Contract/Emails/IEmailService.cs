﻿namespace BitMouse.LeadGenerator.Contract.Emails;

public interface IEmailService
{
    Task SendAsync(EmailDetailsDto details);
}
