import React, { useState } from "react";
import authService from "../services/authService";

import "./Login.css";

const Login = () => {
  // Hooks
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  const _handleChange = (e) => {
    const name = e.target.name;
    const value = e.target.value;

    if (name === "username") setUsername(value);
    else if (name === "password") setPassword(value);
  };

  const _handleSubmit = async () => {
    if (username == "" || password == "") return;

    const credentials = {
      username,
      password,
    };

    const res = authService.login(credentials);

    setUsername("");
    setPassword("");
  };

  return (
    <div className="root-login">
      <div className="login-form">
        <h4 className="form-title">Login</h4>
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
        </div>
        <button type="submit" onClick={_handleSubmit}>
          Login
        </button>
      </div>
    </div>
  );
};

export default Login;
