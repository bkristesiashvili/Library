// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $("#saveChanges").on('click')

    var deleteItem = function (url, uid) {
        event.preventDefault();

        toastr.options.closeMethod = 'slideUp';
        toastr.options.hideMethod = 'slideUp';
        toastr.options.showMethod = 'slideDown';
        toastr.options.closeDuration = 50;
        toastr.options.closeEasing = 'swing';

        $.ajax({
            type: 'POST',
            url: url,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: JSON.stringify(uid),
            success: function (data) {
                console.log(data);
                if (data.success === true) {
                    toastr.options.onHidden = function () {
                        window.location.href = data.location;
                    }
                    toastr.success("მომხმარებელი წარმატებით წაიშალა.");
                } else if (data.success == false) {
                    toastr.warning("ავტორიზებული მომხმარებლის წაშლა შეუძლებელია!");
                    toastr.options.hideMethod = function () {
                        alert("test");
                    }
                }
            },
            error: function (resp) {
                toastr.error("დაფიქსირდა შეცდომა!");
            }
        });
    }
});