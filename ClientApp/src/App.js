import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import Home from "./components/Home";

import "./custom.css";
import SendPost from "./components/SendPost";
import Login from "./components/Login";
import SignUp from "./components/SignUp";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/sendPost" component={SendPost} />
        <Route exact path="/user/login" component={Login} />
        <Route exact path="/user/register" component={SignUp} />
      </Layout>
    );
  }
}
