using DevExpress.XtraReports.Web.ClientControls;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net.Mime;
using System.Security.Cryptography;

namespace Report.Core
{
    public interface IExportResultProvider
    {
        bool TryGetExportResult(string oneTimeToken, out ExportResult exportResult);
    }

    public class ExportedDocumentService : IWebDocumentViewerExportResultUriGenerator, IExportResultProvider
    {
        readonly string basePath;
        readonly string baseUrl;
        const string metaFileExt = ".meta";
        const string dataFileExt = ".data";

        ConcurrentDictionary<string, ExportResult> documents = new ConcurrentDictionary<string, ExportResult>();
        public ExportedDocumentService(string basePath, string baseUrl)
        {
            this.basePath = basePath;
            this.baseUrl = baseUrl;
            if (!Directory.Exists(basePath))
                Directory.CreateDirectory(basePath);
        }

        public string CreateUri(string exportOperationId, ExportedDocument exportedDocument)
        {
            var oneTimeToken = GetOneTimeAccessToken();
            var exportResult = new ExportResult()
            {
                FileName = exportedDocument.FileName,
                ExportOperationId = exportOperationId,
                ContentType = exportedDocument.ContentType,
                ContentDisposition = exportedDocument.ContentDisposition ?? DispositionTypeNames.Attachment
            };
            exportResult.AssignBytes(exportedDocument.Bytes);
            SaveInMemory(oneTimeToken, exportResult);
            SaveToFile(oneTimeToken, exportResult);

            return baseUrl + "?token=" + oneTimeToken;
        }

        public bool TryGetExportResult(string oneTimeToken, out ExportResult exportResult)
        {
            return TryLoadFromMemory(oneTimeToken, out exportResult);
        }

        void SaveInMemory(string oneTimeToken, ExportResult exportResult)
        {
            documents.AddOrUpdate(oneTimeToken, exportResult, (_id, _result) => exportResult);
        }

        void SaveToFile(string oneTimeToken, ExportResult exportResult)
        {
            var jsonString = JsonConvert.SerializeObject(exportResult);
            File.WriteAllText(Path.Combine(basePath, oneTimeToken + metaFileExt), jsonString);
            File.WriteAllBytes(Path.Combine(basePath, oneTimeToken + dataFileExt), exportResult.GetBytes());
        }

        bool TryLoadFromMemory(string oneTimeToken, out ExportResult exportResult)
        {
            return documents.TryRemove(oneTimeToken, out exportResult);
        }

        string GetOneTimeAccessToken()
        {
            byte[] data = new byte[16];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(data);
            }
            return new Guid(data).ToString("N");
        }
    }

    public class ExportResult
    {
        byte[] documentBytes;
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string ExportOperationId { get; set; }
        public string ContentDisposition { get; set; }
        public DateTime TimeStamp { get; private set; }
        public ExportResult()
        {
            TimeStamp = DateTime.UtcNow;
        }
        public void AssignBytes(byte[] data)
        {
            documentBytes = data;
        }
        public byte[] GetBytes()
        {
            return documentBytes;
        }
    }
}
