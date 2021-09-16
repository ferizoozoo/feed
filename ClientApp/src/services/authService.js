export default class authService {
  static async login(credentials) {
    const res = await fetch("https://localhost:45654/user/login", {
      method: "POST",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      body: JSON.stringify(credentials),
    });

    localStorage.setItem("user", await res.json());
  }

  static isAuthenticated() {
    return localStorage.getItem("user") !== null;
  }

  static logout() {
    localStorage.setItem("user", null);
  }
}
