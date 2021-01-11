import { Navbar } from "./components/navbar/navbar";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Home } from "./pages/home/home";
import "devextreme/dist/css/dx.common.css";
import "devextreme/dist/css/dx.material.blue.light.compact.css";
import "@devexpress/analytics-core/dist/css/dx-analytics.common.css";
import "@devexpress/analytics-core/dist/css/dx-analytics.light.compact.css";
import "devexpress-reporting/dist/css/dx-webdocumentviewer.css";
import "jquery-ui/themes/base/all.css";
import { Counter } from "./pages/Counter";
import { EmployeeReport } from "./pages/EmployeeReport";
import { AnnualSalaryReport } from "./pages/AnnualSalaryReport";

function App(props) {
  return (
    <>
      <Router>
        <Navbar />
        <div className="content">
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/home" component={Home} />
            <Route path="/employees" component={EmployeeReport} />
            <Route path="/annualsalary" component={AnnualSalaryReport} />
            <Route path="/counter" component={Counter} />
          </Switch>
        </div>
      </Router>
    </>
  );
}

export default App;
