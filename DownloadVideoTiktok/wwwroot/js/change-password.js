appVdl.changepassword = (function () {

    var init = function () {

        $("#form-change-password").validate({
            rules: {
                currentpassword: {
                    required: true
                },
                newpassword: {
                    required: true
                },
                renewpassword: {
                    required: true
                }
            },
            messages: {
                currentpassword: 'Please enter information.',
                newpassword: 'Please enter information.',
                renewpassword: 'Please enter information.'
            },
            submitHandler: function (e) {

                if (!$('#form-change-password').hasClass('isPosting')) {

                    $('#form-change-password').addClass('isPosting');
                    $('#form-change-password button[type="submit"]').html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');
                    $('.alert-changepassword').removeClass('alert-success').addClass('alert-warning');
                    $('.alert-changepassword').removeClass('show').addClass('hide');

                    $.ajax({
                        type: "POST",
                        url: "/change-password",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader("XSRF-TOKEN",
                                $('input:hidden[name="__RequestVerificationToken"]').val());
                        },
                        data: $('#form-change-password').serialize(),
                        success: function (res) {
                            if (typeof res.error !== 'undefined' && !res.error) {
                                $('#form-change-password').trigger("reset");
                                $('.alert-changepassword').removeClass('alert-warning').addClass('alert-success');
                            }
                            $('.alert-changepassword > span').html(res.message);
                            $('.alert-changepassword').removeClass('hide').addClass('show');
                        },
                        complete: function (response) {
                            $('#form-change-password').removeClass('isPosting');
                            $('#form-change-password button[type="submit"]').html('Change');
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
        init: init
    };

})();