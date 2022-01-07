import customFetch from "../utilities/interceptor";

export default class postService {
  static async sendPost(post) {
    return await customFetch("POST", "post/SendPost", post);
  }

  static async getListOfAllPosts() {
    return await customFetch("GET", "post/GetListOfAllPosts");
  }

  static async GetPostsWithLikeCountAndLikedByUser(userId = null) {
    return await customFetch(
      "GET",
      `post/GetPostsWithLikeCountAndLikedByUser?userId=${userId ? userId : ""}`
    );
  }

  static async likePost(userId, postId) {
    return await customFetch("POST", "post/LikePost", {
      userId,
      postId,
    });
  }
}
