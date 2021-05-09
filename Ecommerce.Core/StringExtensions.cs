using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Core
{
    public static class StringExtensions
    {
        public static string WithNoStressMarks(this string str)
        {
            var noStressMarks = Encoding.GetEncoding(Constants.Encoding.ISO_8859_8).GetBytes(str);
            return Encoding.UTF8.GetString(noStressMarks);
        }
    }
}
