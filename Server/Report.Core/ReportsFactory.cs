using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using Report.Core.Designer;
using Report.Core.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Report.Core
{
    public static class ReportsFactory
    {
        public static Dictionary<string, Func<NameValueCollection, XtraReport>> Reports = new Dictionary<string, Func<NameValueCollection, XtraReport>>()
        {
            ["EmployeeReport"] = (NameValueCollection param) =>
            {
                var report = new DDEmployeeReport();
                report.DataSource = CreateObjectDataSource(typeof(EmployeeList), param);
                return report;
            },
            ["AnnualSalaryReport"] = (NameValueCollection param) =>
            {
                var report = new DDAnnualSalaryReport();
                report.DataSource = CreateObjectDataSource(typeof(AnnualSalaryReportData), param);
                return report;
            }
        };

        private static object CreateObjectDataSource(Type entityType, NameValueCollection param)
        {
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.DataSource = entityType;

            //NameValueCollection can't deserialize
            //Convert to dictionary
            var dictionary = param != null ? param.AllKeys.ToDictionary(k => k, k => param[k]) : default(Dictionary<string, string>);
            var parameter = new Parameter("parameter", typeof(Dictionary<string, string>), dictionary);
            dataSource.Constructor = new ObjectConstructorInfo(parameter);
            return dataSource;
        }

 
    }
}
