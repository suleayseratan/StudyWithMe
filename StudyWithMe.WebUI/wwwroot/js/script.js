// member range
// var slider = document.getElementById("memberRange");
// var output = document.getElementById("rangeText");
// output.innerHTML = slider.value;

// slider.oninput = function () {
//     output.innerHTML = this.value;
// }
// category searxh

$(document).ready(function(){
    $("#category-search-input").on("keyup", function() {
      var value = $(this).val().toLowerCase();
      $("#categories-list div").filter(function() {
        $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
      });
    });
  });