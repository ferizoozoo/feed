import customFetch from "../utilities/interceptor";

export default class notificationService {
  static async getNotificationsByUserId(userId, pageNumber, pageSize) {
    return await customFetch(
      "GET",
      `notification/GetNotificationsByUserId?userId=${userId}&pageNumber=${pageNumber}&pageSize=${pageSize}`
    );
  }

  static async markNotificationAsSeen(notificationId) {
    return await customFetch(
      "GET",
      `notification/MarkNotificationAsSeen?notificationId=${notificationId}`
    );
  }
}
