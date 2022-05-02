using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQintro
{
    public class ManageEmployee
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        private Employee Demo(Employee emp)
        {
            return emp;
        }

        //SELECT 
        private void SelectDemo()
        {
            //select * from employees
            //query syntax
            var result = from employee in employeeRepository.GetEmployees()
                         select employee;
            foreach(var employee in result)
            {
                Console.WriteLine(employee.Id + "\t" + employee.FullName + "\t" + employee.Department + "\t" + employee.Salary + "\t" + employee.Age);
            }

        }


        public void Run()
        {
            SelectDemo();
        }
    }
}
