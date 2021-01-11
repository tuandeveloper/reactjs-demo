import * as msal from "@azure/msal-browser";
import {LOGIN_REQUEST, TOKEN_REQUEST} from './authConfig';
import {callMSGraph} from './graph';
import {GRAPH_CONFIG} from './graphConfig';
import {CLIENT_APPLICATION} from './authConfig';

let username = "";

export function selectAccount() {

    /**
     * See here for more info on account retrieval: 
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
     */

    const currentAccounts = CLIENT_APPLICATION.getAllAccounts();
    if (currentAccounts.length === 0) {
        return;
    } else if (currentAccounts.length > 1) {
        // Add choose account code here
        console.warn("Multiple accounts detected.");
    } else if (currentAccounts.length === 1) {
        username = currentAccounts[0].username;
        console.log(username);
    }
}

export function handleResponse(response) {
    /**
     * To see the full list of response object properties, visit:
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#response
     */

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
    CLIENT_APPLICATION.loginPopup(LOGIN_REQUEST)
        .then(handleResponse)
        .catch(error => {
            console.error(error);
        });
}

export function signOut() {

    /**
     * You can pass a custom request object below. This will override the initial configuration. For more information, visit:
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-browser/docs/request-response-object.md#request
     */

    // Choose which account to logout from by passing a username.

    const logoutRequest = {
        account: CLIENT_APPLICATION.getAccountByUsername(username)
    };

    CLIENT_APPLICATION.logout(logoutRequest);
}

export function getTokenPopup(request) {

    /**
     * See here for more info on account retrieval: 
     * https://github.com/AzureAD/microsoft-authentication-library-for-js/blob/dev/lib/msal-common/docs/Accounts.md
     */
    request.account = CLIENT_APPLICATION.getAccountByUsername(username);
    
    return CLIENT_APPLICATION.acquireTokenSilent(request)
        .catch(error => {
            console.warn("silent token acquisition fails. acquiring token using popup");
            if (error instanceof msal.InteractionRequiredAuthError) {
                // fallback to interaction when silent call fails
                return CLIENT_APPLICATION.acquireTokenPopup(request)
                    .then(tokenResponse => {
                        console.log(tokenResponse);
                        return tokenResponse;
                    }).catch(error => {
                        console.error(error);
                    });
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
    getTokenPopup(LOGIN_REQUEST)
        .then(response => {
            callMSGraph(GRAPH_CONFIG.graphMeEndpoint, response.accessToken, updateUI);
        }).catch(error => {
            console.error(error);
        });
}

export function readMail() {
    getTokenPopup(TOKEN_REQUEST)
        .then(response => {
            callMSGraph(GRAPH_CONFIG.graphMailEndpoint, response.accessToken, updateUI);
        }).catch(error => {
            console.error(error);
        });
}

selectAccount();
