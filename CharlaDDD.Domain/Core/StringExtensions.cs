using System.Text.RegularExpressions;

namespace CharlaDDD.Domain.Core
{
    public static class StringExtensions
    {
        public static bool IsPhoneNumber(this string text)
            => Regex.IsMatch(text, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
    }
}
