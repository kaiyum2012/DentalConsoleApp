using System;
using System.Collections.Generic;
using System.Text;

namespace DentalConsoleApp
{
    class PatientList
    {
       //TODO:: Create 10 Patient List
       private List<Person> patients = new List<Person>();

       public PatientList()
       {
            patients = new List<Person>();
       }

       public void Add(Person person)
        {
            patients.Add(person);
        }

        public int Count
        {
            get { return patients.Count; }
        }

        public Person this[int i]
        {
            get 
            {
                return patients[i]; 
            }
            set 
            { 
                patients[i] = value; 
            }
        }

        public Person[] All() 
        {
            return patients.ToArray();
        }
    }


}
