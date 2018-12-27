using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faker;
using Faker.Extensions;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Options;

namespace api.Controllers
{
    // Just use action name as route
    [Route("[action]")]
    public class GenerateController : Controller
    {
        private readonly MailServerConfig _mailServerConfig;

        public GenerateController(IOptions<MailServerConfig> mailServerConfig)
        {
            _mailServerConfig = mailServerConfig.Value;
        }

        [HttpPost]
        public async Task EmailRandomNames(Range range, string email = "test@fake.com")
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Generator", "generator@generate.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Hi Here are your random names";

            message.Body = new TextPart("plain")
            {
                Text = string.Join(Environment.NewLine, range.Of(Name.FullName))
            };
            using (var mailClient = new SmtpClient())
            {
                await mailClient.ConnectAsync(_mailServerConfig.Host, _mailServerConfig.Port, SecureSocketOptions.None);
                await mailClient.SendAsync(message);
                await mailClient.DisconnectAsync(true);
            }
        }

        [HttpGet]
        public IEnumerable<string> Names(Range range)
            => range.Of(Name.FullName);

        [HttpGet]
        public IEnumerable<string> PhoneNumbers(Range range)
            => range.Of(Phone.Number);

        [HttpGet]
        public IEnumerable<int> Numbers(Range range)
            => range.Of(RandomNumber.Next);

        [HttpGet]
        public IEnumerable<string> Companies(Range range)
            => range.Of(Company.Name);

        [HttpGet]
        public IEnumerable<string> Paragraphs(Range range)
            => range.Of(() => Lorem.Paragraph(3));

        [HttpGet]
        public IEnumerable<string> CatchPhrases(Range range)
            => range.Of(Company.CatchPhrase);

        [HttpGet]
        public IEnumerable<string> Marketing(Range range)
            => range.Of(Company.BS);

        [HttpGet]
        public IEnumerable<string> Emails(Range range)
            => range.Of(Internet.Email);

        [HttpGet]
        public IEnumerable<string> Domains(Range range)
            => range.Of(Internet.DomainName);
    }
}
