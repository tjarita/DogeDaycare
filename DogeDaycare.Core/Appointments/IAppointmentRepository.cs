using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogeDaycare.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment,long>
    {
        List<Appointment> GetAllAppointmentsPerOwner(long? IdOwner);

    }
}
