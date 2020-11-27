using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;

namespace EmployeePayRoll_MultiThreading
{
    public class EmployeePayrollOperations
    {

        //mutex class is defined in threading namespace 
        //it is used for synchronizing threads
        private static Mutex mut = new Mutex();

        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Threads;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);

        public List<EmployeeDetails> employeePayrollDetailList = new List<EmployeeDetails>();

        /// <summary>
        /// UC1
        /// Adds the employee to payroll.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayroll(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                this.AddEmployeePayroll(employeeData);
                Console.WriteLine("Employee added:" + employeeData.EmployeeName);
            });
            Console.WriteLine(this.employeePayrollDetailList.ToString());
        }

        /// <summary>
        /// Adds the employee payroll.
        /// </summary>
        /// <param name="emp">The emp.</param>
        public void AddEmployeePayroll(EmployeeDetails emp)
        {
            employeePayrollDetailList.Add(emp);
        }

        /// <summary>
        /// Adds the employee to payroll data base.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayrollDataBase(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                this.AddEmployeePayrollDatabase(employeeData);
                Console.WriteLine("Employee added" + employeeData.EmployeeName);
            });
        }

        /// <summary>
        /// Adds the employee payroll database.
        /// </summary>
        /// <param name="employeeDetails">The employee details.</param>
        public void AddEmployeePayrollDatabase(EmployeeDetails employeeDetails)
        {
            SqlCommand command = new SqlCommand("spInsertData", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@EmployeeId", employeeDetails.EmployeeID);
            command.Parameters.AddWithValue("@EmployeeName", employeeDetails.EmployeeName);
            command.Parameters.AddWithValue("@phoneNumber", employeeDetails.PhoneNumber);
            command.Parameters.AddWithValue("@Address", employeeDetails.Address);
            command.Parameters.AddWithValue("@Department", employeeDetails.Department);
            command.Parameters.AddWithValue("@gender", employeeDetails.Gender);
            command.Parameters.AddWithValue("@basicpay", employeeDetails.BasicPay);
            command.Parameters.AddWithValue("@deductions", employeeDetails.Deductions);
            command.Parameters.AddWithValue("@taxablepay", employeeDetails.TaxablePay);
            command.Parameters.AddWithValue("@tax", employeeDetails.Tax);
            command.Parameters.AddWithValue("@netpay", employeeDetails.NetPay);
            command.Parameters.AddWithValue("@city", employeeDetails.City);
            command.Parameters.AddWithValue("@country", employeeDetails.Country);
            connection.Open();
            //adding data into database - using disconnected architecture(as connected architecture only reads the data)
            var result = command.ExecuteNonQuery();
            //closing connection
            connection.Close();
        }

        /// <summary>
        /// UC2
        /// Adds the employee to payroll with thread.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayrollWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added:" + employeeData.EmployeeName);
                });
                thread.Start();
            });
        }

        /// <summary>
        /// UC2
        /// Adds the employee to payroll data base with thread.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayrollDataBaseWithThread(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    this.AddEmployeePayrollDatabase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                });
                thread.Start();
                Thread.Sleep(2000);
            });
        }


        /// <summary>
        /// UC3
        /// Adds the employee to payroll with thread with synchronization.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayrollWithThreadWithSynchronization(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    //mutex waitone method is used
                    //this method does not allow to other threads to go in it, until current thread execution is complete
                    mut.WaitOne();
                    Console.WriteLine("Employee Being added" + employeeData.EmployeeName);
                    this.AddEmployeePayroll(employeeData);
                    Console.WriteLine("Employee added:" + employeeData.EmployeeName);
                    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                    //mut realease mutex is used, which releases current thread and allows new thread to be used.
                    mut.ReleaseMutex();
                });
                thread.Start();
            });
        }

        /// <summary>
        /// UC3
        /// Adds the employee to payroll data base with thread with synchronization.
        /// </summary>
        /// <param name="employeePayrollDataList">The employee payroll data list.</param>
        public void AddEmployeeToPayrollDataBaseWithThreadWithSynchronization(List<EmployeeDetails> employeePayrollDataList)
        {
            employeePayrollDataList.ForEach(employeeData =>
            {
                Task thread = new Task(() =>
                {
                    //mutex waitone method is used
                    //this method does not allow to other threads to go in it, until current thread execution is complete
                    mut.WaitOne();
                    Console.WriteLine("Employee being added" + employeeData.EmployeeName);
                    this.AddEmployeePayrollDatabase(employeeData);
                    Console.WriteLine("Employee added" + employeeData.EmployeeName);
                    Console.WriteLine("Current Thread Id : " + Thread.CurrentThread.ManagedThreadId);
                    //mut realease mutex is used, which releases current thread and allows new thread to be used.
                    mut.ReleaseMutex();
                });
                thread.Start();
                //task.wait or task.join also blocks other threads to come until current execution is not complete
                //hence applying synchronization
                //but it reduces no of threads to only one, as thread execution get complete and same thread execute again
                //ask doubt for this. when thread.wait is not used with task, then error is thrown, while opening up connection
                thread.Wait();
            });
        }
    }
}
