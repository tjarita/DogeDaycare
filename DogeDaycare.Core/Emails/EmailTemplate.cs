using Abp.Domain.Entities;
using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    [Table("EmailTemplates")]
    public class EmailTemplate : Entity<int>
    {
        [Required]
        public string Sender { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string BodyHTML { get; set; }


        /// <summary>
        /// Replacement IDs
        /// </summary>
        public virtual ICollection<EmailBodyReplacement> Replacements { get; set; }


        //public virtual ICollection<Attachment> Attachments { get; set; }

        protected EmailTemplate()
        {

        }

        public static EmailTemplate Create(
            string sender,
            string subject,
            string bodyHTML
            //,ICollection<EmailBodyReplacement> replacements
            )
        {
            // Create the template
            var @emailTemplate = new EmailTemplate
            {
                Sender = sender,
                Subject = subject,
                BodyHTML = bodyHTML,
                Replacements = new List<EmailBodyReplacement>()

            };

            //// Set parent class to this template
            //foreach(EmailBodyReplacement replacement in replacements)
            //{
            //    replacement.EmailTemplate = @emailTemplate;
            //}

            //// Add replacements
            //emailTemplate.Replacements = replacements;

            return @emailTemplate;
        }

        public void AddEmailBodyReplacement(string identifier, string description)
        {
            var replacement = new EmailBodyReplacement
            {
                Identifier = identifier,
                Description = description,
                EmailTemplate = this
            };
            Replacements.Add(replacement);
        }
    }
}
