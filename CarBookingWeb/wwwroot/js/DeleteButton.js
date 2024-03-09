//$(function () {
//    $(".confirmDelete").click(function (e) {
//        swal({
//            title: 'Are you sure?',
//            text: "You won't be able to revert this!",
//            icon: 'warning',
//            buttons: true,
//            dangerMode: true
//        }).then((result) => {
//            if (result) {
//                var btn = $(this);
//                var id = btn.data("id");
//                $("#carId").val(id);
//                $('#myCarDeleteForm').submit();
//            }
//        });
//    });
//});


$(function () {
    $(".confirmDelete").click(function (e) {
        swal({
            title: 'Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'warning',
            buttons: true,
            dangerMode: true
        }).then((result) => {
            if (result) {
                var btn = $(this);
                var id = btn.data("id");
                $("#recordId").val(id);
                $('#myRecordDeleteForm').submit();
            }
        });
    });
});