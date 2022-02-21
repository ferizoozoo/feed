import React, { useEffect, useState } from "react";
import notificationService from "../../services/notificationService";

const NotificationsPage = (props) => {
  const { data } = props;

  return <div>{data}</div>;
};

export default NotificationsPage;
