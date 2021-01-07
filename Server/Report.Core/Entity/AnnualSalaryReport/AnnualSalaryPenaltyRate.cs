using System;

namespace Report.Core.Entity
{
    public class AnnualSalaryPenaltyRate : AnnualSalaryReportBase
    {
        /// <summary>
        /// Saturday hour
        /// </summary>
        public double SaturdayHour { get; set; }

        /// <summary>
        /// Saturday hour string
        /// </summary>
        public string SaturdayHourString { get => ConvertToString(TimeSpan.FromHours(SaturdayHour)); }

        /// <summary>
        /// Sunday hour
        /// </summary>
        public double SundayHour { get; set; }

        /// <summary>
        /// Sunday hour string
        /// </summary>
        public string SundayHourString { get => ConvertToString(TimeSpan.FromHours(SundayHour)); }

        /// <summary>
        /// 7am to 7pm
        /// </summary>
        public double SevenAmToSeventPm { get; set; }

        /// <summary>
        /// 7am to 7pm string
        /// </summary>
        public string SevenAmToSeventPmString { get => ConvertToString(TimeSpan.FromHours(SevenAmToSeventPm)); }

        /// <summary>
        /// Total
        /// </summary>
        public double Total { get => SaturdayHour + SundayHour + SevenAmToSeventPm; }

        /// <summary>
        /// Total string
        /// </summary>
        public string TotalString { get => ConvertToString(TimeSpan.FromHours(Total)); }

        /// <summary>
        /// Penalty threshold
        /// </summary>
        public double PenaltyThreshold { get; set; }

        /// <summary>
        /// Penalty threshold string
        /// </summary>
        public string PenaltyThresholdString { get => ConvertToString(TimeSpan.FromHours(PenaltyThreshold)); }

        /// <summary>
        /// Additional penalty threshold
        /// </summary>
        public double AdditionalPenaltyHour { get => Total - PenaltyThreshold < 0 ? 0 : Total - PenaltyThreshold; }

        /// <summary>
        /// Additional penalty threshold string
        /// </summary>
        public string AdditionalPenaltyHourString { get => ConvertToString(TimeSpan.FromHours(AdditionalPenaltyHour)); }
    }
}