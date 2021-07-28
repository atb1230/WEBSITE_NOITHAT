$(document).ready(function () {
    $('body').on('click', '.btn-add-cart', function (e) {
        e.preventDefault();
        var idproduct = $(this).data("id");
        alert(idproduct)
    });
});
