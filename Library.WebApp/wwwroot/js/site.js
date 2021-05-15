// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    toastr.options.closeMethod = 'slideUp';
    toastr.options.hideMethod = 'slideUp';
    toastr.options.showMethod = 'slideDown';
    toastr.options.closeDuration = 500;
    toastr.options.closeEasing = 'swing';
    toastr.options.messageClass = 'text-11px';
    toastr.options.titleClass = 'text-11px';

    const rolesDropDown = $('select[id="roles"');

    rolesDropDown.multiselect({
        selectAllText: 'ყველას არჩევა',
        selectAllValue: 'multiselect-all',
        selectedClass: 'selected-dropdow',
        nonSelectedText: 'ცარიელი',
        allSelectedText: 'ყველა როლი',
        buttonWidth: 'relative',
    });

    const profileEditForm = $('#edit_profile');

    profileEditForm.on('submit', function () {
        event.preventDefault();
        const action = profileEditForm.attr('action');

        const postData = profileEditForm.serialize();

        $.post(action, postData).done(function (data) {
            console.log(data);
            alert('test');
        })
    });
});

var updateItem = function (form_id, user_id) {
    event.preventDefault();

    const form = $('#' + form_id + '_' + user_id);
    const action = form.attr('action');
    const formData = form.serialize();
    const modal = $('#editUser_' + user_id);

    $.ajax({
        type: 'POST',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: formData,
        success: function (response, data) {
            if (response.succeed === true) {
                modal.modal("hide");
                toastr.success("", response.message, {
                    fadeOut: 500,
                    messageClass: 'text-11px',
                    onHidden: function () {
                        window.location.reload();
                    }
                });
            } else if (response.succeed === false) {
                toastr.error("", response.message, {
                    fadeOut: 1000
                });
            }

            console.log(data);
        },
        error: function (response) {
            if (response.success === false) {
                toastr.error(response.message);
            }
        }
    });
}


var deleteItem = function (url, uid) {
    event.preventDefault();

    var confirmForm = $.confirm({
        title: '',
        content: 'ნამდვილად გსურთ წაშლა?',
        type: 'red',
        columnClass: 'col-sm-4 col-md-offset-4 text-12px',
        buttons: {
            დიახ: {
                btnClass: 'btn-danger text-12px',
                action: function () {
                    $.ajax({
                        type: 'POST',
                        url: url,
                        contentType: 'application/json; charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify(uid),
                        success: function (data) {
                            console.log(data);
                            if (data.success === true) {
                                toastr.success("", "მომხმარებელი წარმატებით წაიშალა.", {
                                    timeOut: 1000,
                                    fadeOut: 1500,
                                    onHidden: function () {
                                        window.location.href = data.location;
                                    }
                                });
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
            },
            არა: function () {
                confirmForm.close();
            }
        }
    });
}