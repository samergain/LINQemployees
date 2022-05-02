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

        //SELECT 
        
        private void SelectDemo()
        {
            //select * from employees
            //query syntax
            //var result = from employee in employeeRepository.GetEmployees()
            //           select employee;

            //method syntax
            //var result = employeeRepository.GetEmployees().Select(employee => employee);

            //foreach (var employee in result)
            //{
            //    Console.WriteLine(employee.Id + "\t" + employee.FullName + "\t" + employee.Department + "\t" + employee.Salary + "\t" + employee.Age);
            //}

            //Single Value
            //query syntax
            //var result = from employee in employeeRepository.GetEmployees()
            //             select employee.FullName;

            //method syntax
            //var result = employeeRepository.GetEmployees().Select(emp => emp.FullName);
            //foreach (var employee in result)
            //{
            //    Console.WriteLine(employee);
            //}

            //Multiple values
            //query syntax
            //var result = (from employee in employeeRepository.GetEmployees()
            //             select employee.Department).Distinct();
            var result = employeeRepository.GetEmployees().Select(emp => new { Name = emp.FullName, Department = emp.Department })
                .FirstOrDefault(x => x.Department == "ddsf") ?? new { Name = "N/A", Department = "N/A"};
            Console.WriteLine(result);
        }

        private void OrderByDemo()
        {
            //var result = from employee in employeeRepository.GetEmployees()
            //             orderby employee.Salary descending, employee.FullName descending
            //             select new
            //             {
            //                 Name = employee.FullName,
            //                 Salary = employee.Salary
            //             };

            //method syntax
            var result = employeeRepository.GetEmployees().OrderByDescending(x => x.Salary).ThenByDescending(x => x.FullName).Select(x => new { Name = x.FullName, Salary = x.Salary });
            foreach (var x in result)
            {
                Console.WriteLine(x.Name+'\t'+x.Salary);
            }
        }

        public void Run()
        {
            OrderByDemo();
        }
    }
}
