import * as msal from "@azure/msal-browser";

/**
 * Configuration object to be passed to MSAL instance on creation. 
 * For a full list of MSAL.js configuration parameters, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/configuration.md 
 */
export const MSAL_CONFIG = {
    auth: {
        clientId: "fb16db61-6486-488b-bdcc-152d057f0b10",
        authority: "https://login.microsoftonline.com/cad5b6a5-080f-4b24-b122-3d53f8627b04",
        redirectUri: "http://localhost:3000",
        navigateToLoginRequestUrl: true,
    },
    cache: {
        cacheLocation: "sessionStorage", // This configures where your cache will be stored
        storeAuthStateInCookie: false, // Set this to "true" if you are having issues on IE11 or Edge
    },
    system: {	
        loggerOptions: {	
            loggerCallback: (level, message, containsPii) => {	
                if (containsPii) {		
                    return;		
                }		
                switch (level) {		
                    case msal.LogLevel.Error:		
                        console.error(message);		
                        return;		
                    case msal.LogLevel.Info:		
                        console.info(message);		
                        return;		
                    case msal.LogLevel.Verbose:		
                        console.debug(message);		
                        return;		
                    case msal.LogLevel.Warning:		
                        console.warn(message);		
                        return;		
                }	
            }	
        }	
    }
};

/**
 * Scopes you add here will be prompted for user consent during sign-in.
 * By default, MSAL.js will add OIDC scopes (openid, profile, email) to any login request.
 * For more information about OIDC scopes, visit: 
 * https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-permissions-and-consent#openid-connect-scopes
 */
export const LOGIN_REQUEST = {
    scopes: ["openid", "profile", "email", "offline_access", "api://728b07c2-ceba-402b-b41a-b3541196e0b5/Employees.ReadReport.All"]
};

/**
 * Add here the scopes to request when obtaining an access token for MS Graph API. For more information, see:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/resources-and-scopes.md
 */
export const TOKEN_REQUEST = {
    scopes: ["openid", "profile", "email", "offline_access","api://728b07c2-ceba-402b-b41a-b3541196e0b5/Employees.ReadReport.All"],
    forceRefresh: false // Set this to "true" to skip a cached token and go to the server to get a new token
};
