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
      window.localStorage.removeItem("token");
      window.sessionStorage.removeItem("token");
      if ($("#Remember").is(":checked")) {
        //save token & userId to local storage
        window.localStorage.setItem("token", result["token"]);
        window.localStorage.setItem("userId", result["userId"]);
      } else {
        window.sessionStorage.setItem("token", result["token"]);
      }
      window.location.href = "../Client/index.html";
    },
    error: function (e) {
        console.log(e);
        $("#WrongAccountModal").modal().show();
    },
  });
}

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
      window.localStorage.removeItem("token");
      window.sessionStorage.removeItem("token");
      if ($("#Remember").is(":checked")) {
        //save token & userId to local storage
        window.localStorage.setItem("token", result["token"]);
        window.localStorage.setItem("userId", result["userId"]);
      } else {
        window.sessionStorage.setItem("token", result["token"]);
      }
      window.location.href = "../Client/index.html";
    },
    error: function (e) {
      console.log(e);
    },
  });
}

function Logout() {
  //remove token & userId
  window.localStorage.removeItem("token");
  window.localStorage.removeItem("userId");
  window.sessionStorage.removeItem("token");
  window.location.href = "../Client/index.html";
}

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
      window.localStorage.removeItem("token");
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
