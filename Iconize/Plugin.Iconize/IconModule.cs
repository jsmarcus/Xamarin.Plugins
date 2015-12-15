using System;
using System.Collections.Generic;
using System.Linq;

namespace Plugin.Iconize
{
    public abstract class IconModule : IIconModule
    {
        #region Members

        private readonly Dictionary<String, IIcon> _icons = new Dictionary<String, IIcon>();

        #endregion Members

        #region Properties

        /// <summary>
        /// The characters in the font.
        /// </summary>
        public ICollection<IIcon> Characters => _icons.Values;

        /// <summary>
        /// Gets the font family.
        /// </summary>
        /// <value>
        /// The font family.
        /// </value>
        public String FontFamily { get; }

        /// <summary>
        /// Gets the name of the font.
        /// </summary>
        /// <value>
        /// The name of the font.
        /// </value>
        public String FontName { get; }

        /// <summary>
        /// Gets the font path.
        /// </summary>
        /// <value>
        /// The font path.
        /// </value>
        public String FontPath { get; }

        /// <summary>
        /// Gets or sets the keys.
        /// </summary>
        /// <value>
        /// The keys.
        /// </value>
        public ICollection<String> Keys => _icons.Keys;

        #endregion Properties

        protected IconModule(String fontFamily, String fontName, String fontPath, IEnumerable<IIcon> icons)
        {
            FontFamily = fontFamily;
            FontName = fontName;
            FontPath = fontPath;

            foreach (var icon in icons)
            {
                _icons.Add(icon.Key, icon);
            }
        }

        public IIcon GetIcon(String key)
        {
            if (_icons.ContainsKey(key))
            {
                return _icons[key];
            }
            return null;
        }

        public Boolean HasIcon(IIcon icon)
        {
            return _icons.Values.Contains(icon);
        }
    }
}