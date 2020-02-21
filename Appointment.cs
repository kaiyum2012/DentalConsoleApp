using System;
using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DentalConsoleApp
{
    public enum TimeSlot{
        [Description("NO SLOT")]
        NONE = 0,
         [Description("08 AM TO 09 AM")]
        _08AM_TO_09AM_ = 1,
        [Description("09 AM TO 10 AM")]
        _09AM_TO_10AM_,
        [Description("10 AM TO 11 AM")]
        _10AM_TO_11AM_,
        [Description("11 AM TO 12 Noon")]
        _11AM_TO_12AM_,
        [Description("12 Noon TO 01 PM")]
        _12AM_TO_01PM_,
        [Description("01 PM TO 02 PM")]
        _01PM_TO_02PM_,
        [Description("02 PM TO 03 PM")]
        _02PM_TO_03PM_,
        [Description("03 PM TO 04 PM")]
        _03PM_TO_04PM_
    }

    class Appointment
    {
        private TimeSlot appointmentTimeSlot;

        public delegate void ProcessAppointmentDelegate();
        public ProcessAppointmentDelegate ProcessAppointment;

        private DateTime appointmentDate;
        private readonly Person patient;

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

        public TimeSlot AppointmentTimeSlot
        {
            get
            {
                return appointmentTimeSlot;
            }

            set
            {
                appointmentTimeSlot = value;
            }
        }

        private Appointment(){ }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="person">Patient </param>
        /// <param name="slot">Appoint Time Slot</param>
        public Appointment(Person person, TimeSlot slot)
        {
            patient = person;
            appointmentTimeSlot = slot; 
        }

        public override string ToString()
        {
            return "[ " + GetAppointmentTimeSlotStr() +" ]  " 
                + this.patient.ToString(); //+ "(" + this.patient.PatientNumber + ")";
        }

        private string GetAppointmentTimeSlotStr()
        {
            var enumType = typeof(TimeSlot);
            var memberInfos = enumType.GetMember(appointmentTimeSlot.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                  enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)valueAttributes[0]).Description;
            return description;
        }
    }
}
