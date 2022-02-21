import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import notificationService from "../../services/notificationService";
import userAtom from "../../states/userAtom";

const NotificationsPage = () => {
  const [notifications, setNotifications] = useState([]);
  const user = useRecoilValue(userAtom);

  const _loadData = async () => {
    const res = await notificationService.getNotificationsByUserId(user.id);
    setNotifications(await res.json());
  };

  useEffect(() => {
    _loadData();
  }, []);

  return (
    <div>
      {notifications?.map((notification, index) => (
        <Notification key={index} data={notification} />
      ))}
    </div>
  );
};

export default NotificationsPage;
