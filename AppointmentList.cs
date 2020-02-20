using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class AppointmentList
    {
        private List<Appointment> appointments;

        public AppointmentList()
        {
            appointments = new List<Appointment>();
        }

        public int Count
        {
            get { return appointments.Count; }
        }

        public Appointment this[int i]
        {
            get { return appointments[i]; }
            set { appointments[i] = value; }
        }

        #region PUBLIC API

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }
        //TODO:: Remove apppoint from appointments
        public void CancleAppointment(Appointment appointment)
        {
            
        }

        #endregion
    }
}
