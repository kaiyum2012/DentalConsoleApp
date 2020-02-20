using System;
using System.Collections.Generic;
using Bogus;

namespace DentalConsoleApp
{

    class Program
    {
  
        public static List<Person> patients = new List<Person>();

        static void Main(string[] args)
        {
            DentalClinic clinic = new DentalClinic("ABC Dental Clinic");
            Console.WriteLine("Welcome to {0} Console App", clinic.ClinicName);
            Console.WriteLine("------------------------------------");

            GeneratePatients();
            ScheduleAppointments(clinic);

            Console.WriteLine("-----------------");

            Console.ReadLine();

        }

        public static void GeneratePatients()
        {

            //var faker = new Faker("en");
            //for (int i = 0; i < 10; i++)
            //{
            //    Person patient = new Person(faker.Person.FirstName,faker.Person.LastName,faker.PickRandom<Gender>(),faker.Person.DateOfBirth,long.Parse(faker.Person.Phone));
            //    patient.ToString();

            //}
            patients.Add(new Childern(new Person("Abdulkaiyum", "shaikh",Gender.MALE,new DateTime(1992,06,13), 5195006612)));
            patients.Add(new Adult(new Person("sunny", "pate;", Gender.MALE, new DateTime(1992, 06, 13), 5195006612)));
            patients.Add(new Senior(new Person("sree", "ba", Gender.FEMALE, new DateTime(1992, 06, 13), 5195006612)));
            patients.Add(new Childern(new Person("khushbu", "soni", Gender.FEMALE, new DateTime(1992, 06, 13), 5195006612)));
            patients.Add(new Childern(new Person("Aayushi", "mali", Gender.FEMALE, new DateTime(1992, 06, 13), 5195006612)));


            foreach (var patient in patients)
            {
                Console.WriteLine( patient.ToString());
            }
            //new Childern(new Person("Abdulkaiyum", "Shaikh", Gender.MALE, new DateTime(1992, 06, 13), 5195006612));

        }

        private static void ScheduleAppointments(DentalClinic clinic)
        {
            for (int i = 0; i < 5; i++)
            {
                clinic.Schedule(new Appointment(patients[i], TimeSlot._12AM_01PM_));
            }
            
        }
    }
}
