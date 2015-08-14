using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Appointments
{
    public interface IAppointment
    {
        Guid IdAppointment { get; set; }
        Guid IdOWner { get; set; }
        List<Animals.Animal> Pets { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
    }
}
