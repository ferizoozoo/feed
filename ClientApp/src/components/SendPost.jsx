import React, { useState } from "react";
import postService from "../services/postService";

import "./SendPost.css";

const SendPost = () => {
  const [content, setContent] = useState("");

  const _handleChange = (e) => {
    const value = e.target.value;
    setContent(value);
  };

  const _handleSubmit = async () => {
    if (content == "") return;

    const post = {
      content,
    };

    const res = await postService.sendPost(post);

    setContent("");

    alert("New feed added");
  };

  const _handleEnterPress = (e) => {
    // keyCode == 13 refers to 'Enter' key press
    if (e.keyCode == 13) _handleSubmit();
  };

  return (
    <div className="root">
      <div className="form">
        <input
          type="text"
          id="content"
          name="content"
          value={content}
          onChange={_handleChange}
          onKeyDown={_handleEnterPress}
          placeholder="Write a new feed :)"
        />
        <button type="submit" className="button" onClick={_handleSubmit}>
          Send it now!
        </button>
      </div>
    </div>
  );
};

export default SendPost;
