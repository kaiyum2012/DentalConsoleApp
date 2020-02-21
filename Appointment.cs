using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DentalConsoleApp
{
    public enum TimeSlot{
         NONE = 0,
        _08AM_TO_09AM_ = 1,
        _09AM_TO_10AM_,
        _10AM_TO_11AM_,
        _11AM_TO_12AM_,
        _12AM_TO_01PM_,
        _01PM_TO_02PM_,
        _02PM_TO_03PM_,
        _03PM_TO_04PM_
    }

    class Appointment : IComparable<Appointment>
    {
        public TimeSlot AppointmentTimeSlot;
      
        public delegate void ProcessAppointmentDelegate();
        public ProcessAppointmentDelegate ProcessAppointment;

        private DateTime appointmentDate;
        private Person patient;

        public DateTime AppointmentDay
        {
            get { return appointmentDate.Date; }
            set
            {
                appointmentDate = value;
            }
        }

        public Person Patient
        {
            get { return patient; }
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
        }

        public override string ToString()
        {
            return "[ " + this.AppointmentTimeSlot.ToString() +" ]\n" 
                + this.patient.ToString(); //+ "(" + this.patient.PatientNumber + ")";
        }

        public int CompareTo([AllowNull] Appointment other)
        {
            if (other == null)
                return 0;

            if(this.patient.PatientNumber == other.patient.PatientNumber &&
                this.AppointmentTimeSlot == other.AppointmentTimeSlot)
            {
                return 1;
            }

            return 0;
        }
    }
}
