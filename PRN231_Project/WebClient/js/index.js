$(document).ready(function () {
    ShowMovies();
});

//Test: show data
function ShowMovies() {
    $.ajax({
        url: "https://localhost:5001/api/Movie",
        type: "get",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result, status, xhr) {
            $.each(result, function (index, value) {
                $("#allMovies").append("<div class=\"movie-list-item\">" +
                    "<img class=\"movie-list-item-img\"" +
                    "src=\"..\\image\\movies\\" + value["imagePath"] + "\" alt=\"\">" +
                    "<span class=\"movie-list-item-title\">" + value["movieName"] + "</span>" +
                    // "<p class=\"movie-list-item-desc\">" +
                    // "</p>" +
                    "<a href=\"./WatchMovie.html?id=" + value["movieId"] + 
                    "\" class=\"movie-list-item-button\">Watch</a>" +
                    "</div>");

                // appendElement.append($("<td>").html(value["movieId"]));
                // appendElement.append($("<td>").html(value["movieName"]));
                // appendElement.append($("<td>").html(value["videoPath"]));
                // appendElement.append($("<td>").html(value["description"]));
                // appendElement.append($("<td>").html(value["duration"]));
                // appendElement.append($("<td>").html(value["rated"]));
                // appendElement.append($("<td>").html(value["publishedYear"]));
                // appendElement.append($("<td>").html(value["country"]));
                // appendElement.append($("<td>")
                //     .html("<img src=\"image\\movies\\" + value["imagePath"] + "\" width=\"100\" />"));
            });

            const arrows = document.querySelectorAll(".arrow");
            const movieLists = document.querySelectorAll(".movie-list");

            arrows.forEach((arrow, i) => {
                const itemNumber = movieLists[i].querySelectorAll("img").length;
                let clickCounter = 0;
                arrow.addEventListener("click", () => {
                    const ratio = Math.floor(window.innerWidth / 270);
                    clickCounter++;
                    if (itemNumber - (4 + clickCounter) + (4 - ratio) >= 0) {
                        movieLists[i].style.transform = `translateX(${movieLists[i].computedStyleMap().get("transform")[0].x.value - 300}px)`
                    } else {
                        movieLists[i].style.transform = "translateX(0)";
                        clickCounter = 0;
                    }
                });
            });
        },
        error: function (xhr, status, error) {
            console.log(xhr)
        }
    });
}