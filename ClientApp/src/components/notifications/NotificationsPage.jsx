import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import notificationService from "../../services/notificationService";
import userAtom from "../../states/userAtom";
import Pagination from "../pagination";
import Notification from "./Notification";

const NotificationsPage = () => {
  const [notifications, setNotifications] = useState([]);
  const user = useRecoilValue(userAtom);
  const [pageFilter, setPageFilter] = useState({
    pageSize: 2,
    pageNumber: 1,
  });

  const _loadData = async () => {
    const res = await notificationService.getNotificationsByUserId(
      user.id,
      pageFilter.pageNumber,
      pageFilter.pageSize
    );
    const data = await res.json();
    setNotifications(data);
  };

  const _handlePageChange = (paginationData) => {
    setPageFilter({
      pageSize: pageFilter.pageSize,
      pageNumber: paginationData.pageNumber,
    });
  };

  useEffect(() => {
    _loadData();
  }, [pageFilter]);

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

      <Pagination
        pageNumber={pageFilter.pageNumber}
        pageSize={pageFilter.pageSize}
        totalRecords={6}
        onPageClick={_handlePageChange}
      />
    </div>
  );
};

export default NotificationsPage;
