appVdl.home = (function () {

    var init = function () {

        $('.btn-share-fb').click(function (e) {
            e.preventDefault();

            FB.ui({
                display: 'popup',
                method: 'share',
                href: document.location.href,
                redirect_uri: document.location.href
            }, function (response) {
                console.log(response);
            });

        });

        $(document).on('click', '.btn-download-video', function (e) {
            e.preventDefault();

            if ($(this).hasClass('isPosting')) return;

            var _this = $(this);

            $(this).addClass('isPosting');
            $(this).addClass('d-none');
            $(this).parent().find('span').removeClass('d-none');

            $.post('/get-url-video', { id: $(this).attr('data-id') }, function (res) {

                fetch(res.data.url, {
                    method: 'GET',
                    referrer: ''
                }).then(function (response) {

                    var length = response.headers.get('Content-Length');
                    var bytesReceived = 0;
                    var reader = response.body.getReader();
                    var stream = new ReadableStream({
                        start: function (controller) {
                            function push() {
                                reader.read().then(function(r){
                                    if (r.done) {
                                        controller.close();
                                        return;
                                    }
                                    bytesReceived += r.value.length;
                                    var percenDownload = Math.round(bytesReceived / length * 100);
                                    _this.parent().addClass('p' + percenDownload);
                                    _this.parent().find('span').html(percenDownload + '%');
                                    controller.enqueue(r.value);
                                    push();
                                });
                            };

                            push();
                        }
                    });

                    return new Response(stream);
                }).then(function (response) { return response.blob(); }).then(function (blob) {
                    _this.parent().find('span').addClass('d-none');
                    _this.parent().find('.btn-save-video').removeClass('d-none');
                    var a = _this.parent().find('.btn-save-video').get(0);
                    a.href = window.URL.createObjectURL(blob);
                    a.download = res.data.fileName;
                    a.click();
                }).catch(function (err) {
                    console.log(err);
                    _this.removeClass('isPosting');
                    _this.removeClass('d-none');
                    _this.parent().find('span').addClass('d-none');
                    _this.attr('data-trigger', parseInt(_this.attr('data-trigger')) + 1);
                    if (parseInt(_this.attr('data-trigger')) <= 5) {
                        setTimeout(function () { _this.trigger('click'); }, 1000);
                    }
                });

            });

        });

        $(document).on('click', '.btn-download-all', function () {

            if ($('.tbl-check:checked').length === 0) {
                swal("Please select video");
                return;
            }

            $('.tbl-check:checked').each(function () {
                $(this).closest('tr').find('.btn-download-video').trigger('click');
            });

        });

        $(document).on('click', '.btn-download-zip', function () {

            if ($('.btn-download-zip').hasClass('isPosting')) return;

            var listItems = [];

            $('.tbl-check:checked').each(function () {
                listItems.push($(this).attr('data-item'));
            });

            if (listItems.length === 0) {
                swal("Please select video");
                return;
            }

            $('.btn-download-zip').addClass('isPosting');
            $('.btn-download-zip').html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');

            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                if (xhttp.readyState === 4 && xhttp.status === 200) {
                    var a = document.createElement('a');
                    a.href = window.URL.createObjectURL(xhttp.response);
                    a.download = xhttp.getResponseHeader("fileName");
                    a.style.display = 'none';
                    document.body.appendChild(a);
                    a.click();

                    $('.btn-download-zip').removeClass('isPosting');
                    $('.btn-download-zip').html('Download ZIP');
                }
            };
            xhttp.open("POST", "/download-zip");
            xhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            xhttp.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
            xhttp.responseType = 'blob';
            xhttp.send($.param({ ids: listItems }));
        });

        $(document).on('click', '.tbl-check-all', function () {

            var _isCheck = $(this).is(':checked');

            $('.tbl-check').each(function () {
                $(this).prop('checked', _isCheck);
            });
        });

        $(document).on('click', '.tbl-check', function () {
            $('.tbl-check-all').prop('checked', $('.tbl-check:checked').length > 0);
        });

        $("#form-video").validate({
            rules: {
                url: {
                    required: true
                }
            },
            messages: {
                url: 'This field is required.'
            },
            submitHandler: function (e) {

                if (!$('#form-video').hasClass('isPosting')) {

                    $('#form-video').addClass('isPosting');
                    $('#form-video button[type="submit"]').html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');

                    $.ajax({
                        type: "POST",
                        url: "/get-video",
                        beforeSend: function (xhr) {
                            xhr.setRequestHeader("XSRF-TOKEN", $('input:hidden[name="__RequestVerificationToken"]').val());
                        },
                        data: $('#form-video').serialize(),
                        success: function (res) {
                            $('.box-result').html(res);
                        },
                        complete: function (response) {
                            $('#form-video').removeClass('isPosting');
                            $('#form-video button[type="submit"]').html('Get link');
                            appVdl.main.resetCaptcha();
                        },
                        failure: function (response) {
                            alert(response);
                        }
                    });

                }

                return false;
            }
        });

        if ($('#txtUrl').val() !== '') {
            $('#form-video').submit();
        }
    };

    return {
        init: init
    };

})();