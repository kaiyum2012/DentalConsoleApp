using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class AppointmentList
    {
        private readonly List<Appointment> appointments;

        public AppointmentList()
        {
            appointments = new List<Appointment>();
        }


        #region PUBLIC API
       
        #region Indexer API
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
        #endregion

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);

            Console.WriteLine("\n\n{0}({1}) is Added Successfully with time slot [ {2} ]", appointment.Patient.FirstName, appointment.Patient.PatientNumber, EnumHelper.GetAttributeDescription(appointment.AppointmentTimeSlot));
        }

        //DONE:: Remove apppointment from appointments
        public void CancleAppointment(Appointment appointment)
        {
            appointments.Remove(appointment);
        }
        #endregion
    }
}
