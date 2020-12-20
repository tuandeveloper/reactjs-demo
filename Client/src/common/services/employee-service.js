import serviceBase from './service-base';

export class EmployeeService extends serviceBase {
    getEmployees = () => {
        return this.client.get("/mock/employees.json");
    }
}

