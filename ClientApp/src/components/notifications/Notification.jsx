import React, { useEffect, useState } from "react";
import notificationService from "../../services/notificationService";

const Notification = (props) => {
  const { data } = props;

  return <div>{data}</div>;
};

export default Notification;
