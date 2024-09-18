const { error } = require("toastr");

$(document).ready(function () {
    $("#createBikeWorkshopServiceModal form").submit(function event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created bikeWorkshop service")
            },
            error: function () {
                toastr[error]("Something was wrong")
            }
        })
    })
});
