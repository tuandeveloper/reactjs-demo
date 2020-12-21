import React from "react";
import ko from "knockout";
import "devexpress-reporting/dx-webdocumentviewer";
import { PreviewElements } from "devexpress-reporting/scopes/reporting-viewer";

export class ReportMigration extends React.Component {
  constructor(props) {
    super(props);
    this.reportUrl = ko.observable("MigratedReport");
    this.requestOptions = {
      host: "http://localhost:56061/",
      invokeAction: "DXXRDV",
    };
    this.callbacks = {
      CustomizeElements: function (s, e) {
        var panelPart = e.GetById(PreviewElements.RightPanel);
        var index = e.Elements.indexOf(panelPart);
        e.Elements.splice(index, 1);
      },
    };
  }

  render() {
    return (
      <div style={{ width: "100%", height: "1000px" }}>
        <div ref="viewer" data-bind="dxReportViewer: $data" />
      </div>
    );
  }

  componentDidMount() {
    ko.applyBindings(
      {
        reportUrl: this.reportUrl,
        requestOptions: this.requestOptions,
        callbacks: this.callbacks,
      },
      this.refs.viewer
    );
  }

  componentWillUnmount() {
    ko.cleanNode(this.refs.viewer);
  }
}
