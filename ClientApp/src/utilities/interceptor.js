export default function addTokenHeader() {
  let userToken = localStorage.getItem("user");
  if (userToken) return userToken;
  else return "";
}
