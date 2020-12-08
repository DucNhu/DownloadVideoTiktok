//$(document).ready(function () {

//    $(document).on('click', '.btn-download-video', function (e) {
//        e.preventDefault();

//        if ($(this).hasClass('isPosting')) return;

//        var _this = $(this);

//        $(this).addClass('isPosting');
//        //$(this).html('<div class="spinner-border" role="status"><span class="sr-only">Loading...</span></div>');
//        $(this).html('<div class="loading-download c100 p0 small green"><span>0%</span><div class="slice"><div class="bar"></div><div class="fill"></div></div></div>');

//        $.post('/get-url-video', { id: $(this).attr('data-id') }, function (res) {

//            fetch(res.data.url).then((response) => {
//                var length = response.headers.get('Content-Length');
//                var bytesReceived = 0;
//                var reader = response.body.getReader();
//                var stream = new ReadableStream({
//                    start(controller) {
//                        // The following function handles each data chunk
//                        function push() {
//                            // "done" is a Boolean and value a "Uint8Array"
//                            reader.read().then(({ done, value }) => {
//                                // Is there no more data to read?
//                                if (done) {
//                                    // Tell the browser that we have finished sending data
//                                    controller.close();
//                                    return;
//                                }

//                                bytesReceived += value.length;
//                                console.log('Received', Math.round(bytesReceived / length * 100), '% bytes of data so far');
//                                _this.html('<div class="loading-download c100 p' + Math.round(bytesReceived / length * 100) + ' small green"><span>' + Math.round(bytesReceived / length * 100) + '%</span><div class="slice"><div class="bar"></div><div class="fill"></div></div></div>');
//                                // Get the data and send it to the browser via the controller
//                                controller.enqueue(value);
//                                push();
//                            });
//                        };

//                        push();
//                    }
//                });

//                return new Response(stream);
//            })
//            .then(response => response.blob())
//            .then((blob) => {
//                var a = document.createElement('a');
//                a.href = window.URL.createObjectURL(blob);
//                a.download = res.data.fileName;
//                a.style.display = 'none';
//                document.body.appendChild(a);
//                a.click();
//                a.remove();
//            }).catch(function (err) {
//                console.log(err);
//            });

//            fetch(res.data.url).then((response) => {
//                var length = response.headers.get('Content-Length');
//                var reader = response.body.getReader();
//                var bytesReceived = 0;
//                return reader.read().then(function processResult(result) {
//                    if (result.done) {
//                        console.log('Fetch complete');
//                        return;
//                    }
//                    bytesReceived += result.value.length;
//                    console.log('Received', Math.round(bytesReceived / length * 100), '% bytes of data so far');
//                    return reader.read().then(processResult);
//                });
//            }).then((blob) => {
//                var a = document.createElement('a');
//                a.href = window.URL.createObjectURL(blob);
//                a.download = res.data.fileName;
//                a.style.display = 'none';
//                document.body.appendChild(a);
//                a.click();
//                a.remove();
//            }).catch(function (err) {
//                console.log(err);
//            });

//            fetch(res.data.url, {
//                method: 'GET'
//                //referrer: ''
//            }).then(function (resp) {
//                return resp.blob();
//            }).then(function (blob) {
//                var a = document.createElement('a');
//                a.href = window.URL.createObjectURL(blob);
//                a.download = res.data.fileName;
//                a.style.display = 'none';
//                document.body.appendChild(a);
//                a.click();
//                a.remove();
//            });

//            var xhttp = new XMLHttpRequest();
//            xhttp.addEventListener("progress", function (evt) {
//                if (evt.lengthComputable) {
//                    var percentComplete = Math.round(evt.loaded / evt.total * 100);

//                    _this.html('<div class="loading-download c100 p' + percentComplete + ' small green"><span>' + percentComplete + '%</span><div class="slice"><div class="bar"></div><div class="fill"></div></div></div>');

//                    //_this.parent().find('.loading-download span').html(percentComplete + '%');
//                    //_this.parent().find('.loading-download').removeClass('p' + (percentComplete - 1));
//                    //_this.parent().find('.loading-download').addClass('p' + percentComplete);
//                }
//            }, false);
//            xhttp.onreadystatechange = function () {
//                if (xhttp.readyState === 4 && xhttp.status === 200) {
//                    var a = document.createElement('a');
//                    a.href = window.URL.createObjectURL(xhttp.response);
//                    a.download = res.data.fileName;
//                    a.style.display = 'none';
//                    document.body.appendChild(a);
//                    a.click();
//                    a.remove();
//                }
//            };
//            xhttp.open("GET", res.data.url);
//            //xhttp.setRequestHeader('referer', '');
//            xhttp.responseType = 'blob';
//            xhttp.send();
//        });

//    });

//});