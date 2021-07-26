using AppointmentBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.AppointmentService
{
    public interface IAppointementRepository
    {
        Dictionary<int, List<Appointment>> GetAllStaffRecord();
    }
}
