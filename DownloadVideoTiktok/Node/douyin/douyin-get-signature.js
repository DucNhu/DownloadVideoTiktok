const Signer = require('./tiktok-signature')


module.exports = (async function (callback, str) {

    var generateSignature = (async function (str) {
        let output = '';
        try {
            const signer = new Signer()
            await signer.init()

            const verifyFp = await signer.getVerifyFp();
            const token = await signer.sign(str)
            output = JSON.stringify({
                signature: token,
                verifyFp: verifyFp,
            });
            console.log(output)
            await signer.close()
        } catch (err) {
            console.error(err);
        }
        return output;
    })

    callback(null, await generateSignature(str));
})