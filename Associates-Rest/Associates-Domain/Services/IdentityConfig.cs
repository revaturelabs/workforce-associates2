﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace Associates_Domain.Services
{
  public class EmailService : IIdentityMessageService
  {
    /// <summary>
    /// This method will call the
    /// configSendEmailasync method
    /// so that an email can be sent
    /// to the designated person(s)
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public async Task SendAsync(IdentityMessage message)
    {
      await configSendEmailasync(message);
    }
    

    /// <summary>
    /// Email method to send emails to the
    /// designated person(s) using the
    /// Gmail settings we have in the Web.Config
    /// Class is private as only the SendAsync
    /// method needs to call/use it
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    private async Task configSendEmailasync(IdentityMessage message)
    {
      var email = new MailMessage();

      //formatting the email to be sent
      email.To.Add(message.Destination);
      email.From = new System.Net.Mail.MailAddress("revature@projectliberate.com", "Revature");
      email.Subject = message.Subject;
      email.Body = message.Body;
      email.IsBodyHtml = true;

      //smtp settings that we pull
      //from the app.config file
      System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
      {
        Host = ConfigurationManager.AppSettings["GmailHost"],
        Port = Int32.Parse(ConfigurationManager.AppSettings["GmailPort"]),
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(ConfigurationManager.AppSettings["GmailUserName"], ConfigurationManager.AppSettings["GmailPassword"])

      };
      
      //sends the email
      await smtp.SendMailAsync(email);
    }
  }
}