using EmployeePayRoll_MultiThreading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace EmployeePayRollMSTest
{
    [TestClass]
    public class EmployeePayrollUnitTest
    {
        EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();

        /// <summary>
        /// Addings the data to list.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Givens the list of employee added into employee payroll list.
        /// </summary>
        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayrollList()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayroll(employeeDetails);
            DateTime endtime = DateTime.Now;

            Console.WriteLine("Total time without thread: {0}", endtime - starttime);
        }

        /// <summary>
        /// Addings the data into data base.
        /// </summary>
        [TestMethod]
        public void AddingDataIntoDataBase()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime = DateTime.Now;
            EmployeePayrollOperations employeePayrollOperations = new EmployeePayrollOperations();
            employeePayrollOperations.AddEmployeeToPayrollDataBase(employeeDetails);
            DateTime endtime = DateTime.Now;
            Console.WriteLine("Total time for operation without thread: {0}", endtime - starttime);
        }

        /// <summary>
        /// Givens the list of employee added into employee pay roll list using threading.
        /// </summary>
        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayRollList_UsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time with thread: {0}", endtime1 - starttime1);
        }

        /// <summary>
        /// Addings the datainto data base using threading.
        /// </summary>
        [TestMethod]
        public void AddingDataintoDataBaseUsingThreading()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollDataBaseWithThread(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time for operation with thread: {0}", endtime1 - starttime1);
        }

        /// <summary>
        /// Givens the list of employee added into employee pay roll list using threading with synchronization.
        /// </summary>
        [TestMethod]
        public void GivenListOfEmployee_AddedIntoEmployeePayRollList_UsingThreading_WithSynchronization()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollWithThreadWithSynchronization(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time with thread: {0}", endtime1 - starttime1);
        }

        /// <summary>
        /// Addings the datainto data base using threading with synchronization.
        /// </summary>
        [TestMethod]
        public void AddingDataintoDataBaseUsingThreading_WithSynchronization()
        {
            List<EmployeeDetails> employeeDetails = AddingDataToList();
            DateTime starttime1 = DateTime.Now;
            employeePayrollOperations.AddEmployeeToPayrollDataBaseWithThreadWithSynchronization(employeeDetails);
            DateTime endtime1 = DateTime.Now;
            Console.WriteLine("Total time for operation with thread: {0}",  endtime1 - starttime1);
        }
    }

}
