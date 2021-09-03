import React, { useEffect, useState } from "react";
import "./Home.css";

const Home = () => {
  const [posts, setPosts] = useState([]);

  const _getAllPosts = async () => {
    const res = await fetch("https://localhost:45654/post/GetListOfAllPosts");
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
