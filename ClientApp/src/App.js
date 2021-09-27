import React, { Component } from "react";
import { Route, Switch } from "react-router";
import { Layout } from "./components/Layout";
import Home from "./components/Home";
import SendPost from "./components/SendPost";
import Login from "./components/Login";
import SignUp from "./components/SignUp";
import ProtectedRoute from "./ProtectedRoute";
import {
  RecoilRoot,
  atom,
  selector,
  useRecoilState,
  useRecoilValue,
} from "recoil";

import "./custom.css";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <RecoilRoot>
        <Layout>
          <Route exact path="/" component={Home} />
          <ProtectedRoute exact path="/sendPost" component={SendPost} />
          <Route exact path="/user/login" component={Login} />
          <Route exact path="/user/register" component={SignUp} />
        </Layout>
      </RecoilRoot>
    );
  }
}
