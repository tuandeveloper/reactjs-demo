import * as msal from "@azure/msal-browser";
import {CLIENT_APPLICATION, LOGIN_REQUEST, TOKEN_REQUEST} from './authConfig';
import { callMSGraph } from './graph';
import { GRAPH_CONFIG } from './graphConfig';
import {REPORT_API} from '../appConfig';

// Create the main myMSALObj instance
// configuration parameters are located at authConfig.js
const myMSALObj = CLIENT_APPLICATION;

let username = "";

/**
 * A promise handler needs to be registered for handling the
 * response returned from redirect flow. For more information, visit:
 * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/acquire-token.md
 */
// myMSALObj.handleRedirectPromise()
//     .then(handleResponse)
//     .catch((error) => {
//         console.error(error);
//     });

export function selectAccount() {

    /**
     * See here for more info on account retrieval: 
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
     */

    const currentAccounts = myMSALObj.getAllAccounts();

    if (currentAccounts.length === 0) {
        return;
    } else if (currentAccounts.length > 1) {
        // Add your account choosing logic here
        console.warn("Multiple accounts detected.");
    } else if (currentAccounts.length === 1) {
        username = currentAccounts[0].username;
        console.log(username);
    }
}

export function handleResponse(response) {
    if (response !== null) {
        username = response.account.username;
        console.log(username);
    } else {
        selectAccount();
    }
}

export function signIn() {

    /**
     * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
     */

    myMSALObj.loginRedirect(LOGIN_REQUEST);
}

export function signOut() {

    /**
     * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
     */

    // Choose which account to logout from by passing a username.
    const logoutRequest = {
        account: myMSALObj.getAccountByUsername(username)
    };

    myMSALObj.logout(logoutRequest);
}

export function getTokenRedirect(request) {
    /**
     * See here for more info on account retrieval: 
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
     */

    if (username) {
        request.account = myMSALObj.getAccountByUsername(username);
    } else {
        const currentAccounts = myMSALObj.getAllAccounts();
        if (currentAccounts.length === 0) {
            return;
        } else if (currentAccounts.length > 1) {
            // Add your account choosing logic here
            console.warn("Multiple accounts detected.");
        } else if (currentAccounts.length === 1) {
            request.account = currentAccounts[0];
            username = currentAccounts[0].username;
            console.log(username);
        }
    }

    return myMSALObj.acquireTokenSilent(request)
        .catch(error => {
            console.warn("silent token acquisition fails. acquiring token using redirect");
            if (error instanceof msal.InteractionRequiredAuthError) {
                // fallback to interaction when silent call fails
                return myMSALObj.acquireTokenRedirect(request);
            } else {
                console.warn(error);   
            }
        });
}

function updateUI(response, endpoint) {
    console.log(`Response`, response);
    console.log(`Endpoint`, endpoint);
}

export function seeProfile() {
    getTokenRedirect(LOGIN_REQUEST)
        .then(response => {
            callMSGraph(GRAPH_CONFIG.graphMeEndpoint, response.accessToken, updateUI);
        }).catch(error => {
            console.error(error);
        });
}

export function readMail() {
    getTokenRedirect(TOKEN_REQUEST)
        .then(response => {
            callMSGraph(GRAPH_CONFIG.graphMailEndpoint, response.accessToken, updateUI);
        }).catch(error => {
            console.error(error);
        });
}


export function callTestController() {
    getTokenRedirect(TOKEN_REQUEST)
        .then(response1 => {
            console.log(response1);
            const headers = new Headers();
            const bearer = `Bearer ${response1.accessToken}`;
        
            headers.append("Authorization", bearer);
        
            const options = {
                method: "GET",
                headers: headers
            };
        
            console.log('request made to Graph API at: ' + new Date().toString());
        
            fetch(REPORT_API.endpoint, options)
                .then(response => response.json())
                .then(response => console.log(response))
                .catch(error => console.log(error));
        }).catch(error => {
            console.error(error);
        });
}

