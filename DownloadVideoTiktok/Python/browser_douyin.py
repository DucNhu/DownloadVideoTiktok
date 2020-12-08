import asyncio
import pyppeteer
import random
import os
from pyppeteer_stealth import stealth

class browser_douyin:
    def __init__(self, url, str):
        self.userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36"
        self.args = [
            "--no-sandbox",
            "--disable-setuid-sandbox",
            "--disable-infobars",
            "--window-position=0,0",
            "--ignore-certifcate-errors",
            "--ignore-certifcate-errors-spki-list",
            "--user-agent=" + self.userAgent
        ]

        self.options = {
            'args': self.args,
            'headless': True,
            'ignoreHTTPSErrors': True,
            'userDataDir': "./tmp"
        }

        asyncio.get_event_loop().run_until_complete(self.startDouyin(url, str))

    async def start(self, str):
        self.browser = await pyppeteer.launch(self.options)
        self.page = await self.browser.newPage()

        await stealth(self.page)

        await self.page.setUserAgent(self.userAgent)

        await self.page.goto("file:///" + os.path.dirname(os.path.abspath(__file__)) + "/signature.html", {
            'waitUntil': "load"
        })

        self.signature = await self.page.evaluate('''() => {
            return generateSignature("''' + str + '''");
          }''')

        await self.browser.close()

    async def startDouyin(self, url, str):
        self.browser = await pyppeteer.launch(self.options)
        self.page = await self.browser.newPage()

        await stealth(self.page)

        await self.page.setUserAgent(self.userAgent)

        await self.page.goto(url, {
            'waitUntil': "load"
        })

        self.signature = await self.page.evaluate('''() => {
            return __M.require("douyin_falcon:node_modules/byted-acrawler/dist/runtime").sign("''' + str + '''");
          }''')
          
        await self.browser.close()