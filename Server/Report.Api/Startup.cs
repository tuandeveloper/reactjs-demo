using DevExpress.AspNetCore;
using DevExpress.XtraReports.Web.Extensions;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Report.Core;
using System.IO;

namespace Report.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddMicrosoftIdentityWebApi(Configuration);

            services.AddAuthorization();

            services.AddCors(options => {
                options.AddPolicy("AllowCorsPolicy", builder => {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

            services.AddMvcCore();

            //Register Report services
            services.AddDevExpressControls();
            services.AddScoped<ReportStorageWebExtension, MyReportStorageWebExtension>();

            //Exporting
            var exportedDocumentService = new ExportedDocumentService(Path.Combine(HostingEnvironment.ContentRootPath, "/ExportedDocuments/"), "http://localhost:5000/ReportViewer/GetExportResult");
            services.AddSingleton<IWebDocumentViewerExportResultUriGenerator>(exportedDocumentService);
            services.AddSingleton<IExportResultProvider>(exportedDocumentService);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            // Initialize reporting services.
            app.UseDevExpressControls();

            app.UseCors("AllowCorsPolicy");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
