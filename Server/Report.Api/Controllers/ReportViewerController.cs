using DevExpress.AspNetCore.Reporting.WebDocumentViewer;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Report.Core;
using System.Threading.Tasks;

namespace Report.Api.Controllers
{
    [Route("ReportViewer")]
    public class ReportViewerController : WebDocumentViewerController
    {
        private IExportResultProvider _documentExportService;

        public ReportViewerController(IWebDocumentViewerMvcControllerService controllerService, IExportResultProvider documentExportService) : base(controllerService)
        {
            _documentExportService = documentExportService;
        }

        [Authorize]
        public override Task<IActionResult> Invoke()
        {
            return base.Invoke();
        }

        [AllowAnonymous]
        [Route("GetExportResult")]
        public ActionResult GetExportResult(string token, string fileName)
        {
            ExportResult exportResult;
            if (!_documentExportService.TryGetExportResult(token, out exportResult))
            {
                return NotFound("Exported document was not found. Try to export the document once again.");
            }
            var fileResult = File(exportResult.GetBytes(), exportResult.ContentType);
            if (exportResult.ContentDisposition != System.Net.Mime.DispositionTypeNames.Inline)
            {
                fileResult.FileDownloadName = exportResult.FileName;
            }

            return fileResult;
        }
    }
}
