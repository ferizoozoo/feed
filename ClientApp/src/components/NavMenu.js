import React, { Component, useEffect, useState } from "react";
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
import userAtom from "../states/userAtom";
import notificationService from "../services/notificationService";

export const NavMenu = (props) => {
  // Hooks
  const [collapsed, setCollapsed] = useState(true);
  const [totalUnseenNotificationCount, setTotalUnseenNotificationCount] = useState();

  // Recoil
  const [isAuthenticated, setIsAuthenticated] = useRecoilState(authAtom);
  const user = useRecoilValue(userAtom);

  const toggleNavbar = () => {
    setCollapsed((p) => !p);
  };

  const _handleLogout = () => {
    authService.logout();
    setIsAuthenticated(false);
  };

  const _getNotificationCount = async () => {
    const res = await notificationService.getUserTotalUnseenNotificationCount(user.id);
    const data = await res.json();
    setTotalUnseenNotificationCount(data);
  }

  useEffect(() => {
    _getNotificationCount()
  }, [])

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
                <>
                  <NavLink
                    tag={Link}
                    className="text-dark"
                    to="/"
                    onClick={_handleLogout}
                  >
                    Logout
                  </NavLink>
                  <NavItem>
                    <NavLink tag={Link} className="text-dark" to="/notifications/list">
                      <span style={{ marginBottom: '4px' }}><svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-bell" viewBox="0 0 16 16">
                        <path d="M8 16a2 2 0 0 0 2-2H6a2 2 0 0 0 2 2zM8 1.918l-.797.161A4.002 4.002 0 0 0 4 6c0 .628-.134 2.197-.459 3.742-.16.767-.376 1.566-.663 2.258h10.244c-.287-.692-.502-1.49-.663-2.258C12.134 8.197 12 6.628 12 6a4.002 4.002 0 0 0-3.203-3.92L8 1.917zM14.22 12c.223.447.481.801.78 1H1c.299-.199.557-.553.78-1C2.68 10.2 3 6.88 3 6c0-2.42 1.72-4.44 4.005-4.901a1 1 0 1 1 1.99 0A5.002 5.002 0 0 1 13 6c0 .88.32 4.2 1.22 6z" />
                      </svg><span class="badge badge-danger" style={{ borderRadius: '50%'}}>{totalUnseenNotificationCount}</span></span>
                    </NavLink>
                  </NavItem>
                </>
              )}
            </ul>
          </Collapse>
        </Container>
      </Navbar>
    </header>
  );
};
