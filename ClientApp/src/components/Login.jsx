import React, { useState } from "react";
import { useHistory } from "react-router";
import { useSetRecoilState } from "recoil";
import authService from "../services/authService";
import authAtom from "../states/authAtom";

import "./Login.css";

const Login = () => {
  // useHistory
  const history = useHistory();

  // Hooks
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");

  // Recoil
  const setAuthenticated = useSetRecoilState(authAtom);

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
    setAuthenticated(true);

    setUsername("");
    setPassword("");

    history.replace("/");
  };

  const _handleEnterKeyPress = (e) => {
    if (e.key === "Enter") _handleSubmit();
  };

  return (
    <div className="root-login">
      <div className="login-form">
        <div className="form-title">Login</div>
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
              onKeyPress={_handleEnterKeyPress}
            />
          </div>
        </div>
        <button className="button" type="submit" onClick={_handleSubmit}>
          Login
        </button>
      </div>
    </div>
  );
};

export default Login;
