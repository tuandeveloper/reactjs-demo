import React from "react";
import ko from "knockout";

export class Employees extends React.Component {
  constructor(props) {
    super(props);
    this.reportUrl = ko.observable("DDDEmployeeReport");
    this.requestOptions = {
      host: "http://localhost:56061/",
      invokeAction: "DXXRDV",
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
      },
      this.refs.viewer
    );
  }
  componentWillUnmount() {
    ko.cleanNode(this.refs.viewer);
  }
}
