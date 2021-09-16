import React from "react";
import { Route, Redirect } from "react-router-dom";
import authService from "./services/authService";

const ProtectedRoute = ({ component: Component, ...rest }) => {
  return (
    <Route
      {...rest}
      render={(props) => {
        if (authService.isAuthenticated()) return <Component {...props} />;
        return <Redirect to="/" />;
      }}
    />
  );
};

export default ProtectedRoute;
