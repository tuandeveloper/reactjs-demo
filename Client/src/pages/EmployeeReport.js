import { ReportViewer } from "../common/reportviewer/reportViewer";
import {useIsAuthenticated} from '@azure/msal-react';
import { AccessDenied } from "../components/AccessDenied";

export const EmployeeReport = () => {
  const isAuthenticated = useIsAuthenticated();
  if (!isAuthenticated) return <AccessDenied />;

  return(
    <>
      <ReportViewer ReportName="EmployeeReport" showSearchPanel="true" />
    </>
  )
}