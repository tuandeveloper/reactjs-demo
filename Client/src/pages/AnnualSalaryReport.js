import { ReportViewer } from "../common/reportviewer/reportViewer";
import {useIsAuthenticated} from '@azure/msal-react';
import { AccessDenied } from "../components/AccessDenied";

export const AnnualSalaryReport = () => {
  const isAuthenticated = useIsAuthenticated();

  if (!isAuthenticated) return <AccessDenied />;

  return (
    <>
      <ReportViewer ReportName="AnnualSalaryReport" />
    </>
  )
}