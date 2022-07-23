$(document).ready(function () {
  //Authen button Navbar
  DisplayAuthenButton();

  //Featured Movie
  GetFeaturedMovie(3);

  //Movie Lists
  GetAllMovies();
  GetMoviesByCategory(4);
});

//[Category] All Movies
function GetAllMovies() {
  //Call API
  $.ajax({
    url: "https://localhost:5001/api/Movie",
    type: "get",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result, status, xhr) {
      //Set to HTML
      $.each(result, function (index, value) {
        $("#allMovies").append(
          '<div class="movie-list-item">' +
            '<img class="movie-list-item-img"' +
            'src="..\\image\\movies\\' +
            value["imagePath"] +
            '" alt="">' +
            '<span class="movie-list-item-title">' +
            value["movieName"] +
            "</span>" +
            // "<p class=\"movie-list-item-desc\">" +
            // "</p>" +
            '<a type="button" class="btn btn-light movie-list-item-watch-button" href="./WatchMovie.html?id=' +
            value["movieId"] +
            '"><i class="movie-item-button-icon fa-solid fa-play"></i></a>' +
            "</div>"
        );
      });
    },
    error: function (xhr, status, error) {
      console.log(xhr);
    },
  });
}

// [Category] Movies by Category
function GetMoviesByCategory(categoryId) {
  //Call API
  $.ajax({
    url: "https://localhost:5001/api/Movie/GetMoviesByCategory/" + categoryId,
    type: "get",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result, status, xhr) {
      //Set to HTML
      $.each(result, function (index, value) {
        $("#moviesByCategory").append(
          '<div class="movie-list-item">' +
            '<img class="movie-list-item-img"' +
            'src="..\\image\\movies\\' +
            value["imagePath"] +
            '" alt="">' +
            '<span class="movie-list-item-title">' +
            value["movieName"] +
            "</span>" +
            '<a href="./WatchMovie.html?id=' +
            value["movieId"] +
            '" class="movie-list-item-watch-button">Watch</a>' +
            "</div>"
        );
      });

      //Paging
      const arrows = document.querySelectorAll(".arrow");
      const movieLists = document.querySelectorAll(".movie-list");

      arrows.forEach((arrow, i) => {
        const itemNumber = movieLists[i].querySelectorAll("img").length;
        let clickCounter = 0;
        arrow.addEventListener("click", () => {
          const ratio = Math.floor(window.innerWidth / 270);
          clickCounter++;
          if (itemNumber - (4 + clickCounter) + (4 - ratio) >= 0) {
            movieLists[i].style.transform = `translateX(${
              movieLists[i].computedStyleMap().get("transform")[0].x.value - 300
            }px)`;
          } else {
            movieLists[i].style.transform = "translateX(0)";
            clickCounter = 0;
          }
        });
      });
    },
    error: function (xhr, status, error) {
      console.log(xhr);
    },
  });
}

//[Featured Movie]
function GetFeaturedMovie(id) {
  //Call API
  $.ajax({
    url: "https://localhost:5001/api/Movie/" + id,
    type: "get",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result, status, xhr) {
      // Set to HTML
      $("#featureSpace").append(
        '<div class="featured-content"' +
          'style="background: linear-gradient(to bottom, rgba(0,0,0,0), #151515),' +
          "url('../image/movies/" +
          result["imagePath"] +
          "');\">" +
          '<img class="featured-title" src="../image/movie_titles/ant-man-title.png" alt="">' +
          '<p class="featured-desc">' +
          result["description"] +
          "</p>" +
          '<a type="button" class="btn btn-light featured-button featured-play-button" href="./WatchMovie.html?id=' +
          result["movieId"] +
          '"><i class="featured-button-icon fa-solid fa-play"></i> Play</a>' +
          '<a type="button" class="btn btn-secondary featured-button" href="">' +
          '<i class="featured-button-icon fa-solid fa-circle-info"></i> More Info</a>' +
          "</div>"
      );
    },
    error: function (xhr, status, error) {
      console.log(xhr);
    },
  });
}

//[Link to Update Profile]
$("#navbar-profile-button").click(function (e) {
  //Get UserID from local storage
  let userId = window.localStorage.getItem("userId");
  //move to Update Profile
  window.location.href = "../Client/UpdateProfile.html?id=" + userId;
});

// Determine whether to display [Login] or [Logout] button on Navbar
// (based on token storage)
function DisplayAuthenButton() {
  //Check if Token exist
  permanentToken = window.localStorage.getItem("token");
  sessionToken = window.sessionStorage.getItem("token");
  if (permanentToken !== null || sessionToken !== null) {
    //Display button
    $("#logoutButton").show();
    $("#loginButton").hide();
  } else {
    //Display button
    $("#logoutButton").hide();
    $("#loginButton").show();
  }
}

// (Click event handler) Logout -> call to function in auth.js
$("#logoutButton").click(function (e) {
  Logout();
});
