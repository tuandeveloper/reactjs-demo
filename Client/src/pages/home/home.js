import { callTestController, signIn, signOut } from '../../common/authentication/authRedirect';


export function Home () {

    function login() {
        signIn();
    }

    function logout() {
        signOut();
    }

    return (
        <>
            <p>Home</p>
            <button onClick={login}>Sign In</button>
            <button onClick={logout}>Sign Out</button>
            <button onClick={callTestController}>Call Tests</button>
        </>
    )
}