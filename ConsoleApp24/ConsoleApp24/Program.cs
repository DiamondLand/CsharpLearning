using Newtonsoft.Json;
using System;

public class XmlToJsonConverter
{
    public static string ConvertXmlToJson(string xml)
    {
        try
        {
            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(xml);
            string json = JsonConvert.SerializeXmlNode(xmlDoc.DocumentElement);
            return json;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
            return string.Empty;
        }
    }
}
