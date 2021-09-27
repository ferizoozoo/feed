import { atom } from "recoil";
import authService from "../services/authService";

const authAtom = atom({
  key: "auth", // unique ID (with respect to other atoms/selectors)
  default: authService.isAuthenticated(), // default value (aka initial value)
});

export default authAtom;
