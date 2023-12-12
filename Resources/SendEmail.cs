using BackSmartTalent.DTOs;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace BackSmartTalent.Resources
{
    public class SendEmail
    {
        public void Main(InsertBookingDTO insertBooking)
        {
            Execute(insertBooking).Wait();
        }

        static async Task Execute(InsertBookingDTO insertBooking)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("quinterojorge1234@gmail.com", "Jorge Quintero");
            var to = new EmailAddress(insertBooking.GuestsDTO.EmailDTO, insertBooking.GuestsDTO.NamesDTO);
            var subject = "Booking Confirmation";
            var plainTextContent = $"My dear {insertBooking.GuestsDTO.NamesDTO}, your reservation has been confirmed for the dates {insertBooking.EntryDateDTO} - {insertBooking.DepartureDateDTO}.";
            var htmlContent = $"<p>My dear {insertBooking.GuestsDTO.NamesDTO}, your reservation has been confirmed for the dates {insertBooking.EntryDateDTO} - {insertBooking.DepartureDateDTO}</p>.";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
