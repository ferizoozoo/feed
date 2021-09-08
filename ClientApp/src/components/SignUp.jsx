import React, { useState } from "react";

import "./SignUp.css";

const SignUp = () => {
  // Hooks
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [email, setEmail] = useState("");

  const _handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;

    if (name === "username") setUsername(value);
    else if (name === "password") setPassword(value);
    else if (name === "email") setEmail(value);
  };

  const _handleSubmit = async () => {
    if (username == "" || password == "") return;

    const post = {
      username,
      password,
      email
    };

    const res = await fetch("https://localhost:45654/user/register", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(post),
    });

    //localStorage.setItem("Token")

    setUsername("");
    setPassword("");
    setEmail("");
  };

  return (
    <div className="root-login">
      <div className="login-form">
        <h4 className="form-title">SignUp</h4>
        <div className="form-inputs">
          <div className="form-input">
            <input
              name="username"
              value={username}
              placeholder="Username"
              onChange={_handleChange}
            />
          </div>
          <div className="form-input">
            <input
              name="password"
              value={password}
              placeholder="Password"
              onChange={_handleChange}
            />
          </div>
          <div className="form-input">
            <input
              name="email"
              value={email}
              placeholder="Email"
              onChange={_handleChange}
            />
          </div>
        </div>
        <button type="submit" onClick={_handleSubmit}>
          Login
        </button>
      </div>
    </div>
  );
};

export default SignUp;
