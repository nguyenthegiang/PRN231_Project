// Login
function Login() {
  var json = {
    email: $("#Email").val(),
    password: $("#Password").val(),
  };
  $.ajax({
    type: "post",
    contentType: "application/json; charset=UTF-8",
    url: "http://localhost:5000/api/user/login",
    data: JSON.stringify(json),
    dataType: "json",
    success: function (result, status, xhr) {
      console.log("success");
      console.log(result["token"]);

      //reset storage
      window.localStorage.removeItem("token");
      window.localStorage.removeItem("userId");
      window.sessionStorage.removeItem("token");

      //save token & userId to local storage
      if ($("#Remember").is(":checked")) {
        window.localStorage.setItem("token", result["token"]);
      } else {
        window.sessionStorage.setItem("token", result["token"]);
      }
      window.localStorage.setItem("userId", result["userId"]);

      if (result["role"]["roleName"] === "Admin") {
        window.location.href = "../Admin/Dashboard.html";
      } else {
        window.location.href = "../Client/index.html";
      }
    },
    error: function (e) {
      console.log(e);
    },
  });
}

// Login with Facebook
function LoginFacebook(email, facebookUID, name) {
  var json = {
    email: email,
    facebookUID: facebookUID,
    name: name,
  };
  $.ajax({
    type: "post",
    contentType: "application/json; charset=UTF-8",
    url: "http://localhost:5000/api/user/login/fb",
    data: JSON.stringify(json),
    dataType: "json",
    success: function (result, status, xhr) {
      console.log("success");
      console.log(result["token"]);

      //reset storage
      window.localStorage.removeItem("token");
      window.localStorage.removeItem("userId");
      window.sessionStorage.removeItem("token");

      //save token & userId to local storage
      if ($("#Remember").is(":checked")) {
        window.localStorage.setItem("token", result["token"]);
      } else {
        window.sessionStorage.setItem("token", result["token"]);
      }
      window.localStorage.setItem("userId", result["userId"]);

      //back to Home
      window.location.href = "../Client/index.html";
    },
    error: function (e) {
      console.log(e);
    },
  });
}

// Logout
function Logout() {
  //remove storage
  window.localStorage.removeItem("token");
  window.localStorage.removeItem("userId");
  window.sessionStorage.removeItem("token");

  window.location.href = "../Client/index.html";
}

// Sign up
function Signup() {
  var json = {
    email: $("#Email").val(),
    password: $("#Password").val(),
    username: $("#Username").val(),
    rePassword: $("#RePassword").val(),
  };
  $.ajax({
    type: "post",
    contentType: "application/json; charset=UTF-8",
    url: "http://localhost:5000/api/user/signup",
    data: JSON.stringify(json),
    dataType: "json",
    success: function (result, status, xhr) {
      console.log("success");
      console.log(result["token"]);

      //reset storage
      window.localStorage.removeItem("token");
      window.localStorage.removeItem("userId");
      window.sessionStorage.removeItem("token");

      //save token & userId to local storage
      window.sessionStorage.setItem("token", result["token"]);
      window.localStorage.setItem("userId", result["userId"]);
      window.location.href = "../Client/index.html";
    },
    error: function (e) {
      console.log(e);
    },
  });
}
