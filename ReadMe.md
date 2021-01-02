

# Prerequisite
  - ASP.NET Core 3.1
  - ReactJS 17.0.1
  
# How to install 
- Server side  ([Document](https://docs.devexpress.com/XtraReports/400197/web-reporting/javascript-reporting/server-side-configuration/document-viewer/document-viewer-server-side-configuration-asp-net-core))

1- Install Devpress with Reporting module [Trial version](https://www.devexpress.com/products/try/)

2- Install DevExpress.AspNetCore.Reporting package

![](https://docs.devexpress.com/XtraReports/images/viewer-server-side-install-nuget.png)
3- Open the Startup.cs file and modify it to configure services as demonstrated below.
```sh
using DevExpress.AspNetCore;
using DevExpress.AspNetCore.Reporting;
//...

public class Startup {
//...
   public void ConfigureServices(IServiceCollection services) {
     // Register reporting services in an application's dependency injection container.
      services.AddDevExpressControls();
      // Use the AddMvcCore (or AddMvc) method to add MVC services.
       services.AddMvcCore(); 
 }

 public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
       // ...
       app.UseStaticFiles();
       // Initialize reporting services.
       app.UseDevExpressControls();
        // ...
  }
}
```

- Client side  ([Document](https://docs.devexpress.com/XtraReports/119338/web-reporting/javascript-reporting/react/document-viewer/integration/document-viewer-integration-in-react))

