using System;

namespace Report.Core.Entity
{
    public class AnnualSalaryWorkingDayEntity
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Employee code
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Time sheet date
        /// </summary>
        public DateTime TimeSheetDate { get; set; }

        /// <summary>
        /// Start hours
        /// </summary>
        public TimeSpan? StartHour { get; set; }

        /// <summary>
        /// End hours
        /// </summary>
        public TimeSpan? EndHour { get; set; }

        /// <summary>
        /// Calculated hour
        /// </summary>
        public decimal? CalHour { get; set; }

        /// <summary>
        /// Roster start hours
        /// </summary>
        public decimal? RosterStartHour { get; set; }

        /// <summary>
        /// Roster end hours
        /// </summary>
        public decimal? RosterEndHour { get; set; }

        /// <summary>
        /// Roster calculated hour
        /// </summary>
        public decimal? RosterCalHour { get; set; }

        /// <summary>
        /// Date type
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// Time sheet total hours
        /// </summary>
        public decimal? TimeSheetTotalHour { get; set; }

        /// <summary>
        /// Roster total hours
        /// </summary>
        public decimal? RosterTotalHour { get; set; }

        /// <summary>
        /// The action type
        /// </summary>
        public AnnualSalaryActionType ActionType { get; set; }

        /// <summary>
        /// Payroll identifier
        /// </summary>
        public long PayrollId { get; set; }

        /// <summary>
        /// Payroll start date
        /// </summary>
        public DateTime? PayrollStart { get; set; }

        /// <summary>
        /// Payroll end date
        /// </summary>
        public DateTime? PayrollEnd { get; set; }
    }
}

