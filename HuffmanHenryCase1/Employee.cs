using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HuffmanHenryCase1
{
    public class Employee
    {
        public int employeeId;
        public string lastName;
        public string firstName;
        public double hourlyWage;
        public double hoursWorked;
        public double totalPayRoll;

        private static string[] namePrefix = { "a", "b", "c"};
        private static int lastId = 100;
        private static Random r = new System.Random(1);

        public static Employee makeEmployee()
        {
            Employee e = new Employee();
            e.employeeId = ++lastId;
            e.firstName = namePrefix[r.Next(0, namePrefix.GetUpperBound(0) + 1)] + lastId.ToString();
            e.lastName = namePrefix[r.Next(0, namePrefix.GetUpperBound(0) + 1)] + lastId.ToString();
            e.hourlyWage = r.NextDouble() * (180.00 - 9.00) + 9.00;
            e.hoursWorked = r.Next(0, 100);
            e.totalPayRoll = (e.hourlyWage) * (e.hoursWorked);
            return e; 
        }
    }
}