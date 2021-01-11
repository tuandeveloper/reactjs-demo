import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { MsalProvider } from "@azure/msal-react";
import {CLIENT_APPLICATION} from './common/authentication/authConfig';
import {ErrorBoundary} from './pages/ErrorBoundary';

ReactDOM.render(
  <ErrorBoundary>
    <MsalProvider instance={CLIENT_APPLICATION}>
      <App />
    </MsalProvider>
  </ErrorBoundary>,
  document.getElementById('root')
);
reportWebVitals();
