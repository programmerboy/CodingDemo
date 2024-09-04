using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiLoginSample.Helpers
{
    public static class ExtensionMethods
    {
        public static bool HasValue(this string src)
        {
            return src != null && !string.IsNullOrEmpty(src) && !string.IsNullOrWhiteSpace(src);
        }
    }
}
