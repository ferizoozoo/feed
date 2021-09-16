import React, { useEffect, useState } from "react";
import postService from "../services/postService";
import "./Home.css";

const Home = () => {
  const [posts, setPosts] = useState([]);

  const _getAllPosts = async () => {
    const res = await postService.getListOfAllPosts();
    const data = await res.json();
    setPosts(data);
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
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
