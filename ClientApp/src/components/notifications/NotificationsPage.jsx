import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import notificationService from "../../services/notificationService";
import userAtom from "../../states/userAtom";
import Notification from "./Notification";

const NotificationsPage = () => {
  const [notifications, setNotifications] = useState([]);
  const user = useRecoilValue(userAtom);

  const _loadData = async () => {
    const res = await notificationService.getNotificationsByUserId(
      user.id,
      1,
      100
    );
    const data = await res.json();
    setNotifications(data);
  };

  useEffect(() => {
    _loadData();
  }, []);

  return (
    <div
      style={{
        display: "flex",
        flexDirection: "column",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      {notifications?.map((notification, index) => (
        <Notification key={index} data={notification} loadData={_loadData} />
      ))}
    </div>
  );
};

export default NotificationsPage;
