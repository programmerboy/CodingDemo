using System.Reflection;

namespace MauiLoginSample.Helpers
{
    public static class ExtensionMethods
    {
        public static bool CustomCompare(this string source, string stringToFind, bool ignoreNullOrEmpty = false)
        {
            if (ignoreNullOrEmpty && string.IsNullOrEmpty(stringToFind)) { return true; }
            return string.IsNullOrEmpty(source) ? false : source.IndexOf(stringToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool ExactMatch(this string source, string stringToFind, bool ignoreNullOrEmpty = false)
        {
            if (ignoreNullOrEmpty && string.IsNullOrEmpty(stringToFind))
                return true;

            return String.CompareOrdinal(source, stringToFind) == 0;
        }

        public static bool HasValue(this string src)
        {
            return src != null && !string.IsNullOrEmpty(src) && !string.IsNullOrWhiteSpace(src);
        }

        public static string GetLastPart(this string source, char separator = ' ')
        {
            if (string.IsNullOrEmpty(source))
            { return String.Empty; }

            separator = separator == ' ' ? '\\' : separator;

            if (source.IndexOf(separator) < 0)
            { return source; }

            return source.Substring(source.LastIndexOf(separator) + 1);
        }

        public static bool AreAllPropertiesSet<T>(this T myObject, List<string> propertiesToCheck = null)
        {
            var props = myObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (propertiesToCheck != null)
                props = props.Where(r => propertiesToCheck.Contains(r.Name, StringComparer.OrdinalIgnoreCase)).ToArray();

            foreach (PropertyInfo prop in props)
            {
                if (prop.PropertyType == typeof(string) && (prop.GetValue(myObject) == null || !prop.GetValue(myObject).ToString().HasValue()))
                    return false;
                else if (prop.GetValue(myObject) == null)
                    return false;
            }

            return true;
        }

        public static T CleanForTransport<T>(this T myObject)
        {
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in properties)
            {
                if (prop.PropertyType == typeof(string))
                {
                    var value = (string)prop.GetValue(myObject);

                    if (prop.CanWrite)
                    {
                        prop.SetValue(myObject, value == null ? String.Empty : value.Trim());
                    }
                }
            }

            return myObject;
        }

        public static T CopyProperties<T>(this object sourceObject, T destObject = default, List<string> propertiesToIgnore = null)
        {
            var properties = sourceObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (propertiesToIgnore != null)
                properties = properties.Where(r => !propertiesToIgnore.Contains(r.Name)).ToArray();

            if (destObject == null)
                destObject = (T)Activator.CreateInstance(typeof(T));

            foreach (PropertyInfo prop in properties)
            {
                var destProp = destObject.GetType().GetProperty(prop.Name);

                if (destProp == null)
                    continue;

                var propValue = prop.GetValue(sourceObject);

                if (propValue != null)
                    destProp.SetValue(destObject, propValue);
            }

            return destObject;
        }
    }
}
