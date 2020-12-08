appVdl.upgrade = (function () {

    var createButtonPaypal = function(domBtn, package) {
        paypal.Buttons({
            style: {
                shape: 'pill',
                color: 'blue',
                layout: 'vertical',
                label: 'paypal'
            },
            createOrder: function (data, actions) {

                $(domBtn).addClass('d-none');
                $(domBtn).parent().append('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');

                return $.post('/createPayment', { package: package }).done(function (res) {
                    return res;
                }).then(function (res) {
                    return res.data;
                });
            },
            onApprove: function (data, actions) {
                return fetch(
                    '/updatePayment',
                    {
                        method: 'POST',
                        headers: {
                            'Accept': 'application/json',
                            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                        },
                        body: $.param({ orderId: data.orderID })
                    }
                ).then(function (res) {
                    return res.json();
                }).then(function (data) {
                    swal(data.message).then(function (value) { document.location.reload(); });
                });
            },
            onCancel: function (data) {
                $(domBtn).removeClass('d-none');
                $(domBtn).parent().find('.spinner-border').remove();
            }
        }).render(domBtn);
    };

    var init = function () {

        createButtonPaypal('#btn-paypal-week', 'WEEK');
        createButtonPaypal('#btn-paypal-month', 'MONTH');
        createButtonPaypal('#btn-paypal-year', 'YEAR');

        $('#modal-notify').on('hidden.bs.modal', function (e) {
            if ($('#modal-notify').hasClass('isSuccess')) document.location.reload();
        });

        $(".btn-upgrade").click(function (e) {
            e.preventDefault();

            if ($(this).hasClass('isPosting')) return;

            var _this = $(this);

            _this.addClass('isPosting');
            _this.html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');

            $.ajax({
                type: "POST",
                url: "/upgrade",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: {
                    package: _this.attr('data-package')
                },
                success: function (res) {
                    if (typeof res.error !== 'undefined' && !res.error) $('#modal-notify').addClass('isSuccess');
                    $('#modal-notify .modal-body').html(res.message);
                    $('#modal-notify').modal('show');
                },
                complete: function (response) {
                    _this.removeClass('isPosting');
                    _this.html('Upgrade');
                },
                failure: function (response) {
                    alert(response);
                }
            });
        });
    };

    return {
        init: init
    };

})();