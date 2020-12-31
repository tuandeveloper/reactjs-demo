import { MenuItems } from "./menu-items";
import React, { useState } from "react";
import { Button } from "../button";
import "./navbar.css";
import { Link } from "react-router-dom";

export function Navbar() {
  const [clicked, updateClicked] = useState(false);
  const handleClick = () => {
    updateClicked(!clicked);
  };

  return (
    <nav className="navbar-item">
      <h1 className="navbar-logo">Epayroll</h1>
      <div className="menu-icon" onClick={handleClick}>
        <i className={clicked ? "fas fa-times" : "fas fa-bars"}></i>
      </div>
      <ul className={clicked ? "nav-menu active" : "nav-menu"}>
        {MenuItems.map((item, index) => {
          return (
            <li key={index}>
              <Link to={item.url} className={item.className}>
                {item.title}
              </Link>
            </li>
          );
        })}
      </ul>
    </nav>
  );
}
