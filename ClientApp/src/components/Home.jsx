import React, { useEffect, useState } from "react";
import { useRecoilValue } from "recoil";
import authService from "../services/authService";
import postService from "../services/postService";
import authAtom from "../states/authAtom";
import userAtom from "../states/userAtom";
import "./Home.css";

const Home = () => {
  const [posts, setPosts] = useState([]);
  const isAuthenticated = useRecoilValue(authAtom);
  const user = useRecoilValue(userAtom);

  const _getAllPosts = async () => {
    const res = await postService.GetPostsWithLikeCountAndLikedByUser(
      user ? user.id : null
    );
    const data = await res.json();
    setPosts(data);
  };

  const _handleLike = async (postId) => {
    if (user) {
      const res = await postService.likePost(user.id, postId);
      if (res.status == 200) _getAllPosts();
    }
  };

  useEffect(() => {
    _getAllPosts();
  }, []);

  return (
    <div className="root">
      <div className="paper">
        {posts?.map((post, index) => (
          <div className="item" key={index}>
            <div>{post.content}</div>
            <div className="like">
              <div className="likeCount">{post.likeCount}</div>
              {isAuthenticated ? (
                <div
                  className="likedByUser"
                  onClick={() => _handleLike(post.id)}
                >
                  {post.likedByUser == 0 ? (
                    <i class="fa fa-heart-o" aria-hidden="true"></i>
                  ) : (
                    <i class="fa fa-heart" aria-hidden="true"></i>
                  )}
                </div>
              ) : (
                <i class="fa fa-heart-o" aria-hidden="true"></i>
              )}
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
