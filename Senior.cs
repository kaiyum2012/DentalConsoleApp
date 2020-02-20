using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class Senior : Person
    {

        public Senior()
        {

        }

        public Senior(Person person)
        {
            base.FirstName = person.FirstName;
            base.LastName = person.LastName;
            base.Gender = person.Gender;
            base.BirthDate = person.BirthDate;
            base.PhoneNumber = person.PhoneNumber;
        }

        public override void Fittings()
        {
            Console.WriteLine("veneers fitted");
        }
    }
}
