$(document).ready(function () {
  // member range
  $('#memberRange').val(1).on('input', function () {
    var memberRangeValue = $(this).val();
    $('#rangeValue').html(memberRangeValue);
  });
  // category search
  $("#category-search-input").on("keyup", function () {
    var value = $(this).val().toLowerCase();
    $("#categories-list div").filter(function () {
      $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
    });
  });
});