﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const profileEditForm = $('#edit_profile');
const passwordUpdateForm = $('#password_update');
const userRegisterForm = $('#new_user');
const modal = $('.modal');
const loginForm = $('#login_form');
const logoutForm = $('#logout');
const rolesDropDown = $('select[id="roles"');

$(document).ready(function () {

    toastr.options.closeMethod = 'slideUp';
    toastr.options.hideMethod = 'slideUp';
    toastr.options.showMethod = 'slideDown';
    toastr.options.closeDuration = 500;
    toastr.options.closeEasing = 'swing';
    toastr.options.messageClass = 'text-11px';
    toastr.options.titleClass = 'text-11px';
    toastr.options.maxOpened = 1;
    toastr.options.timeOut = 1000;

    rolesDropDown.multiselect({
        selectAllText: 'ყველას არჩევა',
        selectAllValue: 'multiselect-all',
        selectedClass: 'selected-dropdow',
        nonSelectedText: 'ცარიელი',
        allSelectedText: 'ყველა როლი',
        buttonWidth: 'relative',
    });

    modal.modal({
        backdrop: true,
        show: false
    });

    profileEditForm.on('submit', function () {
        event.preventDefault();

        profileEditForm.validate()

        if (profileEditForm.valid() !== true) return;

        const action = profileEditForm.attr('action');

        const postData = profileEditForm.serialize();

        $(this).attr('disabled', true);

        $.ajax({
            type: 'PUT',
            url: action,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            data: postData,
            success: function (response) {
                if (response.succeed === true) {
                    toastr.success("", response.message, {
                        onHidden: function () {
                            window.location.href = response.returnUrl;
                        }
                    })
                } else if (response.succeed === false) {
                    toastr.error("", response.message, {
                        onHidden: function () {
                            window.location.reload();
                        }
                    });
                }
            }
        });
    });

    passwordUpdateForm.on('submit', function () {
        event.preventDefault();

        passwordUpdateForm.validate();

        if (passwordUpdateForm.valid() !== true) return;

        const action = passwordUpdateForm.attr('action');
        const postData = passwordUpdateForm.serialize();



        $.ajax({
            type: 'PUT',
            url: action,
            contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
            dataType: 'json',
            data: postData,
            success: function (response) {
                if (response.succeed === true) {
                    toastr.success("", response.message, {
                        onHidden: function () {
                            window.location.href = response.returnUrl;
                        }
                    })
                } else if (response.succeed === false) {
                    toastr.error("", response.message, {
                        onHidden: function () {
                            window.location.reload();
                        }
                    });
                }
            }
        });
    });

    userRegisterForm.on('submit', function () {
        event.preventDefault();

        userRegisterForm.validate();

        console.log('clicked!');

        if (userRegisterForm.valid() !== true) return;

        const action = userRegisterForm.attr('action');
        const postData = userRegisterForm.serialize();

        $.post(action, postData).done(function (response) {
            if (response.succeed === true) {
                toastr.success("", response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.error("", response.message);
            }
        });
    })

    loginForm.on('submit', function () {
        event.preventDefault();

        loginForm.validate();;

        if (loginForm.valid() === false) return;

        var index = window.location.search.indexOf('=') + 1;

        var retUrl = window.location.search.slice(index);

        $('#returnUrl').val(decodeURIComponent(retUrl));

        const action = loginForm.attr('action');
        const postData = loginForm.serialize();

        $.post(action, postData).done(function (response) {
            if (response.succeed === true) {
                toastr.success("", response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                })
            }
            else if (response.succeed === false) {
                toastr.warning("", response.message);
            }
        });
    });

    logoutForm.on('submit', function () {
        event.preventDefault();
        const postData = logoutForm.serialize();
        const action = logoutForm.attr('action');

        $.post(action, postData).done(function (response) {
            if (response.succeed === true) {
                toastr.success("", response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                })
            }
        });
    });
});

var updateItem = function (form_id, user_id) {
    event.preventDefault();

    const form = $('#' + form_id + '_' + user_id);
    const action = form.attr('action');
    const formData = form.serialize();
    const modal = $('#editUser_' + user_id);

    form.validate();


    if (form.valid() !== true) return;

    $.ajax({
        type: 'PUT',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: formData,
        success: function (response, data) {
            if (response.succeed === true) {
                toastr.success("", response.message, {
                    fadeOut: 500,
                    messageClass: 'text-11px',
                    onHidden: function () {
                        modal.modal("hide");
                        window.location.reload();
                    }
                });
            } else if (response.succeed === false) {
                toastr.error("", response.message, {
                    fadeOut: 1000
                });
            }
        },
        error: function (response) {
            toastr.error('Error: ' + response.status);
        }
    });
}

var deleteItem = function (uid) {
    event.preventDefault();

    const deleteForm = $('#delete_' + uid);
    const action = deleteForm.attr('action');
    const deleteData = deleteForm.serialize();

    console.log(deleteData);

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
                        type: 'DELETE',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: deleteData,
                        success: function (data) {
                            console.log(data);
                            if (data.succeed === true) {
                                toastr.success("", data.message, {
                                    fadeOut: 500,
                                    onHidden: function () {
                                        window.location.href = data.returnUrl;
                                    }
                                });
                            } else if (data.succeed == false) {
                                toastr.warning("", data.message);
                            }
                        },
                        error: function (resp) {
                            toastr.error('Error: ' + resp.status);
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

var deleteAuthor = function (aid) {
    event.preventDefault();

    authorDeleteForm = $('form[data-delete="' + aid + '"]');

    const action = authorDeleteForm.attr('action');

    const deleteData = authorDeleteForm.serialize();

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
                        type: 'DELETE',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: deleteData,
                        success: function (data) {
                            console.log(data);
                            if (data.succeed === true) {
                                toastr.success("", data.message, {
                                    fadeOut: 500,
                                    onHidden: function () {
                                        window.location.href = data.returnUrl;
                                    }
                                });
                            } else if (data.succeed == false) {
                                toastr.warning("", data.message);
                            }
                        },
                        error: function (resp) {
                            toastr.error('Error: ' + resp.status);
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

var authorEdit = function (aid) {
    const authorEditForm = $('form[data-edit="' + aid + '"]');

    const action = authorEditForm.attr('action');
    const updatedData = authorEditForm.serialize();

    authorEditForm.validate();

    if (authorEditForm.valid() !== true) return;

    $.ajax({
        url: action,
        type: 'PUT',
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: updatedData,
        success: function (response, data) {
            if (response.succeed === true) {
                toastr.success("", response.message, {
                    fadeOut: 500,
                    messageClass: 'text-11px',
                    onHidden: function () {
                        modal.modal("hide");
                        window.location.reload();
                    }
                });
            } else if (response.succeed === false) {
                toastr.error("", response.message, {
                    fadeOut: 1000
                });
            }
        },
        error: function (response) {
            toastr.error('Error: ' + response.status);
        }
    });
}

var authorCreate = function () {
    const authorCreateForm = $('form[data-create-author="new"]');
    const action = authorCreateForm.attr('action');

    console.log(action);
    const postData = authorCreateForm.serialize();

    authorCreateForm.validate();

    if (authorCreateForm.valid() !== true) return;

    $.post(action, postData)
        .done(function (response) {
            if (response.succeed === true) {

                toastr.success("", response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.error("", response.message);
            }
        })
        .fail(function (response) {
            toastr.error('Error: ' + response.status);
        });
}