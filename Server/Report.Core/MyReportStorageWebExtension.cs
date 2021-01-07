using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;

namespace Report.Core
{
    public class MyReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
    {
        readonly string ReportDirectory;
        const string FileExtension = ".repx";

        public MyReportStorageWebExtension(IHostingEnvironment env)
        {
            var path = Directory.GetParent(env.ContentRootPath);
            ReportDirectory = Path.Combine(path.ToString(), "Report.Core\\Designer");
            if (!Directory.Exists(ReportDirectory))
            {
                Directory.CreateDirectory(ReportDirectory);
            }
        }
   
        public override byte[] GetData(string url)
        {
            // Returns report layout data stored in a Report Storage using the specified URL. 
            // This method is called only for valid URLs after the IsValidUrl method is called.
            try
            {
                HttpUtility.ParseQueryString("");
                var reportName = url.Split('?')[0];
                NameValueCollection requestParam = null;

                if (url.Split('?').Count() > 1)
                {
                    requestParam = HttpUtility.ParseQueryString(url.Split('?')[1]);
                }
                

                if (Directory.EnumerateFiles(ReportDirectory).Select(Path.GetFileNameWithoutExtension).Contains(reportName))
                {
                    return File.ReadAllBytes(Path.Combine(ReportDirectory, reportName + FileExtension));
                }
                if (ReportsFactory.Reports.ContainsKey(reportName))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        ReportsFactory.Reports[reportName]().SaveLayoutToXml(ms);
                        return ms.ToArray();
                    }
                }
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
            }
            catch (Exception)
            {
                throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
            }
        }
    }
}
