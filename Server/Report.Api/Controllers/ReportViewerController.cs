using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Report.Api.Controllers
{
    [Route("ReportViewer")]
    [Authorize]
    public class ReportViewerController : WebDocumentViewerController
    {
        public ReportViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService)
        {
        }

        public override Task<IActionResult> Invoke()
        {
            return base.Invoke();
        }
    }
}
