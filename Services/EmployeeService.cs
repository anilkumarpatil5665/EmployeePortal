using EmployeePortal.Models;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml.Linq;

namespace EmployeePortal.Services
{
    public class EmployeeService
    {
        private readonly ObservableCollection<Employee> _employees;

        public EmployeeService()
        {
            _employees = new ObservableCollection<Employee>
            {
             new Employee
        {
            Name = "Priya",
            Address = "23",
            Gender = Gender.Female,
            IsMarried = false,
            PhotoPath = string.Empty,
            PhoneNumber = "8794564568",
            Email = "priya@solitontech.com",
            Position = "Senior Project Engineer",
            ReportingTo = "Navin Subramani",
            ProjectName = "SDC-IP"
        },
         
        new Employee
        {
            Name = "Vignesh",
            Address = "Coimbatore",
            Gender = Gender.Male,
            IsMarried = false,
            PhotoPath = string.Empty,
            PhoneNumber = "9877897895",
            Email = "vignesh@solitontech.com",
            Position = "Senior Project Engineer",
            ReportingTo = "Navin Subramani",
            ProjectName = "SDC-IP"
        },

        new Employee
        {
            Name = "Ram",
            Address = "Coimbatore",
            Gender = Gender.Male,
            IsMarried = true,
            PhotoPath = string.Empty,
            PhoneNumber = "7815612323",
            Email = "ram@solitontech.com",
            Position = "Project Engineer",
            ReportingTo = "Navin Subramani",
            ProjectName = "SDC-IP"
        }
            };
        }

        public ObservableCollection<Employee> Employees
        {
            get
            {
                return _employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }
    }
}