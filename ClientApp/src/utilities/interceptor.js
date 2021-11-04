function getTokenHeader() {
  let userToken = localStorage.getItem("user");
  if (userToken) return userToken;
  else return "";
}

export default async function customFetch(verb, url, dataSet = null) {
  const token = getTokenHeader();

  const request = {
    method: verb,
    headers: {
      Accept: "application/json",
      "Content-Type": "application/json",
    },
    body: dataSet ? JSON.stringify(dataSet) : null,
  };

  if (token) {
    request.headers["Authorization"] = `Bearer ${token}`;
  }

  return await fetch(url, request);
}
