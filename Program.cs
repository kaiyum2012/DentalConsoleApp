using System;
using System.Collections.Generic;
using Bogus;

namespace DentalConsoleApp
{

    class Program
    {

        

        //TODO:: setup app setup delegate To handle inial task require by App
        private delegate void SetupConsoleApp();

        private static SetupConsoleApp SetupTasks;
        //private static int patientCounter = 0;
        static readonly bool _debug = false; // is only for Development purpose so, to distiguish starts with "_"

        /* 
         * TODO:: Create a menu with four options:
         * List all people.This option will display each person and all its information. The patient number shouldbe displayed with the first three numbers replaced by Xs.
         * Create a schedule.This option will allow a user to create a schedule. For each schedule slot (8 slots, 1hour each, first slot being 8am-9am, the last slot being 3pm-4pm) select a person and a validoperation.You do not need to select the time slot, they can be done in order.Only one appointmentmay be scheduled in one slot.
         * Display the day's schedule. This should be done by iterating through the appointment schedule and"performing" the task required for each person.
         * Exit the program
         */

        public static void Menu()
        {
            Console.WriteLine("*************************************");
            Console.WriteLine("Please Choose Your option to proceed");
            Console.WriteLine("*************************************");
            Console.WriteLine("1. List all Patient(s)");
            Console.WriteLine("2. Create Schedule");
            Console.WriteLine("3. Display Today's Schedule");
            Console.WriteLine("0. Exit");

            Console.Write("Your choice -->");
        }

        enum MenuOptions
        {
            EXIT = 0,
            LIST,
            CREATE_SCHEDULE,
            DISPLAY_SCHEDULE,
           
        }
        static void Main(string[] args)
        {
            int input = 0;
            MenuOptions option = 0;
           
            DentalClinic clinic = new DentalClinic("ABC Dental Clinic");
            Console.WriteLine("Welcome to {0} Console App", clinic.ClinicName);

            //TODO:: Assign all init task to delegate
            SetupTasks += clinic.GeneratePatients;
            SetupTasks();

            do
            {
                //try
                //{
                    Menu();

                    input = GetIntInputFromConsole(_debug);
                    option = (MenuOptions) input;

                //}
                //catch (Exception e)
                //{
                   
                //}
                Console.Clear();
                //Console.WriteLine(option.ToString());
                switch (option)
                {
                    case MenuOptions.LIST:
                        clinic.ListPatients();
                        Console.WriteLine("\n\n");
                        break;
                    case MenuOptions.CREATE_SCHEDULE:
                        clinic.ListPatients();
                        Console.WriteLine("Enter 0 to Cancle\n\n");
                        Console.Write("Select Patient ---->");

                        var patient = GetPatientForAppointment(clinic);
                        var slot = GetAppointmentTimeSlot(clinic);

                        if(patient == null)
                        {
                            break;
                        }
                        else if(slot == TimeSlot.NONE)
                        {
                            Console.WriteLine("Sorry, we are full, Please book next day");
                        }
                        else if(patient != null && slot != TimeSlot.NONE)
                        {
                            clinic.Schedule(new Appointment(patient,slot));
                        }

                        break;
                    case MenuOptions.DISPLAY_SCHEDULE:
                        clinic.DisplayAndPerformSchedule();
                        break;
                    case MenuOptions.EXIT:
                        Console.WriteLine("Exiting Application, See you later" );
                        break;
                    default:
                        Console.WriteLine("it's not an option, Try again");
                        break;
                }

                //Console.WriteLine("/*************************/");
            
            } while (option != MenuOptions.EXIT);

            Console.WriteLine("-----------------");

            Console.ReadLine();

        }


        /// <summary>
        /// Get Appointment slot for passed in clinic
        /// </summary>
        /// <param name="clinic"> </param>
        /// <returns></returns>
        private static TimeSlot GetAppointmentTimeSlot(DentalClinic clinic)
        {
            TimeSlot timeSlot;

            #region allow user to choose slot
            //int input;

            //do
            //{
            //    Console.WriteLine("Choose Your Appointment slot");

            //    var slots = clinic.GetAvailableTimeSlots();

            //    Console.WriteLine("****************************");
            //    for (int i = 0; i < slots.Length; i++)
            //    {
            //        Console.WriteLine("{0}. {1}", (i+1), slots[i].ToString());
            //    }
            //    Console.WriteLine("****************************");
            //    Console.Write("Slot -->");
            //    input = getIntInputFromConsole(_debug);
            //    timeSlot = (TimeSlot)input;

            //    if (clinic.CheckAvailability(timeSlot))
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Slot is not available");
            //    }

            //} while (true);
            #endregion

            if (clinic.GetAvailableTimeSlots().Length > 0)
            {
                timeSlot = clinic.GetAvailableTimeSlots()[0];
            }
            else
            {
                timeSlot = TimeSlot.NONE;
            }
            
            return timeSlot;
        }

        private static Person GetPatientForAppointment(DentalClinic clinic)
        {
            
            try
            {
                var input = GetIntInputFromConsole(_debug);

                if (input == 0)
                    return null;

                return clinic.GetPatient(input - 1); // offseting input to match with Array index
            }
            catch (Exception)
            {

                Console.WriteLine("\n\nInvalid Patient record select\n\n");
                return null;
            }
        
        }
      
        private static int GetIntInputFromConsole(bool _Debug)
        {
            int input;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                if (_Debug)
                {
                    Console.WriteLine(e.Message.ToString());
                }
                Console.WriteLine("Please choose valid option");
                input = -1;
            }

            return input;
        }

        
    }
}
