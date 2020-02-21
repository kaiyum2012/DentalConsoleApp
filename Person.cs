using System;
using System.Collections.Generic;
using System.Text;
// TODO :: restrict Birthdate to get access / return only short date representation upton access

namespace DentalConsoleApp
{
     enum Gender {
        MALE,
        FEMALE
    }
    class Person : IDentalClinicServices
    {
        private string firstName;
        private string lastName;
        private Gender gender;
        private DateTime birthDate;
        private string patientNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public Gender Gender { get => gender; set => gender = value; }
        public DateTime BirthDate {
            get => birthDate.Date;
            set => birthDate = value; 
        }
       
        public string PatientNumber 
        {
            get {
                int mask = 3;
                string maskStr = new string('X',mask );
                string unMask = patientNumber.Substring(mask, patientNumber.Length - mask);
                return maskStr + unMask;
            }

            set { patientNumber = value; }
        }
        /// <summary>
        /// Age (Computed property)
        /// </summary>
        public int Age { 
           get
            {
                return (int)(DateTime.Now.Year - BirthDate.Year); 
            }
        }

        public Person()
        {

        }

        /// <summary>
        /// Constructor for Person Class
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"> Datetime Object (YYYY-MM-DD)</param>
        /// <param name="patientNumber"> Patient Number (10 digits)</param>
        public Person(string firstName,string lastName,Gender gender,DateTime birthDate,string patientNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            BirthDate = birthDate;
            PatientNumber = patientNumber;

        }

        #region Override Methods
        // DONE:: Replace AGE with computed property 
        public override string ToString()
        {
            return
                FirstName + "," + LastName + " ("+ Age +" years) - " + Gender + "\n" +
                "Patient Number :" + PatientNumber + "   Birthday (MM/DD/YYYY) :" + GetBirthDateShortString() ;
        }
       
        #endregion
        public string GetBirthDateShortString()
        {
            return birthDate.ToShortDateString();
        }

        #region IDentalClinicServices
        public void CavityFill()
        {
            Console.WriteLine("The Cavity Fill was performed");
        }

        public void CheckUp()
        {
            Console.WriteLine("The Check up was performed");
        }

        public void Cleaning()
        {
            Console.WriteLine("The Cleaning was performed");
        }

        public virtual void Fittings()
        {
            Console.WriteLine("The specific person fitting was performed");
        }

        public void XRay()
        {
            Console.WriteLine("The XRay was performed");
        }

        #endregion
    }
}
