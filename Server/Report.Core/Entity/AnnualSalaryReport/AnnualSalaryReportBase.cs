using System;

namespace Report.Core.Entity
{
    public class AnnualSalaryReportBase
    {
        /// <summary>
        /// Convert time span to string
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        protected string ConvertToString(TimeSpan timeSpan)
        {
            return timeSpan < TimeSpan.Zero ? $"{((long)timeSpan.TotalHours).ToString("d2")}:{Math.Abs(timeSpan.Minutes).ToString("d2")}" 
                : $"{((long)timeSpan.TotalHours).ToString("d2")}:{timeSpan.Minutes.ToString("d2")}";
        }
    }
}
