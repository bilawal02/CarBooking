$(document).ready(function () { // Ensure the document is ready
    // $('#carModels').html('<option>---Select Model---</option>');

    var makerId = $('#carMakers').val();
    loadModels();

    $('#carMakers').change(function () {
        makerId = $(this).val();
        $('#carModels').html('<option>---Select Model---</option>');
        loadModels();
    });

    function loadModels() {
        var carModelId = $(this).attr('carModelId');
        $.getJSON('/CarPages/Create?handler=LoadingCarModels', { carMakerId: makerId }, function (data) {
            $.each(data, function (key, value) {
                var option = $('<option></option>').attr('value', value.id).text(value.name);
                if (value.id == carModelId) {
                    option.prop('selected', true);
                }
                $("#carModels").append(option);
            })
        });
    }
});