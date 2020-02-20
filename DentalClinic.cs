using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class DentalClinic
    {
        public string ClinicName;
        private readonly AppointmentList appointments;
        private int NoOfSlots = 8;
        private List<TimeSlot> appointmentSlots = new List<TimeSlot>();


        public DentalClinic()
        {

        }

        public DentalClinic(string clinicName)
        {
            ClinicName = clinicName;
        }

        public void Schedule(Appointment appointment)
        {
            if(IsSlotAvailable(appointment))
            {
                appointments.AddAppointment(appointment);


                BookAppointmentSlot(appointment);

                appointment.ProcessAppointment();
            }
            else
            {
                Console.WriteLine("Sorry {0} slot is already occupied, please choose different",appointment.AppointmentTimeSlot);
            }
           
        }

        private bool IsSlotAvailable(Appointment appointment)
        {
            return appointmentSlots.Contains(appointment.AppointmentTimeSlot);
        }

        private void BookAppointmentSlot(Appointment appointment)
        {
            appointmentSlots.Add(appointment.AppointmentTimeSlot);
            Console.WriteLine(" {0} slot is Added Successfully",appointment.AppointmentTimeSlot);
        }
    }
}
