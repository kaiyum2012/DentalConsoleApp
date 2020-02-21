using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class AppointmentList
    {
        private List<Appointment> appointments;
        //private List<TimeSlot> appointmentSlots = new List<TimeSlot>();
        public AppointmentList()
        {
            appointments = new List<Appointment>();
        }


        #region PUBLIC API
        public int Count
        {
            get { return appointments.Count; }
        }

        public Appointment this[int i]
        {
            get { return appointments[i]; }
            set { appointments[i] = value; }
        }

        public Appointment[] All()
        {
            return appointments.ToArray();
        }

        public void AddAppointment(Appointment appointment)
        {

            appointments.Add(appointment);
            //appointmentSlots.Add(appointment.AppointmentTimeSlot);

            Console.WriteLine("\n\n{0}({1}) is Added Successfully with time {2}", appointment.Patient.FirstName, appointment.Patient.PatientNumber, appointment.AppointmentTimeSlot);
        }
        //TODO:: Remove apppoint from appointments
        public void CancleAppointment(Appointment appointment)
        {

        }
        #endregion
    }
}
