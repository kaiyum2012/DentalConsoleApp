using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class Adult : Person
    {

        private Adult() { }

        /// <summary>
        /// Adult is of Type Person
        /// </summary>
        /// <param name="person"></param>
        public Adult(Person person)
        {
            base.FirstName = person.FirstName;
            base.LastName = person.LastName;
            base.Gender = person.Gender;
            base.BirthDate = person.BirthDate;
            base.PatientNumber = person.PatientNumber;
        }

        #region overrride methods
        public override void Fittings()
        {
            Console.WriteLine("dentures fitted");
        }
        #endregion
    }
}
