import React, { useState } from "react";
import { useHistory } from "react-router";
import authService from "../services/authService";

import "./SignUp.css";

const SignUp = () => {
  // useHistory
  const history = useHistory();

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
      email,
    };

    const res = authService.register(post);

    //localStorage.setItem("Token")

    setUsername("");
    setPassword("");
    setEmail("");

    history.replace("/");
  };

  return (
    <div className="root-signUp">
      <div className="signUp-form">
        <h4 className="form-title">SignUp</h4>
        <div className="form-inputs">
          <div className="form-input">
            <input
              className="input"
              name="username"
              value={username}
              placeholder="Username"
              onChange={_handleChange}
            />
          </div>
          <div className="form-input">
            <input
              className="input"
              name="password"
              value={password}
              placeholder="Password"
              onChange={_handleChange}
            />
          </div>
          <div className="form-input">
            <input
              className="input"
              name="email"
              value={email}
              placeholder="Email"
              onChange={_handleChange}
            />
          </div>
        </div>
        <button className="button" type="submit" onClick={_handleSubmit}>
          Sign Up
        </button>
      </div>
    </div>
  );
};

export default SignUp;
