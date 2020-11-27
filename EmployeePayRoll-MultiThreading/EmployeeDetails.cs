using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRoll_MultiThreading
{
    public class EmployeeDetails
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public char Gender { get; set; }
        public decimal BasicPay { get; set; }
        public decimal Deductions { get; set; }
        public decimal TaxablePay { get; set; }
        public decimal Tax { get; set; }
        public decimal NetPay { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeDetails"/> class.
        /// </summary>
        /// <param name="EmployeeID">The employee identifier.</param>
        /// <param name="EmployeeName">Name of the employee.</param>
        /// <param name="PhoneNumber">The phone number.</param>
        /// <param name="Address">The address.</param>
        /// <param name="Department">The department.</param>
        /// <param name="Gender">The gender.</param>
        /// <param name="BasicPay">The basic pay.</param>
        /// <param name="Deductions">The deductions.</param>
        /// <param name="TaxablePay">The taxable pay.</param>
        /// <param name="Tax">The tax.</param>
        /// <param name="NetPay">The net pay.</param>
        /// <param name="City">The city.</param>
        /// <param name="Country">The country.</param>
        public EmployeeDetails(int EmployeeID, string EmployeeName, string PhoneNumber, string Address, string Department, char Gender, decimal BasicPay, decimal Deductions, decimal TaxablePay, decimal Tax, decimal NetPay, string City, string Country)
        {
            this.EmployeeID = EmployeeID;
            this.EmployeeName = EmployeeName;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;
            this.Department = Department;
            this.Gender = Gender;
            this.BasicPay = BasicPay;
            this.Deductions = Deductions;
            this.TaxablePay = TaxablePay;
            this.Tax = Tax;
            this.NetPay = NetPay;
            this.City = City;
            this.Country = Country;
        }
    }
}
