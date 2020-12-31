using DevExpress.XtraReports.UI;
using Report.Api.Reports;
using System;
using System.Collections.Generic;

namespace Report.Api.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
             ["EmployeeReport"] = () => new DDEmployeeReport(),
        };
    }
}
