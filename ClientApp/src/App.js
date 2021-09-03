import React, { Component } from "react";
import { Route } from "react-router";
import { Layout } from "./components/Layout";
import Home from "./components/Home";

import "./custom.css";
import SendPost from "./components/SendPost";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Home} />
        <Route exact path="/sendPost" component={SendPost} />
      </Layout>
    );
  }
}
