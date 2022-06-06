using AsposeTestTask.Logic.Entities;
using System;
using System.Collections.Generic;
using Xunit;

namespace AsposeTestTask.Logic.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CalculationOfEmployeeSalaryTest()
        {
            var employee = new Employee()
            {
                Experience = 5,
                Salary = 3000
            };

            var salary = employee.CalculateSalary();

            Assert.Equal(3450, salary);
        }
    
        [Fact]
        public void CalculationOfEmployeeSalaryWithExperienceMoreThan10Test()
        {
            var employee = new Employee()
            {
                Experience = 12,
                Salary = 3000
            };

            var salary = employee.CalculateSalary();

            Assert.Equal(3900, salary);
        }

        [Fact]
        public void CalculationOfManagerSalaryWithoutSubordinatesTest()
        {
            var manager = new Manager()
            {
                Experience = 5,
                Salary = 4000,
                Subordinates = new List<Worker>()
            };

            var salary = manager.CalculateSalary();

            Assert.Equal(5000, salary);
        }

        [Fact]
        public void CalculationOfManagerSalaryWithSubordinatesTest()
        {
            var manager = new Manager()
            {
                Experience = 5,
                Salary = 4000,
                Subordinates = new List<Worker>()
            };
            manager.Subordinates.Add(new Employee()
            {
                Experience = 5,
                Salary = 3000,
                Chief = manager
            });
            manager.Subordinates.Add(new Employee()
            {
                Experience = 5,
                Salary = 3000,
                Chief = manager
            });

            var salary = manager.CalculateSalary();

            Assert.Equal(5034.5, salary);
        }

        [Fact]
        public void CalculationOfSalesSalaryWithSubordinatesTest()
        {
            var sales = new Sales()
            {
                Experience = 5,
                Salary = 6000,
                Subordinates = new List<Worker>()
            };
            var manager = new Manager()
            {
                Experience = 5,
                Salary = 4000,
                Subordinates = new List<Worker>(),
                Chief = sales
            };
            sales.Subordinates.Add(manager);
            manager.Subordinates.Add(new Employee()
            {
                Experience = 5,
                Salary = 3000,
                Chief = manager
            });
            manager.Subordinates.Add(new Employee()
            {
                Experience = 5,
                Salary = 3000,
                Chief = manager
            });

            var salary = sales.CalculateSalary();

            Assert.Equal(6335.8035, salary);
        }
    }
}
