using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;

namespace MaterialIcons.FormsPlugin.Abstractions
{
    public sealed class MaterialIconsConverter : TypeConverter
    {
        /// <summary>
        /// Determines whether this instance [can convert from] the specified source type.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public override Boolean CanConvertFrom(Type sourceType)
        {
            if (sourceType == null)
                throw new ArgumentNullException(nameof(sourceType));
            return sourceType == typeof(String);
        }

        /// <summary>
        /// Converts from.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public override Object ConvertFrom(CultureInfo culture, Object value)
        {
            if (value == null)
                return null;

            var valuestring = value as String;
            if (valuestring != null)
            {
                var fieldInfo = typeof(MaterialIcons).GetRuntimeFields().FirstOrDefault(x => x.Name == valuestring);
                if (fieldInfo != null)
                {
                    return (MaterialIcons)fieldInfo.GetValue(null);
                }
            }

            throw new InvalidOperationException($"Cannot convert {value} into {typeof(MaterialIcons)}");
        }
    }
}
