using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyMoney.Helper
{
    public static class StringExtension
    {
        public static string CutDetails(this string original, int length, string mark)
        {
            if (!string.IsNullOrWhiteSpace(original) && original.Length > length)
            {
                return string.Format("{0}{1}", original.Substring(0, length), mark);
            }

            return original;
        }
    }
}