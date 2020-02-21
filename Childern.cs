using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    /// <summary>
    /// Below 16 age will consider as Childern
    /// </summary>
    class Childern : Person 
    {
        public Childern()
        {

        }
        public Childern(Person person)
        {
            base.FirstName = person.FirstName;
            base.LastName = person.LastName;
            base.Gender = person.Gender;
            base.BirthDate = person.BirthDate;
            base.PatientNumber = person.PatientNumber;
        }

        public override void Fittings()
        {
            Console.WriteLine("Braces fitted");
        }
    }
}
