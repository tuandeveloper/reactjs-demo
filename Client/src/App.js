import { Navbar } from "./components/navbar/navbar";
import "./App.css";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Employees } from "./pages/employees/employees";
import { Home } from "./pages/home/home";
import 'devextreme/dist/css/dx.common.css';
import 'devextreme/dist/css/dx.material.blue.light.compact.css';

function App(props) {
  return (
    <>
      <Router>
        <Navbar />
        <div className="content">
          <Switch>
            <Route path="/" exact component={Home} />
            <Route path="/home" component={Home} />
            <Route path="/employees" component={Employees} />
          </Switch>
        </div>
      </Router>
    </>
  );
}

export default App;
