import { atom } from "recoil";
import authService from "../services/authService";

const userAtom = atom({
  key: "user", // unique ID (with respect to other atoms/selectors)
  default: authService.getUser(), // default value (aka initial value)
});

export default userAtom;
