using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using Report.Core.Designer;
using Report.Core.Entity;
using System;
using System.Collections.Generic;

namespace Report.Core
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
        {
            ["EmployeeReport"] = () =>
            {
                var report = new DDEmployeeReport();
                report.DataSource = CreateObjectDataSource();
                return report;
            },
            ["AnnualSalaryReport"] = () =>
            {
                var report = new DDAnnualSalaryReport();
                report.DataSource = CreateAlObjectDataSource();
                return report;
            }
        };

        private static object CreateObjectDataSource()
        {
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.DataSource = typeof(EmployeeList);

            dataSource.Constructor = ObjectConstructorInfo.Default;
            dataSource.DataMember = "Items";
            return dataSource;
        }

        private static object CreateAlObjectDataSource()
        {
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.DataSource = typeof(AnnualSalaryReportData);
            dataSource.Constructor = ObjectConstructorInfo.Default;
            return dataSource;
        }
    }
}
