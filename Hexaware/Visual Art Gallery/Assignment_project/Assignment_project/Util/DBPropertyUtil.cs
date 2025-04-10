using System.Collections.Generic;
using System.IO;

namespace VirtualArtGallery.Util
{
    public class DBPropertyUtil
    {
        public static Dictionary<string, string> GetConnectionProperties(string filePath)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();

            foreach (string line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    var parts = line.Split('=');
                    properties[parts[0].Trim()] = parts[1].Trim();
                }
            }

            return properties;
        }
    }
}
