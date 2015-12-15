using System.Collections.Generic;

namespace Plugin.Iconize.Fonts
{
    public static class MeteoconsCollection
    {
        public static IList<IIcon> Icons { get; } = new List<IIcon>();

        static MeteoconsCollection()
        {
            Icons.Add(new Icon("mc-sunrise-o", 'A'));
            Icons.Add(new Icon("mc-sun-o", 'B'));
            Icons.Add(new Icon("mc-moon-o", 'C'));
            Icons.Add(new Icon("mc-eclipse-o", 'D'));
            Icons.Add(new Icon("mc-cloudy-o", 'E'));
            Icons.Add(new Icon("mc-wind-o", 'F'));
            Icons.Add(new Icon("mc-snow-o", 'G'));
            Icons.Add(new Icon("mc-sun-cloud-o", 'H'));
            Icons.Add(new Icon("mc-moon-cloud-o", 'I'));
            Icons.Add(new Icon("mc-sunrise-sea-o", 'J'));
            Icons.Add(new Icon("mc-moonrise-sea-o", 'K'));
            Icons.Add(new Icon("mc-cloud-sea-o", 'L'));
            Icons.Add(new Icon("mc-sea-o", 'M'));
            Icons.Add(new Icon("mc-cloud-o", 'N'));
            Icons.Add(new Icon("mc-cloud-thunder-o", 'O'));
            Icons.Add(new Icon("mc-cloud-thunder2-o", 'P'));
            Icons.Add(new Icon("mc-cloud-drop-o", 'Q'));
            Icons.Add(new Icon("mc-cloud-rain-o", 'R'));
            Icons.Add(new Icon("mc-cloud-wind-o", 'S'));
            Icons.Add(new Icon("mc-cloud-wind-rain-o", 'T'));
            Icons.Add(new Icon("mc-cloud-snow-o", 'U'));
            Icons.Add(new Icon("mc-cloud-snow2-o", 'V'));
            Icons.Add(new Icon("mc-cloud-snow3-o", 'W'));
            Icons.Add(new Icon("mc-cloud-rain2-o", 'X'));
            Icons.Add(new Icon("mc-cloud-double-o", 'Y'));
            Icons.Add(new Icon("mc-cloud-double-thunder-o", 'Z'));
            Icons.Add(new Icon("mc-cloud-double-thunder2-o", '0'));
            Icons.Add(new Icon("mc-sun", '1'));
            Icons.Add(new Icon("mc-moon", '2'));
            Icons.Add(new Icon("mc-sun-cloud", '3'));
            Icons.Add(new Icon("mc-moon-cloud", '4'));
            Icons.Add(new Icon("mc-cloud", '5'));
            Icons.Add(new Icon("mc-cloud-thunder", '6'));
            Icons.Add(new Icon("mc-cloud-drop", '7'));
            Icons.Add(new Icon("mc-cloud-rain", '8'));
            Icons.Add(new Icon("mc-cloud-wind", '9'));
            Icons.Add(new Icon("mc-cloud-wind-rain", '!'));
            Icons.Add(new Icon("mc-cloud-snow", '"'));
            Icons.Add(new Icon("mc-cloud-snow2", '#'));
            Icons.Add(new Icon("mc-cloud-rain2", '$'));
            Icons.Add(new Icon("mc-cloud-double", '%'));
            Icons.Add(new Icon("mc-cloud-double-thunder", '&'));
            Icons.Add(new Icon("mc-thermometer", '\''));
            Icons.Add(new Icon("mc-compass", '('));
            Icons.Add(new Icon("mc-not-applicable", ')'));
            Icons.Add(new Icon("mc-celsius", '*'));
            Icons.Add(new Icon("mc-fahrenheit", '+'));
        }
    }
}