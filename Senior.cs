using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class Senior : Person
    {

        private Senior()
        {

        }
        
        /// <summary>
        /// Senior is type of Person
        /// </summary>
        /// <param name="person"></param>

        public Senior(Person person)
        {
            base.FirstName = person.FirstName;
            base.LastName = person.LastName;
            base.Gender = person.Gender;
            base.BirthDate = person.BirthDate;
            base.PatientNumber = person.PatientNumber;
        }

        public override void Fittings()
        {
            Console.WriteLine("veneers fitted");
        }
    }
}
