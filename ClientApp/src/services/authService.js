import customFetch from "../utilities/interceptor";
import { parseJwt } from "../utilities/jwtParse";

export default class authService {
  static async login(credentials) {
    const res = await customFetch(
      "POST",
      "https://localhost:45654/user/login",
      credentials
    );

    const token = await res.json();

    if (res.status == "200") localStorage.setItem("user", token);
  }

  static isAuthenticated() {
    return localStorage.getItem("user") !== null;
  }

  static logout() {
    localStorage.removeItem("user");
  }

  static getUser() {
    return parseJwt(localStorage.getItem("user"));
  }

  static async register(credentials) {
    return await customFetch(
      "POST",
      "https://localhost:45654/user/register",
      credentials
    );
  }
}
