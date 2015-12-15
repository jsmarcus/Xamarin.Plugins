using System;

namespace Plugin.Iconize
{
    public class Icon : IIcon
    {
        public Char Character { get; private set; }

        public String Key { get; private set; }

        public Icon(String key, Char character)
        {
            Character = character;
            Key = key;
        }
    }
}