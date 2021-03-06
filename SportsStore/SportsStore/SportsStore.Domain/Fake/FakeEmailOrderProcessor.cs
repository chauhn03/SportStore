﻿
using System.Net;
using System.Net.Mail;
using System.Text;
using SportsStore.Domain.Abstract;
namespace SportsStore.Domain.Fake
{
    public class EmailSettings
    {
        public string MailToAddress = "chauhn.k28@gmail.com";
        public string MailFromAddress = "chauhn.k28@gmail.com";
        public bool UseSsl = true;
        public string Username = "chauhn.k28@gmail.com";
        public string Password = "Chau.Hoang86";
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\sports_store_emails";
    }

    public class FakeEmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;

        public FakeEmailOrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void ProcessOrder(Entities.Cart cart, Entities.ShippingDetails shippingDetails)
        {
            using (SmtpClient smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(emailSettings.Username, emailSettings.Password);

                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                                         .AppendLine("A new order has been submitted")
                                         .AppendLine("---")
                                         .AppendLine("Items:");

                foreach (var line in cart.GetItems())
                {
                    var subtotal = line.Product.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", line.Quantity,
                    line.Product.Name,
                    subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", cart.ComputeTotalValue())
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(shippingDetails.Name)
                .AppendLine(shippingDetails.Line1)
                .AppendLine(shippingDetails.Line2 ?? "")
                .AppendLine(shippingDetails.Line3 ?? "")
                .AppendLine(shippingDetails.City)
                .AppendLine(shippingDetails.State ?? "")
                .AppendLine(shippingDetails.Country)
                .AppendLine(shippingDetails.Zip)
                .AppendLine("---")
                .AppendFormat("Gift wrap: {0}",
                shippingDetails.GiftWrap ? "Yes" : "No");
                MailMessage mailMessage = new MailMessage(
                emailSettings.MailFromAddress, // From 
                emailSettings.MailToAddress, // To 
                "New order submitted!", // Subject 
                body.ToString()); // Body 
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(mailMessage);
            }
        }
    }
}
