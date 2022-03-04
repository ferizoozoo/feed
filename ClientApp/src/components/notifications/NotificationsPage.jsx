import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import notificationService from "../../services/notificationService";
import userAtom from "../../states/userAtom";
import Pagination from "../pagination";
import Notification from "./Notification";

const NotificationsPage = () => {
  const [notifications, setNotifications] = useState([]);
  const [totalCount, setTotalCount] = useState(0);
  const user = useRecoilValue(userAtom);
  const [pageFilter, setPageFilter] = useState({
    pageSize: 4,
    pageNumber: 1,
  });

  const _loadData = async () => {
    const res = await notificationService.getNotificationsByUserIdByPage(
      user.id,
      pageFilter
    );
    const data = await res.json();
    setNotifications(data.result);
    setTotalCount(data.totalRecords);
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
        totalRecords={totalCount}
        onPageClick={_handlePageChange}
      />
    </div>
  );
};

export default NotificationsPage;
