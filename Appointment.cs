using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    public enum TimeSlot{
        _08AM_09AM_ = 1,
        _09AM_10AM_,
        _10AM_11AM_,
        _11AM_12AM_,
        _12AM_01PM_,
        _01PM_02PM_,
        _02PM_03PM_,
        _03PM_04PM_
    }

    
    class Appointment
    {
        public TimeSlot AppointmentTimeSlot;
        private DateTime appointmentDate;
        public delegate void ProcessAppointmentDelegate();
        public ProcessAppointmentDelegate ProcessAppointment;


        private Person patient;


        public DateTime AppointmentDay
        {
            get { return appointmentDate.Date; }
            set
            {
                appointmentDate = value;
            }
        }

        public Appointment(){ }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person">Patient </param>
        /// <param name="slot">Appoint Time Slot</param>
        public Appointment(Person person, TimeSlot slot)
        {
            patient = person;
            AppointmentTimeSlot = slot;

            ProcessAppointment += patient.CheckUp;
            ProcessAppointment += patient.Cleaning;
            ProcessAppointment += patient.CavityFill;
            ProcessAppointment += patient.Fittings;
            ProcessAppointment += patient.XRay;    
        }




    }
}
