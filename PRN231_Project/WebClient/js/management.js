// Logout
function Logout() {
  //remove storage
  window.localStorage.removeItem("token");
  window.localStorage.removeItem("userId");
  window.sessionStorage.removeItem("token");

  window.location.href = "../../Client/index.html";
}
