using System;
using System.Collections.Generic;
using System.Linq;

namespace Report.Core.Entity
{
    public class AnnualSalaryEmployee : AnnualSalaryReportBase
    {
        /// <summary>
        /// Employee identifier
        /// </summary>
        public long EmployeeId { get; set; }

        /// <summary>
        /// Employee Name
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Employee code
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Over time threshold
        /// </summary>
        public double OverTimeThreshold { get; set; }

        /// <summary>
        /// Over time thresholdString
        /// </summary>
        public string OverTimeThresholdString { get => ConvertToString(TimeSpan.FromHours(OverTimeThreshold)); }

        /// <summary>
        /// Annual workinbg day group
        /// </summary>
        public List<AnnualSalaryWorkingDayGroup> WorkingDayGroups { get; set; }

        /// <summary>
        /// Total timesheet hours
        /// </summary>
        private double TotalTimeSheetHour { get => WorkingDayGroups.Sum(s => s.TotalHour.TotalHours); }

        /// <summary>
        /// Total roster timesheet hours
        /// </summary>
        private double RosterTotalTimeSheetHour { get => WorkingDayGroups.Sum(s => s.RosterTotalHour.TotalHours); }

        /// <summary>
        /// Total difference cal timesheet hours
        /// </summary>
        private double DifferenceCalTotalHour { get => WorkingDayGroups.Sum(s => s.DifferenceCal.TotalHours); }

        /// <summary>
        /// Total timesheet hours
        /// </summary>
        public string TotalTimeSheetHourString { get => ConvertToString(TimeSpan.FromHours(TotalTimeSheetHour)); }

        /// <summary>
        /// Total roster timesheet hours
        /// </summary>
        public string RosterTotalTimeSheetHourString { get => ConvertToString(TimeSpan.FromHours(RosterTotalTimeSheetHour)); }

        /// <summary>
        /// Total difference cal timesheet hours
        /// </summary>
        public string DifferenceCalTotalHourString { get => ConvertToString(TimeSpan.FromHours(DifferenceCalTotalHour)); }

        /// <summary>
        /// Penalty rate
        /// </summary>
        public AnnualSalaryPenaltyRate AnnualPenaltyRate { get; set; }

        /// <summary>
        /// Addditional overtime pay
        /// </summary>
        public double AdditionalOvertimePay { get => (DifferenceCalTotalHour - OverTimeThreshold) < 0 ? 0 : DifferenceCalTotalHour - OverTimeThreshold; }

        /// <summary>
        /// Addditional overtime pay string
        /// </summary>
        public string AdditionalOvertimePayString { get => ConvertToString(TimeSpan.FromHours(AdditionalOvertimePay)); }
    }
}