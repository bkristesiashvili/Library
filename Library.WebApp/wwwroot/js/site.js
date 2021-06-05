// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const profileEditForm = $('#edit_profile');
const passwordUpdateForm = $('#password_update');
const userRegisterForm = $('#new_user');
const modal = $('.modal');
const loginForm = $('#login_form');
const logoutForm = $('#logout');
const rolesDropDown = $('select[id="roles"');
const selectAllForm = $('form[data-select-all]');
const pageSizeSelect = $('select[data-page-size]');

$(document).ready(() => {

    $.validator.addMethod("sanitization",
        function (value, element, parameters) {
            const regex = '<[^>]*(>|$)';
            return !value.match(regex);
        });

    $.validator.unobtrusive.adapters.add("sanitization", [], function (options) {
        options.rules.sanitization = {};
        options.messages["sanitization"] = options.message;
    });

    toastr.options.closeMethod = 'slideUp';
    toastr.options.hideMethod = 'slideUp';
    toastr.options.showMethod = 'slideDown';
    toastr.options.closeDuration = 500;
    toastr.options.closeEasing = 'swing';
    toastr.options.messageClass = 'text-11px';
    toastr.options.titleClass = 'text-11px';
    toastr.options.maxOpened = 1;
    toastr.options.timeOut = 1000;

    const checkBox = $('input[type="checkbox"]');

    rolesDropDown.multiselect({
        selectAllText: 'ყველას არჩევა',
        selectAllValue: 'multiselect-all',
        selectedClass: 'selected-dropdow',
        nonSelectedText: 'ცარიელი',
        allSelectedText: 'ყველა როლი',
        buttonWidth: 'relative',
        numberDisplayed: 1,
        nSelectedText: 'მონიშნული'
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

    loginForm.on('submit', () => {
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

    logoutForm.on('submit', () => {
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

    checkBox.on('change', () => {
        var checked = checkBox.prop('checked');
        var action = selectAllForm.attr('action');
        var name = checkBox.attr('name');

        console.log(name);

        window.location.href = action + '?' + name + '=' + checked;

    });

    pageSizeSelect.on('change', () => {
        alert(pageSizeSelect.val());
    });
});

var updateItem = (form_id, user_id) => {
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

var deleteItem = (uid) => {
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

var deleteAuthor = (aid) => {
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

var authorEdit = (aid) => {
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

var authorCreate = () => {
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

var authorRestore = (aid) => {
    const authorDeleteForm = $('form[data-restore-author="' + aid + '"]');
    const action = authorDeleteForm.attr('action');
    const postData = authorDeleteForm.serialize();

    var confirmForm = $.confirm({
        title: '',
        content: 'ნამდვილად გსურთ აღდგენა?',
        type: 'green',
        columnClass: 'col-sm-4 col-md-offset-4 text-12px',
        buttons: {
            დიახ: {
                btnClass: 'btn-success text-12px',
                action: function () {
                    $.ajax({
                        type: 'PUT',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: postData,
                        success: function (response) {
                            if (response.succeed === true) {
                                toastr.success('', response.message, {
                                    onHidden: function () {
                                        window.location.href = response.returnUrl;
                                    }
                                });

                            } else if (response.succeed === false) {
                                toastr.warning('', response.message);
                            }
                        },
                        error: function (response) {
                            toastr.error('ERROR: ' + response.status);
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

var genreCreate = () => {
    event.preventDefault();
    const genreCreateForm = $('form[data-create-genre="new"]');
    const action = genreCreateForm.attr('action');
    const postData = genreCreateForm.serialize();

    genreCreateForm.validate();

    if (genreCreateForm.valid() !== true) return;

    $.post(action, postData)
        .done(function (response) {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                })
            } else if (response.succeed === false) {
                toastr.warning('', response.message);
            }
        })
        .fail(function (response) {
            toastr.error('ERROR: ' + response.status);
        });
}

var genreEdit = (gid) => {
    const genreEditForm = $('form[data-genre-edit="' + gid + '"]');
    const action = genreEditForm.attr('action');
    const postData = genreEditForm.serialize();

    genreEditForm.validate();
    if (genreEditForm.valid() !== true) return;

    $.ajax({
        type: 'PUT',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: postData,
        success: function (response) {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.warning('', response.message);
            }
        },
        error: function (response) {
            toastr.error('ERROR: ' + response.status);
        }
    });
}

var genreDelete = (gid) => {
    const deleteForm = $('form[data-delete-genre="' + gid + '"]');
    const action = deleteForm.attr('action');
    const deleteData = deleteForm.serialize();

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

var genreRestore = (gid) => {
    const sectorDeleteForm = $('form[data-restore-genre="' + gid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

    var confirmForm = $.confirm({
        title: '',
        content: 'ნამდვილად გსურთ აღდგენა?',
        type: 'green',
        columnClass: 'col-sm-4 col-md-offset-4 text-12px',
        buttons: {
            დიახ: {
                btnClass: 'btn-success text-12px',
                action: function () {
                    $.ajax({
                        type: 'PUT',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: postData,
                        success: function (response) {
                            if (response.succeed === true) {
                                toastr.success('', response.message, {
                                    onHidden: function () {
                                        window.location.href = response.returnUrl;
                                    }
                                });

                            } else if (response.succeed === false) {
                                toastr.warning('', response.message);
                            }
                        },
                        error: function (response) {
                            toastr.error('ERROR: ' + response.status);
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

var sectorCreate = () => {
    const sectorCreateForm = $('form[data-create-sector="new"]');
    const action = sectorCreateForm.attr('action');
    const postData = sectorCreateForm.serialize();

    sectorCreateForm.validate();

    if (sectorCreateForm.valid() !== true) return;

    $.post(action, postData)
        .done((response) => {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: () => {
                        window.location.href = response.returnUrl;
                    }
                })
            } else if (response.succeed === false) {
                toastr.error('', response.message);
            }
        })
        .fail((response) => {
            toastr.error('ERROR: ' + response.status);
        });
}

var sectorDelete = (sid) => {
    const sectorDeleteForm = $('form[data-delete-sector="' + sid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

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
                        data: postData,
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

var sectorEdit = (sid) => {
    const sectorDeleteForm = $('form[data-sector-edit="' + sid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

    $.ajax({
        type: 'PUT',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: postData,
        success: function (response) {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.warning('', response.message);
            }
        },
        error: function (response) {
            toastr.error('ERROR: ' + response.status);
        }
    });
}

var sectorRestore = (sid) => {
    const sectorDeleteForm = $('form[data-restore-sector="' + sid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

    var confirmForm = $.confirm({
        title: '',
        content: 'ნამდვილად გსურთ აღდგენა?',
        type: 'green',
        columnClass: 'col-sm-4 col-md-offset-4 text-12px',
        buttons: {
            დიახ: {
                btnClass: 'btn-success text-12px',
                action: function () {
                    $.ajax({
                        type: 'PUT',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: postData,
                        success: function (response) {
                            if (response.succeed === true) {
                                toastr.success('', response.message, {
                                    onHidden: function () {
                                        window.location.href = response.returnUrl;
                                    }
                                });

                            } else if (response.succeed === false) {
                                toastr.warning('', response.message);
                            }
                        },
                        error: function (response) {
                            toastr.error('ERROR: ' + response.status);
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

var sectionCreate = () => {
    const sectorCreateForm = $('form[data-create-section="new"]');
    const action = sectorCreateForm.attr('action');
    const postData = sectorCreateForm.serialize();

    sectorCreateForm.validate();

    if (sectorCreateForm.valid() !== true) return;

    $.post(action, postData)
        .done((response) => {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: () => {
                        window.location.href = response.returnUrl;
                    }
                })
            } else if (response.succeed === false) {
                toastr.error('', response.message);
            }
        })
        .fail((response) => {
            toastr.error('ERROR: ' + response.status);
        });
}

var sectionEdit = (sid) => {
    const sectorDeleteForm = $('form[data-section-edit="' + sid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

    $.ajax({
        type: 'PUT',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: postData,
        success: function (response) {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.warning('', response.message);
            }
        },
        error: function (response) {
            toastr.error('ERROR: ' + response.status);
        }
    });
}

var sectionDelete = (sid) => {
    const deleteForm = $('form[data-delete-section="' + sid + '"]');
    const action = deleteForm.attr('action');
    const deleteData = deleteForm.serialize();

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

var sectionRestore = (sid) => {
    const sectorDeleteForm = $('form[data-restore-section="' + sid + '"]');
    const action = sectorDeleteForm.attr('action');
    const postData = sectorDeleteForm.serialize();

    var confirmForm = $.confirm({
        title: '',
        content: 'ნამდვილად გსურთ აღდგენა?',
        type: 'green',
        columnClass: 'col-sm-4 col-md-offset-4 text-12px',
        buttons: {
            დიახ: {
                btnClass: 'btn-success text-12px',
                action: function () {
                    $.ajax({
                        type: 'PUT',
                        url: action,
                        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
                        dataType: 'json',
                        data: postData,
                        success: function (response) {
                            if (response.succeed === true) {
                                toastr.success('', response.message, {
                                    onHidden: function () {
                                        window.location.href = response.returnUrl;
                                    }
                                });

                            } else if (response.succeed === false) {
                                toastr.warning('', response.message);
                            }
                        },
                        error: function (response) {
                            toastr.error('ERROR: ' + response.status);
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

var bookShelveCreate = () => {
    const sectorCreateForm = $('form[data-create-bookshelve="new"]');
    const action = sectorCreateForm.attr('action');
    const postData = sectorCreateForm.serialize();

    sectorCreateForm.validate();

    if (sectorCreateForm.valid() !== true) return;

    $.post(action, postData)
        .done((response) => {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: () => {
                        window.location.href = response.returnUrl;
                    }
                })
            } else if (response.succeed === false) {
                toastr.error('', response.message);
            }
        })
        .fail((response) => {
            toastr.error('ERROR: ' + response.status);
        });
}

var resolveLog = (lid) => {
    const genreEditForm = $('form[data-log-resolve="' + lid + '"]');
    const action = genreEditForm.attr('action');
    const postData = genreEditForm.serialize();

    genreEditForm.validate();
    if (genreEditForm.valid() !== true) return;

    $.ajax({
        type: 'PUT',
        url: action,
        contentType: 'application/x-www-form-urlencoded; charset=UTF-8',
        dataType: 'json',
        data: postData,
        success: function (response) {
            if (response.succeed === true) {
                toastr.success('', response.message, {
                    onHidden: function () {
                        window.location.href = response.returnUrl;
                    }
                });

            } else if (response.succeed === false) {
                toastr.warning('', response.message);
            }
        },
        error: function (response) {
            toastr.error('ERROR: ' + response.status);
        }
    });
}