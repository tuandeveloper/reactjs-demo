
namespace Report.Core.Entity
{
    public class AnnualSalaryTotalEntity
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
        /// Saturday hour
        /// </summary>
        public decimal? SaturdayHour { get; set; }

        /// <summary>
        /// Sunday hour
        /// </summary>
        public decimal? SundayHour { get; set; }

        /// <summary>
        /// <> 7am to 7pm
        /// </summary>
        public decimal? SevenAmToSeventPm { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public decimal? Total { get => SaturdayHour + SundayHour + SevenAmToSeventPm; }

        /// <summary>
        /// Penalty threshold
        /// </summary>
        public decimal? PenaltyRateThreshold { get; set; }

        /// <summary>
        /// Additional penalty threshold
        /// </summary>
        public decimal? AdditionalPenaltyThreshold { get; set; }

        /// <summary>
        /// Overtime threshold
        /// </summary>
        public decimal? OverTimeThreshold { get; set; }
    }
}
