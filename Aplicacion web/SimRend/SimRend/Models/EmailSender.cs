using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SimRend.Models
{
    public class EmailSender
    {
        private static string user = "yorch5.77@gmail.com";
        private static string pass = "Yorch0892";

        public static void Send(string to, string Subject, string body)
        {
            MailMessage o = new MailMessage(user, to,Subject, body);

            NetworkCredential netCred = new NetworkCredential(user, pass);
            SmtpClient cliente = new SmtpClient("smtp.gmail.com", 587);
            cliente.EnableSsl = true;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = netCred;
            cliente.Send(o);
        }
    }
}