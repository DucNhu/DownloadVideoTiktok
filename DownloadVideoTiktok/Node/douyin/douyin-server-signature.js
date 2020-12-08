const Signer = require("./douyin-signature");
const http = require("http");

(async function main() {
    try {
        const signer = new Signer();

        const server = http
            .createServer()
            .listen(8082, "localhost")
            .on("listening", function () {
                console.log("Douyin Signature server started");
            });

        // Uncomment if you want to auto-exit this application after a period of time
        // Supervisord will attempt to re-open it if are used
        // setTimeout(function () {
        //   server.close(() => {
        //     console.log("Server shutdown completed.");
        //     process.exit(1);
        //   });
        // }, 1 * 60 * 60 * 1000);

        setInterval(async function () {
            await signer.init();
        }, 15 * 60 * 1000);

        signer.init(); // !?

        server.on("request", (request, response) => {
            if (request.method === "POST" && request.url === "/signature") {
                var url = "";
                request.on("data", function (chunk) {
                    url += chunk;
                });

                request.on("end", async function () {
                    console.log("Received url: " + url);

                    try {
                        const token = await signer.sign(url);
                        let output = JSON.stringify({
                            signature: token
                        });
                        response.writeHead(200, { "Content-Type": "application/json" });
                        response.end(output);
                        console.log("Sent result: " + output);
                    } catch (err) {
                        console.log(err);
                    }
                });
            } else {
                response.writeHead(200, { 'Content-Type': 'text/plain' });
                response.end('SUCCESS');
                //response.statusCode = 404;
                //response.end();
            }
        });

        await signer.close();
    } catch (err) {
        console.error(err);
    }
})();