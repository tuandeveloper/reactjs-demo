import React from "react";
import ko from "knockout";
import "devexpress-reporting/dx-webdocumentviewer";
import { PreviewElements } from "devexpress-reporting/scopes/reporting-viewer";
import { AsyncExportApproach } from "devexpress-reporting/scopes/reporting-viewer-settings";
import { getTokenRedirect } from "../authentication/authRedirect";
import { TOKEN_REQUEST } from "../authentication/authConfig";
import { ajaxSetup } from "@devexpress/analytics-core/analytics-utils";
import "./reportViewer.css";

export class ReportViewer extends React.Component {
  constructor(props) {
    super(props);
    this.reportUrl = ko.observable(props.ReportName);
    this.reportRef = React.createRef();
    this.search = this.search.bind(this);
    this.state = { value: "" };

    this.handleChange = this.handleChange.bind(this);

    //https://supportcenter.devexpress.com/ticket/details/t714576/adding-authentication-to-the-html5-report-viewer-component-asp-net-core-angular
    AsyncExportApproach(true);

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
        console.log("Error", e);
      },
      CustomizeLocalization: function (s, e) {
        s.UpdateLocalization({
          "ASPxReportsStringId.WebDocumentViewer_OpenReportError":
            "Could not open report",
        });
      },
    };
  }

  handleChange(event) {
    this.setState({ value: event.target.value });
  }

  search(ref) {
    ko.cleanNode(ref);
    ko.applyBindings(
      {
        reportUrl: `${this.props.ReportName}?personName=${this.state.value}`,
        requestOptions: this.requestOptions,
        callbacks: this.callbacks,
      },
      this.reportRef.current
    );
  }

  render() {
    return (
      <React.Fragment>
        <div
          className="container"
          style={{ display: this.props.showSearchPanel ? "block" : "none" }}
        >
          <div className="row">
            <input
              type="text"
              placeholder="PersonName"
              value={this.state.value}
              onChange={this.handleChange}
            />

            <button onClick={() => this.search(this.reportRef.current)}>
              Search
            </button>
          </div>
        </div>
        <div style={{ width: "100%", height: "700px" }}>
          <div ref={this.reportRef} data-bind="dxReportViewer: $data" />
        </div>
      </React.Fragment>
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
        },
        this.reportRef.current
      );
    })
    .catch((error) => {
      console.error(error);
    });
  }

  componentWillUnmount() {
    ko.cleanNode(this.reportRef.current);
  }
}
