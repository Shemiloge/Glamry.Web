$('#colorselector').colorselector();
$('#showPicker').on('click', function () {
    $('#colorselector').colorselector('showPicker');
});

$('#hidePicker').on('click', function () {
    $('#colorselector').colorselector('hidePicker');
});

$('#setColor').on('click', function () {
    $('#colorselector').colorselector('setColor', "#DB7093");
});

$('#setId').on('click', function () {
    $('#colorselector').colorselector("setId", 36);
});

$(".pick-a-color").pickAColor();