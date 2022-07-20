function Login() {
    var json = {
        email: $("#Email").val(),
        password: $("#Password").val()
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
            if ($("#Remember").is(':checked')) {
                window.localStorage.setItem("token", result["token"]);
            }
            else {
                window.sessionStorage.setItem("token", result["token"]);
            }
            window.location.href = "../../index.html";
        },
        error: function (e) {
            console.log(e);
        }
    });
}

function Logout() {
    window.localStorage.removeItem("token");
    window.sessionStorage.removeItem("token");
    window.location.href = "../../index.html";
}

function Signup() {
    var json = {
        email: $("#Email").val(),
        password: $("#Password").val(),
        username: $("#Username").val(),
        rePassword: $("#RePassword").val()
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
            window.sessionStorage.setItem("token", result["token"]);
            window.location.href = "../../index.html";
        },
        error: function (e) {
            console.log(e);
        }

    });
}