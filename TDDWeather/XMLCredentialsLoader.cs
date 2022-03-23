using System.Collections.Generic;
using System.Xml.Linq;

namespace TDDWeather
{
    public class XMLCredentialsLoader
    {
        private const string FILENAME = @"C:\Code\OpenWeatherKeys\Credentials.xml";

        public string GetApiKey()
        {
            var fileElements = XElement.Load(FILENAME);
            var element = fileElements.FirstNode;
            if (element != null && element.NodeType == System.Xml.XmlNodeType.Text)
            {
                return element.ToString();
            }
            throw new KeyNotFoundException();
        }
    }
}