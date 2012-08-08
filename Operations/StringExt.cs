using System;

namespace Extensions
{
    public static class StringExt
    {
        public static string Reverse(this string s)
        {
            var original = s.ToCharArray();
            Array.Reverse(original);
            return new string(original);
        }
    }
}