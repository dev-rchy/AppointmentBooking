using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AppointmentBooking.AppointmentService;
using AppointmentBooking.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    { 

        private readonly ILogger<AppointmentController> _logger;
        private readonly IAppointementRepository _appointmentService;

        public AppointmentController(
            ILogger<AppointmentController> logger,
            IAppointementRepository appointmentService
            )
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public Dictionary<int, List<Appointment>> Get()
        {
            return _appointmentService.GetAllStaffRecord();
        }

        [Route("Appointment/slot/{staffId?}")]
        public int getSlotId(int staffId)
        {
             
            var data = _appointmentService.GetAllStaffRecord();
            if (data.ContainsKey(staffId))
            {
                var id = data[staffId].FirstOrDefault(x => !x.Status).SlotId;

                //for handeling concurrency we can use Etag and than match it with if-match in header to handel with concurrency.
                data[staffId].Where(x => x.SlotId == id).Select(x => x.Status = true);

                _logger.LogInformation("status of slot with id " + id + "changed");

                return id;
            } else
            {
                _logger.LogError("Staff id " + staffId + "is not available");

                // ideally this should be the responsibility of custome exception class to catter with single responsibility principal.
                throw new InvalidDataException("Not A valid staff id");
            }


        }
    }
}
