using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Storage.Common.Extensions
{
    public static class StringExtensions
    {
        public static string ToTsQueryCompat(this string source)
        {
            var space = new Regex(@"\s+");
            return $"{space.Replace(source.Trim().RemoveAccent(), "&")}:*";
        }

        public static string RemoveAccent(this string value)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return string
                .Concat(value.Normalize(NormalizationForm.FormD).Where(ch =>
                    CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark))
                .Normalize(NormalizationForm.FormC);
        }
    }
}