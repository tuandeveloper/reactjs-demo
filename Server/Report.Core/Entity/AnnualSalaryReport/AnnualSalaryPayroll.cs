using System;
using System.Collections.Generic;

namespace Report.Core.Entity
{
    public class AnnualSalaryPayroll
    {
        /// <summary>
        /// Payroll identifier
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Payroll start date
        /// </summary>
        public DateTime? Start { get; set; }

        /// <summary>
        /// Payroll end date
        /// </summary>
        public DateTime? End { get; set; }

        /// <summary>
        /// Employee list 
        /// </summary>
        public IList<AnnualSalaryEmployee> Employees { get; set; }
    }
}
