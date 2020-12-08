using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DownloadVideoTiktok.Infrastructure.Extensions
{
    public static class StringExtension
    {
        public static string[] ToLines(this string str)
        {
            return str.Split(new[] { '\r', '\n' });
        }

        public static string ToAscii(this string str)
        {
            str = str.ToLower().Trim();
            str = Regex.Replace(str, "[á|à|ả|ã|ạ|â|ă|ấ|ầ|ẩ|ẫ|ậ|ắ|ằ|ẳ|ẵ|ặ]", "a", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ]", "e", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự]", "u", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[í|ì|ỉ|ĩ|ị]", "i", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[ó|ò|ỏ|õ|ọ|ô|ơ|ố|ồ|ổ|ỗ|ộ|ớ|ờ|ở|ỡ|ợ]", "o", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[đ|Đ]", "d", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[ý|ỳ|ỷ|ỹ|ỵ|Ý|Ỳ|Ỷ|Ỹ|Ỵ]", "y", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, "[,|~|@|/|.|:|?|#|$|%|&|*|(|)|+|”|“|'|\"|!|`|–]", "", RegexOptions.IgnoreCase);
            str = Regex.Replace(str, @"\s+", " ");
            str = Regex.Replace(str, "[\\s]", "-");
            str = Regex.Replace(str, @"-+", "-");

            return str;
        }
    }
}
