using EmployeePayRoll_MultiThreading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeePayRollMSTest
{
    [TestClass]
    public class EmployeePayrollUnitTest
    {


        EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();

        [TestMethod]
        public List<EmployeeDetails> AddingDataToList()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();

            employeeDetails.Add(new EmployeeDetails(EmployeeID: 1, EmployeeName: "Bruce", PhoneNumber: "7412589632", Address: "Kormangala", Department: "HR", Gender: 'M', BasicPay: 1000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 2, EmployeeName: "Wayne", PhoneNumber: "1234567895", Address: "VijayNagar", Department: "HR", Gender: 'M', BasicPay: 3000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 3, EmployeeName: "Lil Wayne", PhoneNumber: "7894561235", Address: "BTM Layout", Department: "Marketing", Gender: 'M', BasicPay: 3000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 4, EmployeeName: "Eminen", PhoneNumber: "6398521475", Address: "Basweshwar Nagar", Department: "Sales", Gender: 'M', BasicPay: 6000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 5, EmployeeName: "Drake", PhoneNumber: "9632587412", Address: "Mahantesh Nagar", Department: "Sales", Gender: 'M', BasicPay: 7000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Belgaum", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 6, EmployeeName: "Enrique", PhoneNumber: "5469871235", Address: "Hanuman Nagar", Department: "Development", Gender: 'M', BasicPay: 10000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Belgaum", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 7, EmployeeName: "Shakira", PhoneNumber: "8521479635", Address: "MG Road", Department: "Quality", Gender: 'F', BasicPay: 2000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 8, EmployeeName: "Rihanna", PhoneNumber: "9874563217", Address: "Brigade Road", Department: "HR", Gender: 'F', BasicPay: 2000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 9, EmployeeName: "Akon", PhoneNumber: "7412369857", Address: "Srinagar", Department: "SE", Gender: 'M', BasicPay: 1000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Belgaum", Country: "India"));
            employeeDetails.Add(new EmployeeDetails(EmployeeID: 10, EmployeeName: "MGK", PhoneNumber: "9632177856", Address: "Alsur", Department: "HR", Gender: 'M', BasicPay: 5000, Deductions: 2, TaxablePay: 20, Tax: 100, NetPay: 400, City: "Bangalore", Country: "India"));

            return employeeDetails;
        }

        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayrollList()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll(employeeDetails);
            DateTime endtime = DateTime.Now;

            Console.WriteLine("Total time without thread: {0}", starttime - endtime);
        }

        [TestMethod]
        public void AddingDataIntoDataBase()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.AddEmployeeToPayrollDataBase(employeeDetails);
            DateTime endtime = DateTime.Now;
            Console.WriteLine("Total time for operation without thread: {0}", starttime - endtime);
        }
    }

}