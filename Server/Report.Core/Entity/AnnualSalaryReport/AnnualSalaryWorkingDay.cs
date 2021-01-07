
using System;

namespace Report.Core.Entity
{
    public class AnnualSalaryWorkingDay : AnnualSalaryReportBase
    {
        /// <summary>
        /// Start hours
        /// </summary>
        public TimeSpan StartHour { get; set; }

        /// <summary>
        /// Start hours string
        /// </summary>
        public string StartHourString { get => ConvertToString(StartHour); }

        /// <summary>
        /// End hours
        /// </summary>
        public TimeSpan EndHour { get; set; }

        /// <summary>
        /// End hours string
        /// </summary>
        public string EndHourString { get => ConvertToString(EndHour); }

        /// <summary>
        /// Calculated hour
        /// </summary>
        public TimeSpan CalHour { get; set; }

        /// <summary>
        /// Cal hours string
        /// </summary>
        public string CalHourString { get => ConvertToString(CalHour); }


        /// <summary>
        /// Roster start hours
        /// </summary>
        public TimeSpan RosterStartHour { get; set; }

        /// <summary>
        /// Roster start hours string
        /// </summary>
        public string RosterStartHourString { get => ConvertToString(RosterStartHour); }

        /// <summary>
        /// Roster end hours
        /// </summary>
        public TimeSpan RosterEndHour { get; set; }

        /// <summary>
        /// Roster end hours string
        /// </summary>
        public string RosterEndHourString { get => ConvertToString(RosterEndHour); }

        /// <summary>
        /// Roster calculated hour
        /// </summary>
        public TimeSpan RosterCalHour { get; set; }

        /// <summary>
        /// Roster cal hours string
        /// </summary>
        public string RosterCalHourString { get => ConvertToString(RosterCalHour); }

        /// <summary>
        /// Date type
        /// </summary>
        public string DateType { get; set; }

        /// <summary>
        /// The action type
        /// </summary>
        public AnnualSalaryActionType ActionType { get; set; }
    }
}