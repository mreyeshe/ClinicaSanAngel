using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Mail
/// </summary>
public class Mail
{
    public Mail()
    {
       
        
        
    }
    public bool SendMail(string To)
    {
        bool IsSended=false;
        var fromAddress = new MailAddress("miguelangelreyesit@gmail.com", "Clinica San Angel");
        var toAddress = new MailAddress(To);
        const string fromPassword = "fromPassword";
        const string subject = "Bienvenido a Clinica San Angel";
        const string body = "plantilla";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body
        })
        {
            smtp.Send(message);
        }
        smtp.res
        return IsSended;
    }
}