using System.Collections.Generic;
using System.Xml.Linq;

namespace TDDWeather
{
    public class XMLCredentialsLoader : ICredentialsLoader
    {
        // Save the credential apikey in a file formatted thus:
        // <?xml version="1.0" encoding="utf-8" standalone="yes"?>
        // <ApiKey>abcdef1234567890abcdef1234567890</ApiKey>
        private string pathname;

        public XMLCredentialsLoader(string pathname) => this.pathname = pathname;

        public string GetApiKey()
        {
            var fileElements = XElement.Load(pathname);
            var element = fileElements.FirstNode;
            if (element != null && element.NodeType == System.Xml.XmlNodeType.Text)
            {
                return element.ToString();
            }
            throw new KeyNotFoundException();
        }
    }
}