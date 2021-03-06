﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Emails
{
    [Table("EmailBodyReplacements")]
    public class EmailBodyReplacement : Entity<int>
    {
        [Required]
        public EmailTemplate EmailTemplate { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
