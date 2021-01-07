import React from "react";
import ko from "knockout";
import "devexpress-reporting/dx-webdocumentviewer";
import { PreviewElements } from "devexpress-reporting/scopes/reporting-viewer";
import { getTokenRedirect } from "../authentication/authRedirect";
import { TOKEN_REQUEST } from "../authentication/authConfig";
import { ajaxSetup } from "@devexpress/analytics-core/analytics-utils";
import "./reportViewer.css";
export class ReportViewer extends React.Component {
  constructor(props) {
    super(props);
    this.reportUrl = ko.observable(props.ReportName);

    //Request option
    //https://docs.devexpress.com/XtraReports/118985/web-reporting/javascript-reporting/knockout/document-viewer/document-viewer-client-side-configuration-knockout
    this.requestOptions = {
      host: "http://localhost:5000/",
      invokeAction: "ReportViewer",
    };

    //Event builder
    //https://docs.devexpress.com/XtraReports/DevExpress.AspNetCore.Reporting.ReportDesigner.ReportDesignerClientSideEventsBuilder._methods
    this.callbacks = {
      CustomizeElements: function (s, e) {
        var panelPart = e.GetById(PreviewElements.RightPanel);
        var index = e.Elements.indexOf(panelPart);
        e.Elements.splice(index, 1);
      },
      OnServerError: function (s, e) {
        console.log("Error", s);
      },
      CustomizeLocalization: function (s, e) {
        s.UpdateLocalization({
          "ASPxReportsStringId.WebDocumentViewer_OpenReportError":
            "Could not open report",
        });
      },
    };
  }

  render() {
    return (
      <div style={{ width: "100%", height: "700px" }}>
        <div ref="viewer" data-bind="dxReportViewer: $data" />
      </div>
    );
  }

  componentDidMount() {
    getTokenRedirect(TOKEN_REQUEST)
      .then((response) => {
        if (response) {
          ajaxSetup.ajaxSettings = {
            headers: { Authorization: "Bearer " + response.accessToken },
          };
        }

        ko.applyBindings(
          {
            reportUrl: this.reportUrl,
            requestOptions: this.requestOptions,
            callbacks: this.callbacks,
            remoteSettings: this.remoteSettings,
          },
          this.refs.viewer
        );
      })
      .catch((error) => {
        console.error(error);
      });
  }

  componentWillUnmount() {
    ko.cleanNode(this.refs.viewer);
  }
}
