import customFetch from "../utilities/interceptor";

export default class postService {
  static async sendPost(post) {
    return await customFetch(
      "POST",
      "https://localhost:45654/post/SendPost",
      post
    );
  }

  static async getListOfAllPosts() {
    return await customFetch(
      "GET",
      "https://localhost:45654/post/GetListOfAllPosts"
    );
  }
}
