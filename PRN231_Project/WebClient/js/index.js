$(document).ready(function () {
  //Authen button Navbar
  DisplayAuthenButton();

  //Featured Movie
  GetFeaturedMovie(3);

  //Movie Lists
  GetAllMovies();
  GetMoviesByCategory(4);
});

//Change navbar color
const [red, green, blue] = [0, 0, 0];
const navbar = document.querySelector(".my-main-navbar");

window.addEventListener("scroll", () => {
  let y = 1 + (window.scrollY || window.pageYOffset) / 150;
  y = y < 1 ? 1 : y; // ensure y is always >= 1 (due to Safari's elastic scroll)
  const [r, g, b] = [red / y, green / y, blue / y].map(Math.round);
  navbar.style.backgroundColor = `rgb(${r}, ${g}, ${b})`;
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
          //Movie item
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
            // Watch button
            '<a type="button" class="btn btn-light movie-list-item-button movie-list-item-watch-button"' +
            'href="./WatchMovie.html?id=' +
            value["movieId"] +
            '"><i class="movie-item-button-icon fa-solid fa-play"></i></a>' +
            // Detail button
            '<button type="button" class="btn btn-light movie-list-item-button movie-list-item-detail-button"' +
            'data-bs-toggle="modal" data-bs-target="#movieDetailModal" onclick="displayMovieDetail(' +
            value["movieId"] +
            ')">' +
            '<i class="movie-item-button-icon fa-solid fa-angle-down"></i></button>' +
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
          //Movie item
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
            // Watch button
            '<a type="button" class="btn btn-light movie-list-item-button movie-list-item-watch-button"' +
            'href="./WatchMovie.html?id=' +
            value["movieId"] +
            '"><i class="movie-item-button-icon fa-solid fa-play"></i></a>' +
            // Detail button
            '<button type="button" class="btn btn-light movie-list-item-button movie-list-item-detail-button"' +
            'data-bs-toggle="modal" data-bs-target="#movieDetailModal" onclick="displayMovieDetail(' +
            value["movieId"] +
            ')">' +
            '<i class="movie-item-button-icon fa-solid fa-angle-down"></i></button>' +
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
          // Featured Image
          'style="background: linear-gradient(to bottom, rgba(0,0,0,0), #151515),' +
          "url('../image/movies/" +
          result["imagePath"] +
          "');\">" +
          '<img class="featured-title" src="../image/movie_titles/ant-man-title.png" alt="">' +
          // Featured Description
          '<p class="featured-desc">' +
          result["description"] +
          "</p>" +
          // Play Button
          '<a type="button" class="btn btn-light featured-button featured-play-button" href="./WatchMovie.html?id=' +
          result["movieId"] +
          '"><i class="featured-button-icon fa-solid fa-play"></i> Play</a>' +
          // Detail Button
          '<button type="button" class="btn btn-secondary featured-button" href="" ' +
          'data-bs-toggle="modal" data-bs-target="#movieDetailModal" onclick="displayMovieDetail(' +
          result["movieId"] +
          ')">' +
          '<i class="featured-button-icon fa-solid fa-circle-info"></i> More Info</button>' +
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

// Determine whether to display [Login], [Logout] or [Profile] button on Navbar
// (based on token storage)
function DisplayAuthenButton() {
  //Check if Token exist
  permanentToken = window.localStorage.getItem("token");
  sessionToken = window.sessionStorage.getItem("token");
  if (permanentToken !== null || sessionToken !== null) {
    //Display button
    $("#logoutButton").show();
    $("#loginButton").hide();
    $("#navbar-profile-button").show();
  } else {
    //Display button
    $("#logoutButton").hide();
    $("#loginButton").show();
    $("#navbar-profile-button").hide();
  }
}

// (Click event handler) Logout -> call to function in auth.js
$("#logoutButton").click(function (e) {
  Logout();
});

// Get Detail Information of a Movie and set it to the Modal to display
function displayMovieDetail(movieId) {
  // Get Detail infos of Movie
  $.ajax({
    url: "https://localhost:5001/api/Movie/" + movieId,
    type: "get",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result, status, xhr) {
      $("#movieDetailModal > div > div > div > #movieDetailName").html(
        result["movieName"]
      );
      $(
        "#movieDetailModal > div > div > #movieDetailModalBody > #movieDetailImage"
      ).attr("src", "../image/movies/" + result["imagePath"]);
      $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailDuration").html(
        result["duration"]
      );
      $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailRated").html(
        result["rated"]
      );
      $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailPublishedYear").html(
        result["publishedYear"]
      );
      $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailCountry").html(
        result["country"]
      );
      $("#movieDetailModal > div > div > #movieDetailModalBody > #movieDetailDescription").html(
        result["description"]
      );
      // Play button
      $("#movieDetailModal > div > div > #movieDetailModalFooter > a")
        .attr("href", "./WatchMovie.html?id=" + result["movieId"]);
    },
    error: function (xhr, status, error) {
      console.log(xhr);
    },
  });

  // Get Actors of Movie
  $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailActors").html("");
  $.ajax({
    url: "https://localhost:5001/GetActorsByMovieId/" + movieId,
    type: "get",
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (result, status, xhr) {
      $.each(result, function (index, value) {
        if (index > 0) {
          $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailActors").append(
            ", " + value["actorName"]
          );
        } else {
          $("#movieDetailModal > div > div > #movieDetailModalBody > div > #movieDetailActors").append(
            value["actorName"]
          );
        }
      });
    },
    error: function (xhr, status, error) {
      console.log(xhr);
    },
  });
}
