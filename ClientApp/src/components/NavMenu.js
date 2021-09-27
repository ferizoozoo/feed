import React, { Component, useState } from "react";
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";
import "./NavMenu.css";
import { useRecoilState, useRecoilValue } from "recoil";
import authAtom from "../states/authAtom";
import authService from "../services/authService";

export const NavMenu = (props) => {
  // Hooks
  const [collapsed, setCollapsed] = useState(true);

  // Recoil
  const [isAuthenticated, setIsAuthenticated] = useRecoilState(authAtom);

  const toggleNavbar = () => {
    setCollapsed((p) => !p);
  };

  const _handleLogout = () => {
    authService.logout();
    setIsAuthenticated(false);
  };

  return (
    <header>
      <Navbar
        className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
        light
      >
        <Container>
          <NavbarBrand tag={Link} to="/">
            feed
          </NavbarBrand>
          <NavbarToggler onClick={toggleNavbar} className="mr-2" />
          <Collapse
            className="d-sm-inline-flex flex-sm-row-reverse"
            isOpen={!collapsed}
            navbar
          >
            <ul className="navbar-nav flex-grow">
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/">
                  Home
                </NavLink>
              </NavItem>
              <NavItem>
                <NavLink tag={Link} className="text-dark" to="/sendPost">
                  New Post
                </NavLink>
              </NavItem>
              {!isAuthenticated ? (
                <>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/user/login">
                      Login
                    </NavLink>
                  </NavItem>
                  <NavItem>
                    <NavLink
                      tag={Link}
                      className="text-dark"
                      to="/user/register"
                    >
                      Register
                    </NavLink>
                  </NavItem>
                </>
              ) : (
                <NavLink
                  tag={Link}
                  className="text-dark"
                  to="/user/login"
                  onClick={_handleLogout}
                >
                  Logout
                </NavLink>
              )}
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
