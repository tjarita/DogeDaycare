using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using DogeDaycare.Animals;
using DogeDaycare.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Appointments
{
    [Table("Appointments")]
    public class Appointment : FullAuditedEntity<long>
    {
        public virtual User Owner { get; set; }
        public virtual Animal Pet { get; set; }
        public virtual DateTimeOffset Start { get; set; }
        public virtual DateTimeOffset End { get; set; }

        protected Appointment()
        {

        }

        public Appointment Create(User owner, Animal pet, DateTime start, DateTime end )
        {
            var @appointment = new Appointment() {
                Owner = owner,
                Pet = pet,
                Start = start, 
                End = end
            };
            return @appointment;
        }
    }
}
