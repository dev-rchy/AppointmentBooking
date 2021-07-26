using AppointmentBooking.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentBooking.AppointmentService
{
    //ideally this class should be in seprate project and reffered here in this project
    public class AppointmentRepository : IAppointementRepository
    {
        public  Dictionary<int, List<Appointment>> GetAllStaffRecord()
        {
            var result = new Dictionary<int, List<Appointment>>();
            result.Add(1, new List<Appointment> {
                          new Appointment() { Status = false , SlotId = 1},
                          new Appointment() { Status = false , SlotId = 2},
                          new Appointment() { Status = false , SlotId = 3},
                          new Appointment() { Status = false , SlotId = 4},
                          new Appointment() { Status = false , SlotId = 5}
            });
            result.Add(2, new List<Appointment> {
                          new Appointment() { Status = false , SlotId = 1},
                          new Appointment() { Status = false , SlotId = 2},
                          new Appointment() { Status = false , SlotId = 3},
                          new Appointment() { Status = false , SlotId = 4},
                          new Appointment() { Status = false , SlotId = 5}
            }
            );
            result.Add(3, new List<Appointment> {
                          new Appointment() { Status = false , SlotId = 1},
                          new Appointment() { Status = false , SlotId = 2},
                          new Appointment() { Status = false , SlotId = 3},
                          new Appointment() { Status = false , SlotId = 4},
                          new Appointment() { Status = false , SlotId = 5}
            }
           );

            return result;
        }

    }
}
