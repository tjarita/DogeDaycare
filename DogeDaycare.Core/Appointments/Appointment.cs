using Abp.Domain.Entities;
using DogeDaycare.Humans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Appointments
{
    public class Appointment : Entity<Guid>
    {
        public virtual Guid IdAppointment { get; set; }
        public virtual Person Owner { get; set; }
        public virtual List<Animals.Animal> Pets { get; set; }
        public virtual DateTime Start { get; set; }
        public virtual DateTime End { get; set; }


        public Appointment()
        {
            IdAppointment = Guid.NewGuid();
        }
    }
}
