using DevExpress.XtraReports.UI;
using Reporting.Designer;
using System;
using System.Collections.Generic;

namespace Report.Api.PredefinedReports
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["DDDEmployeeReport"] = () => new DDEmployeeReport()
        };
    }
}
