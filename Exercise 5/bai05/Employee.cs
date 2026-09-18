using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Module03.bai05
{
    //use polymorphism for class Employee
    public abstract class Employee
    {
        //instance fields
        private string Firstname;
        private string Lastname;
        private string Socialsecuritynumber;
        //constructor
        public Employee(string firstname, string lastname, string SSN)
        {
            Firstname = firstname;
            Lastname = lastname;
            Socialsecuritynumber = SSN;
        }
        public abstract double Earnings();

        public override string ToString()
        {
            return $"Employee: {Firstname} {Lastname}\n" +
                   $"Social Security Number: {Socialsecuritynumber}";
        }

    }
    public class SalariedEmployee : Employee
    {
        private double weeklySalary;

        public SalariedEmployee(
            string firstName,
            string lastName,
            string SSN,
            double weeklySalary)
            : base(firstName, lastName, SSN)
        {
            this.weeklySalary = weeklySalary;
        }

        public double WeeklySalary
        {
            get { return weeklySalary; }
            set { weeklySalary = value; }
        }

        public override double Earnings()
        {
            return WeeklySalary;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nWeekly Salary: {WeeklySalary}";
        }
    }
    public class HourlyEmployee : Employee
    {
        // Instance fields
        private double wage;
        private double hours;

        // Constructor
        public HourlyEmployee(
            string firstName,
            string lastName,
            string SSN,
            double wage,
            double hours)
            : base(firstName, lastName, SSN)
        {
            this.wage = wage;
            this.hours = hours;
        }

        // Properties
        public double Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        // Calculate salary
        public override double Earnings()
        {
            if (Hours <= 40)
            {
                return Hours * Wage;
            }
            else
            {
                return (40 * Wage) +
                       ((Hours - 40) * Wage * 1.5);
            }
        }

        // Display information
        public override string ToString()
        {
            return base.ToString() +
                   $"\nHourly Wage: {Wage}" +
                   $"\nHours Worked: {Hours}";
        }
    }

    public class CommissionEmployee : Employee
    {
        private double grossSales;
        private double commissionRate;

        public CommissionEmployee(
            string firstName,
            string lastName,
            string SSN,
            double grossSales,
            double commissionRate)
            : base(firstName, lastName, SSN)
        {
            this.grossSales = grossSales;
            this.commissionRate = commissionRate;
        }

        public double GrossSales
        {
            get { return grossSales; }
            set { grossSales = value; }
        }

        public double CommissionRate
        {
            get { return commissionRate; }
            set { commissionRate = value; }
        }

        public override double Earnings()
        {
            return GrossSales * CommissionRate;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nGross Sales: {GrossSales}" +
                   $"\nCommission Rate: {CommissionRate}";
        }
    }

    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        private double baseSalary;

        public BasePlusCommissionEmployee(
            string firstName,
            string lastName,
            string SSN,
            double grossSales,
            double commissionRate,
            double baseSalary)
            : base(firstName, lastName, SSN, grossSales, commissionRate)
        {
            this.baseSalary = baseSalary;
        }

        public double BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }

        public override double Earnings()
        {
            return base.Earnings() + BaseSalary;
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\nBase Salary: {BaseSalary}";
        }
    }
}
