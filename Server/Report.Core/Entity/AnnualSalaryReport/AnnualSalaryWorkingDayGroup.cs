using System;
using System.Collections.Generic;
using System.Linq;

namespace Report.Core.Entity
{
    public class AnnualSalaryWorkingDayGroup : AnnualSalaryReportBase
    {
        /// <summary>
        /// Annual working day
        /// </summary>
        public IList<AnnualSalaryWorkingDay> WorkingDays { get; set; }

        /// <summary>
        /// Time sheet date
        /// </summary>
        public DateTime TimeSheetDate { get; set; }

        /// <summary>
        /// Total hour
        /// </summary>
        public TimeSpan TotalHour { get => new TimeSpan(WorkingDays.Sum(s => s.ActionType == AnnualSalaryActionType.Break ? s.CalHour.Ticks * (-1) : s.CalHour.Ticks)); }

        /// <summary>
        /// Total hours string
        /// </summary>
        public string TotalHourString { get => ConvertToString(TotalHour); }

        /// <summary>
        /// Total roster hour
        /// </summary>
        public TimeSpan RosterTotalHour { get => new TimeSpan(WorkingDays.Sum(s => s.ActionType == AnnualSalaryActionType.Break ? s.RosterCalHour.Ticks * (-1) : s.RosterCalHour.Ticks)); }

        /// <summary>
        ///  Total roster hour string
        /// </summary>
        public string RosterTotalHourString { get => ConvertToString(RosterTotalHour); }

        /// <summary>
        /// Difference calculation
        /// </summary>
        public TimeSpan DifferenceCal { get => (TotalHour.Ticks - RosterTotalHour.Ticks) > 0 ? new TimeSpan(TotalHour.Ticks - RosterTotalHour.Ticks) : TimeSpan.Zero; }

        /// <summary>
        ///   Difference calculation string
        /// </summary>
        public string DifferenceCalTotalString { get => ConvertToString(DifferenceCal); }
    }
}