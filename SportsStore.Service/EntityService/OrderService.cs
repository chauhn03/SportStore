namespace SportsStore.Service.EntityService
{
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using SportsStore.Domain.Entities;
    using SportsStore.Service.Abstract;

    public class OrderService : IOrderService
    {
        private EmailSettings emailSettings;

        public OrderService(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shippingDetails)
        {

            SendEmailForNewOrder(cart, shippingDetails);
        }

        private void SendEmailForNewOrder(Cart cart, ShippingDetails shippingDetails)
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
