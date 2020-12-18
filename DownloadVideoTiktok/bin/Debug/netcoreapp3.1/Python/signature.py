import sys
from browser import browser
from browser_douyin import browser_douyin

class Signature:
    def getSignature(self, url, str):
        b = browser(url, str)
        return b.signature
    def getSignatureDouyin(self, url, str):
        b = browser_douyin(url, str)
        return b.signature

if __name__ == "__main__":
    _sign = Signature()
    if sys.argv[1] == "TIKTOK": print(_sign.getSignature(sys.argv[2], sys.argv[3]))
    if sys.argv[1] == "DOUYIN": print(_sign.getSignatureDouyin(sys.argv[2], sys.argv[3]))