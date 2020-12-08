var initCaptcha = function () {
    if ($('#rcRegister').length > 0) {
        grecaptcha.render('rcRegister', {
            'sitekey': '6LcGQvkUAAAAAPFUw2yO9OBPlsRDg6VxAYVJWgsw'
        });
    }

    if ($('#rcLogin').length > 0) {
        grecaptcha.render('rcLogin', {
            'sitekey': '6LcGQvkUAAAAAPFUw2yO9OBPlsRDg6VxAYVJWgsw'
        });
    }

    if ($('#rcGetVideo').length > 0) {
        grecaptcha.render('rcGetVideo', {
            'sitekey': '6LcGQvkUAAAAAPFUw2yO9OBPlsRDg6VxAYVJWgsw'
        });
    }
};

appVdl.main = (function () {    

    var resetCaptcha = function () {
        if ($('#rcRegister').length > 0
            || $('#rcLogin').length > 0
            || $('#rcGetVideo').length > 0) {
            grecaptcha.reset();
        }
    };

    var initAccount = function () {

        $("#form-login").validate({
            rules: {
                username: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength: 6,
                    maxlength: 32
                }
            },
            messages: {
                username: 'This field is required.',
                password: 'This field is required.'
            },
            submitHandler: function (e) {

                if (!$('#form-login').hasClass('isPosting')) {

                    $('#form-login').addClass('isPosting');
                    $('#form-login button[type="submit"]').html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');
                    $('.alert-login').addClass('d-none');

                    $.ajax({
                        type: "POST",
                        url: "/login",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader("XSRF-TOKEN",
                                $('input:hidden[name="__RequestVerificationToken"]').val());
                        },
                        data: $('#form-login').serialize(),
                        success: function (res) {
                            if (typeof res.error !== 'undefined' && !res.error) {
                                document.location.reload();
                            } else {
                                $('.alert-login > span').html(res.message);
                                $('.alert-login').removeClass('d-none');
                            }
                        },
                        complete: function (response) {
                            $('#form-login').removeClass('isPosting');
                            $('#form-login button[type="submit"]').html('Sign In');
                            resetCaptcha();
                        },
                        failure: function (response) {
                            alert(response);
                        }
                    });

                }

                return false;
            }
        });

        $("#form-register").validate({
            rules: {
                username: {
                    required: true,
                    email: true
                },
                password: {
                    required: true,
                    minlength: 6,
                    maxlength: 32
                },
                repassword: {
                    required: true,
                    minlength: 6,
                    maxlength: 32
                },
            },
            messages: {
                username: 'This field is required.',
                password: 'This field is required.',
                repassword: 'This field is required.'
            },
            submitHandler: function (e) {

                if (!$('#form-register').hasClass('isPosting')) {

                    $('#form-register').addClass('isPosting');
                    $('#form-register button[type="submit"]').html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');
                    $('.alert-register').addClass('d-none');

                    $.ajax({
                        type: "POST",
                        url: "/register",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader("XSRF-TOKEN",
                                $('input:hidden[name="__RequestVerificationToken"]').val());
                        },
                        data: $('#form-register').serialize(),
                        success: function (res) {
                            if (typeof res.error !== 'undefined' && !res.error) {
                                document.location.reload();
                            } else {
                                $('.alert-register > span').html(res.message);
                                $('.alert-register').removeClass('d-none');
                            }
                        },
                        complete: function (response) {
                            $('#form-register').removeClass('isPosting');
                            $('#form-register button[type="submit"]').html('Sign Up');
                            resetCaptcha();
                        },
                        failure: function (response) {
                            alert(response);
                        }
                    });

                }

                return false;
            }
        });
    };

    return {
        resetCaptcha: resetCaptcha,
        initAccount: initAccount
    };

})();

$(document).ready(function () {
    appVdl.main.initAccount();
    if (document.location.pathname === '/' || document.location.pathname === '/free-vip') appVdl.home.init();
    if (document.location.pathname === '/change-password') appVdl.changepassword.init();
    if (document.location.pathname === '/upgrade') appVdl.upgrade.init();
    if (document.location.pathname !== '/' && document.location.search.indexOf('?url=') === 0) appVdl.getVideo.init();
});