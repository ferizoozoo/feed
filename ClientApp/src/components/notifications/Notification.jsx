import React, { useEffect, useState } from "react";
import moment from "moment";
import notificationService from "../../services/notificationService";

import "./Notification.css";

const Notification = (props) => {
  const { data } = props;
  const { content, createdAt, seen } = data;

  return (
    <div
      className="notification"
      style={
        seen ? { backgroundColor: "#fff" } : { backgroundColor: "#9f9d9d61" }
      }
    >
      <div className="content">
        <p>{content}</p>
      </div>
      <div className="createdAt">
        <span>{moment(new Date(createdAt)).fromNow()}</span>
      </div>
    </div>
  );
};

export default Notification;
