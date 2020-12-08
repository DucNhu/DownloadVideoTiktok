const puppeteer = require("puppeteer-extra");
const devices = require("puppeteer/DeviceDescriptors");
const iPhonex = devices["iPhone X"];
const pluginStealth = require("puppeteer-extra-plugin-stealth");

puppeteer.use(pluginStealth());

class Signer {
    userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36";
    args = [
        "--no-sandbox",
        "--disable-setuid-sandbox",
        "--disable-infobars",
        "--window-position=0,0",
        "--ignore-certifcate-errors",
        "--ignore-certifcate-errors-spki-list"
    ];

    constructor(userAgent, browser) {
        if (userAgent) {
            this.userAgent = userAgent;
        }

        if (browser) {
            this.browser = browser;
            this.isExternalBrowser = true;
        }

        this.args.push(`--user-agent="${this.userAgent}"`);

        this.options = {
            args: this.args,
            headless: true,
            ignoreHTTPSErrors: true,
            userDataDir: "./tmp"
        };
    }

    async init() {
        if (!this.browser) {
            this.browser = await puppeteer.launch(this.options);
        }

        this.page = await this.browser.newPage();

        //let emulateTemplate = { ...iPhonex };
        //emulateTemplate.viewport.width = getRandomInt(320, 1920);
        //emulateTemplate.viewport.height = getRandomInt(320, 1920);
        //emulateTemplate.viewport.deviceScaleFactor = getRandomInt(1, 3);
        //emulateTemplate.viewport.isMobile = Math.random() > 0.5;
        //emulateTemplate.viewport.hasTouch = Math.random() > 0.5;

        //await this.page.emulate(emulateTemplate);
        await this.page.setUserAgent(this.userAgent);

        await this.page.goto("https://www.douyin.com/share/user/108786612941", {
            waitUntil: "load",
        });

        await this.page.evaluate(() => {
            window.generateSignature = function generateSignature(str) {
                return __M.require("douyin_falcon:node_modules/byted-acrawler/dist/runtime").sign(str);
            };
        }, null);        

        return this;
    }

    async sign(str) {
        let res = await this.page.evaluate(`generateSignature("${str}")`);
        return res;
    }

    async close() {
        if (this.browser && !this.isExternalBrowser) {
            await this.browser.close();
            this.browser = null;
        }
        if (this.page) {
            this.page = null;
        }
    }


}

module.exports = Signer;