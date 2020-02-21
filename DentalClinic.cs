using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DentalConsoleApp
{
    class DentalClinic
    {

        private AppointmentList appointments;
        private PatientList patientList;
        public string ClinicName;

        public DentalClinic()
        {

        }

        public DentalClinic(string clinicName)
        {
            ClinicName = clinicName;
            appointments = new AppointmentList();
            patientList = new PatientList();
        }

        public void Schedule(Appointment appointment)
        {
            if (IsSlotAvailable(appointment))
            {
                AskServicesAndAssign(appointment);
                appointments.AddAppointment(appointment);
                Console.WriteLine("Total Appointments :" + appointments.Count);
            }
            else
            {
                Console.WriteLine("Sorry {0} slot is already occupied, please choose different", appointment.AppointmentTimeSlot);
            }
        }

        // TODO :: prevent from adding same service twice
        private void AskServicesAndAssign(Appointment appointment)
        {
            var services = GetDentalServiceList();
            DentalServicesEnum service;

            int input = 0;

            do
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine("What service would you like");
                Console.WriteLine("----------------------------");

                for (int i = 0; i < services.Length; i++)
                {

                    var enumType = typeof(DentalServicesEnum);
                    var memberInfos = enumType.GetMember(services[i].ToString());
                    var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
                    var valueAttributes =
                          enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    var description = ((DescriptionAttribute)valueAttributes[0]).Description;
                    Console.WriteLine("{0}. {1}", (i + 1), description);
                }

                Console.WriteLine("---------------------------");
                Console.WriteLine("0. Finish");
                try
                {
                    Console.Write("your option ->");
                    input = int.Parse(Console.ReadLine());
                    service = (DentalServicesEnum)input;
                    bool isAdded = false;

                    switch (service)
                    {
                        case DentalServicesEnum.NONE:
                            break;
                        case DentalServicesEnum.CLEARNING:
                            appointment.ProcessAppointment += appointment.Patient.Cleaning;

                            isAdded = true;
                            break;
                        case DentalServicesEnum.CAVITY_FILL:
                            appointment.ProcessAppointment += appointment.Patient.CavityFill;

                            isAdded = true;

                            break;
                        case DentalServicesEnum.CHECK_UP:
                            appointment.ProcessAppointment += appointment.Patient.CheckUp;

                            isAdded = true;

                            break;
                        case DentalServicesEnum.X_RAY:
                            appointment.ProcessAppointment += appointment.Patient.XRay;

                            isAdded = true;

                            break;
                        case DentalServicesEnum.FITTING:
                            appointment.ProcessAppointment += appointment.Patient.Fittings;

                            isAdded = true;

                            break;
                    }
                    if (isAdded)
                    {
                        isAdded = false;
                        Console.WriteLine("\n\n" + GetServiceDescription(service) +
                        "  service added. \n\n");
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Service is not available");
                }

            } while (input != 0);
        }

        private bool IsSlotAvailable(Appointment appointment)
        {
            foreach (var a in appointments.All())
            {
                if (a.AppointmentTimeSlot == appointment.AppointmentTimeSlot)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckAvailability(TimeSlot slot)
        {
            foreach (var a in appointments.All())
            {
                if (a.AppointmentTimeSlot == slot ||
                    a.AppointmentTimeSlot == TimeSlot.NONE)
                {
                    return false;
                }
            }
            return true;
        }

        public TimeSlot[] GetAvailableTimeSlots()
        {
            List<TimeSlot> availableTimeSlots = new List<TimeSlot>();

            foreach (TimeSlot slot in Enum.GetValues(typeof(TimeSlot)))
            {

                if (CheckAvailability(slot))
                {
                    if (slot != TimeSlot.NONE)
                    {
                        availableTimeSlots.Add(slot);
                    }
                }
            }
            return availableTimeSlots.ToArray();
        }

        private void BookAppointmentSlot(Appointment appointment)
        {

        }

        public void DisplayAppointmemts()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No Appointment so far, Please book an Appointment");
            }
            else
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    Console.WriteLine(appointments[i].ToString());
                }
            }

        }

        public void DisplayAppointment(Appointment appointment)
        {
            Console.WriteLine(appointment.ToString());
        }

        public void PerformSchedule()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No Appointment so far, Please book an Appointment");
            }
            else
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    appointments[i].ProcessAppointment();
                }
            }
        }

        public void PerformSchedule(Appointment appointment)
        {
            appointment.ProcessAppointment();
        }

        public void DisplayAndPerformSchedule()
        {
            if (appointments.Count == 0)
            {
                Console.WriteLine("No Appointment so far, Please book an Appointment");
            }
            else
            {
                for (int i = 0; i < appointments.Count; i++)
                {
                    DisplayAppointment(appointments[i]);
                    PerformSchedule(appointments[i]);
                    Console.WriteLine("-------------------------");
                }
            }
        }

        public void GeneratePatients()
        {

            patientList.Add(new Childern(new Person("Abdulkaiyum", "shaikh", Gender.MALE, new DateTime(2005, 06, 13), "3861958249")));
            patientList.Add(new Adult(new Person("sunny", "patel", Gender.MALE, new DateTime(1992, 06, 13), "9356070775")));
            patientList.Add(new Senior(new Person("sree", "ba", Gender.FEMALE, new DateTime(1960, 06, 13), "7515829410")));
            patientList.Add(new Childern(new Person("khushbu", "soni", Gender.FEMALE, new DateTime(2010, 06, 13), "2392257448")));
            patientList.Add(new Childern(new Person("Aayushi", "mali", Gender.FEMALE, new DateTime(2012, 06, 13), "9149773176")));
            patientList.Add(new Adult(new Person("Mark", "Zukerburg", Gender.MALE, new DateTime(1990, 04, 12), "8511029729")));
            patientList.Add(new Adult(new Person("Mark", "Zukerburg", Gender.MALE, new DateTime(1995, 01, 10), "8532189771")));
            patientList.Add(new Senior(new Person("Steven", "Willson", Gender.MALE, new DateTime(1995, 01, 10), "4252733833")));
            patientList.Add(new Childern(new Person("Alica", "Carter", Gender.FEMALE, new DateTime(2014, 09, 21), "3104188844")));
            patientList.Add(new Adult(new Person("Tena", "Desuza", Gender.FEMALE, new DateTime(1989, 02, 08), "3104188844")));

        }

        public void ListPatients()
        {
            for (int i = 0; i < patientList.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "]");
                Console.WriteLine(patientList[i].ToString());
                Console.WriteLine("+++++++++++++++++++++++++");
            }
        }

        public Person GetPatient(int i)
        {
            return patientList[i];
        }

        public Person[] GetPatientAll()
        {
            return patientList.All();
        }

        public DentalServicesEnum[] GetDentalServiceList()
        {
            List<DentalServicesEnum> dentalServices = new List<DentalServicesEnum>();

            foreach (DentalServicesEnum service in Enum.GetValues(typeof(DentalServicesEnum)))
            {
                if (service != DentalServicesEnum.NONE)
                    dentalServices.Add(service);
            }
            return dentalServices.ToArray();
        }

        private string GetServiceDescription(DentalServicesEnum service)
        { 
            // TODO :: Extract method to resulability
            var enumType = typeof(DentalServicesEnum);
            var memberInfos = enumType.GetMember(service.ToString());
            var enumValueMemberInfo = memberInfos.FirstOrDefault(m => m.DeclaringType == enumType);
            var valueAttributes =
                  enumValueMemberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var description = ((DescriptionAttribute)valueAttributes[0]).Description;
            return description;

        }
    }

}