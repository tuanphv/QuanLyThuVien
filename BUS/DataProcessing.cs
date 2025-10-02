using System.Text;
using System.Text.RegularExpressions;

namespace BUS
{
    public class DataProcessing
    {
        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            text = text.Replace("đ", "d").Replace("Đ", "D");

            string normalized = text.Normalize(NormalizationForm.FormD);

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalized, "");

            return result.Normalize(NormalizationForm.FormC);
        }
    }
}
