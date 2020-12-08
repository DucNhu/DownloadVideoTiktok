appVdl.getVideo = (function () {

    var init = function () {

        $('.btn-getlink-download').click(function (e) {
            e.preventDefault();

            if ($(this).hasClass('isPosting')) return;

            var _this = $(this);

            $(this).addClass('isPosting');
            $(this).attr('disabled', 'disabled');

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
                                reader.read().then(function (r) {
                                    if (r.done) {
                                        controller.close();
                                        return;
                                    }
                                    bytesReceived += r.value.length;
                                    var percenDownload = Math.round(bytesReceived / length * 100);
                                    _this.parent().find('.progress-bar').attr({
                                        'style': 'width: ' + percenDownload + '%',
                                        'aria-valuenow': percenDownload
                                    });
                                    controller.enqueue(r.value);
                                    push();
                                });
                            };

                            push();
                        }
                    });

                    return new Response(stream);
                }).then(function (response) { return response.blob(); }).then(function (blob) {
                    var a = document.createElement('a');
                    a.href = window.URL.createObjectURL(blob);
                    a.download = res.data.fileName;
                    a.style.display = 'none';
                    document.body.appendChild(a);
                    a.click();
                    a.remove();
                }).catch(function (err) {
                    console.log(err);
                    _this.removeClass('isPosting');
                    _this.removeAttr('disabled');
                    _this.attr('data-trigger', parseInt(_this.attr('data-trigger')) + 1);
                    if (parseInt(_this.attr('data-trigger')) <= 5) {
                        setTimeout(function () { _this.trigger('click'); }, 1000);
                    }
                });

            });
        });

    };

    return {
        init: init
    };

})();