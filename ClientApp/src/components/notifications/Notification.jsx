import React, { useEffect, useState } from "react";
import moment from "moment";
import notificationService from "../../services/notificationService";

import "./Notification.css";

const Notification = (props) => {
  const { data, loadData } = props;
  const { content, createdAt, seen, id } = data;

  const _markNotificationAsSeen = async (notificationId) => {
    const res = await notificationService.markNotificationAsSeen(
      notificationId
    );
    loadData();
  };

  return (
    <div
      className="notification"
      style={
        seen ? { backgroundColor: "#fff" } : { backgroundColor: "#9f9d9d61" }
      }
      onClick={() => _markNotificationAsSeen(id)}
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
