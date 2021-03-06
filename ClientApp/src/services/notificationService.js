import customFetch from "../utilities/interceptor";

export default class notificationService {
  static async getNotificationsByUserIdByPage(userId, pageParameters) {
    return await customFetch(
      "GET",
      `notification/GetNotificationsByUserIdByPage?userId=${userId}&pageNumber=${pageParameters.pageNumber}&pageSize=${pageParameters.pageSize}`
    );
  }

  static async getUserTotalUnseenNotificationCount(userId) {
    return await customFetch(
      "GET",
      `notification/GetUserTotalUnseenNotificationCount?userId=${userId}`
    );
  }

  static async markNotificationAsSeen(notificationId) {
    return await customFetch(
      "GET",
      `notification/MarkNotificationAsSeen?notificationId=${notificationId}`
    );
  }
}
