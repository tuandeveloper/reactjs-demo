import { MenuItems } from "./menu-items";
import React, { useState } from "react";
import "./navbar.css";
import { Link } from "react-router-dom";
import { useIsAuthenticated } from "@azure/msal-react";
import { signIn, signOut } from '../../common/authentication/authRedirect';

export function Navbar() {
  const [clicked, updateClicked] = useState(false);
  const handleClick = () => {
    updateClicked(!clicked);
  };

  const isAuthenticated = useIsAuthenticated();

  return (
    <>
      <nav className="navbar-item">
        <h1 className="navbar-logo">
          <Link className="nav-links" to='/'>Epayroll</Link>
        </h1>
        <div className="menu-icon" onClick={handleClick}>
          <i className={clicked ? "fas fa-times" : "fas fa-bars"}></i>
        </div>
        <ul className={clicked ? "nav-menu active" : "nav-menu"}>
          {isAuthenticated && 
            MenuItems.map((item, index) => {
              return (
                <li key={index}>
                  <Link to={item.url} className={item.className}>
                    {item.title}
                  </Link>
                </li>
              );
            })
          }
          {isAuthenticated &&
          <li>
            <a className='nav-links' href="#/" onClick={signOut}>Sign Out</a>
          </li>
          }
          {!isAuthenticated &&
            <li>
              <a className='nav-links' href="#/" onClick={signIn}>Sign In</a>
            </li>
          }
        </ul>
      </nav>
    </>
  );
}
