using DevExpress.XtraReports.UI;
using Report.Core.Deisnger;
using System;
using System.Collections.Generic;

namespace Report.Core
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
             ["EmployeeReport"] = () => new DDEmployeeReport(),
        };
    }
}
