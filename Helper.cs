using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DentalConsoleApp
{
   public static class Helper
   {
       
   }

   public static class EnumHelper
   {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        /// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (attributes.Length > 0) ? (T)attributes[0] : null;
        }

        public static string GetAttributeDescription(this Enum enumValue)
        {
            var attribute = enumValue.GetAttributeOfType<DescriptionAttribute>();
            return attribute == null ? String.Empty : attribute.Description;
        }

        public static T[] ToArray<T>() where T : Enum
        {
            List<T> valuesList = new List<T>();

            foreach (T v in Enum.GetValues(typeof(T)))
            {
                    valuesList.Add(v);
            }
            return valuesList.ToArray();
        }

        //public static T[] ToArrayExcept<T>(this T[] excepts) where T : Enum
        //{
        //    List<T> valuesList = new List<T>();
        //    T[] values = ToArray<T>();
        //    T[] exceptsValues = excepts.ToArray<T>();

        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        for (int j = 0; j <exceptsValues.Length; j++)
        //        {
        //            if (exceptsValues[j] != values[i])
        //            {
        //                valuesList.Add(values[i]);
        //                break;
        //            }

        //        }
        //    }
           
        //    return valuesList.ToArray();
        //}
   }  
}

