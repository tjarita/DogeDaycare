using Abp.Domain.Entities;
using DogeDaycare.Persons;
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
    public class Appointment : Entity<Guid>
    {
        public virtual Person Owner { get; set; }
        public virtual List<Animals.Animal> Pets { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }

        public Appointment()
        {
            Id = Guid.NewGuid();
        }
    }
}
