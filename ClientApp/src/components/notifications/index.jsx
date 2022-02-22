import React from "react";
import { Route, Switch, useRouteMatch } from "react-router-dom";
import NotificationsPage from "./NotificationsPage";

const NotificationsRoute = () => {
  let { path } = useRouteMatch();

  return (
    <Switch>
      <Route exact path={`/notifications/list`} component={NotificationsPage} />
    </Switch>
  );
};

export default NotificationsRoute;
