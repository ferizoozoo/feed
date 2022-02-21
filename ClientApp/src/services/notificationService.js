import customFetch from "../utilities/interceptor";

export default class notificationService {
  static async getNotificationsByUserId(userId) {
    return await customFetch(
      "GET",
      `notification/GetNotificationsByUserId?userId=${userId}`
    );
  }
}
