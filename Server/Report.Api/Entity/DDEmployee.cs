using System;
using System.Collections.Generic;

namespace Report.Api.Entity
{
    /// <summary>
    /// no need to inherit, no header and footer
    /// </summary>
    public class DDEmployee
    {
        public List<Employee> Employees { get; set; }

        public DDEmployee()
        {
            Employees = new List<Employee>()
            {
                new Employee()
                {
                    FamilyName = "Test01",
                    GivenName = "test02"
                },
                new Employee()
                {
                    FamilyName = "Test03",
                    GivenName = "test04"
                }
            };
        }        
    }

    public class Employee
    {
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime StartDate { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Status { get; set; }
        public DateTime? TerminationDate { get; set; }
        public decimal HourlyRate { get; set; }
        public string PaymentGroup { get; set; }
        public string CostCentreName { get; set; }
        public string DepartmentName { get; set; }
        public decimal CostCentreHours { get; set; }
        public string StateEmployed { get; set; }
        public string Occupation { get; set; }
        public string PayLocation { get; set; }

        public string HECS { get; set; }
        public decimal AccruedAL { get; set; }
        public decimal AccruedSL { get; set; }
        public decimal AccruedLSL { get; set; }
        public decimal AccruedRDO { get; set; }
        public string EmployeeCode { get; set; }
        public string EmploymentStatus { get; set; }

        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string EmergencyName { get; set; }
        public string NextOfKinRelation { get; set; }
        public string EmergencyPhone { get; set; }
        public string EmergencyMobile { get; set; }
        public string EmergencyAddress1 { get; set; }
        public string EmergencyAddress2 { get; set; }
        public string EmergencyAddress3 { get; set; }

        public bool ShowEmergencyContactDetails { get; set; }
        public DateTime? LastLogin { get; set; }
    }
}
