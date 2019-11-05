using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace SerialPortTest
{
    public class AppConfig
    {
        static string FileName = System.Environment.CurrentDirectory + @"\AppConfig.xml";

        public static string GetItemValue(string key)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(FileName);
                XmlNode node;
                XmlElement element;
                node = document.SelectSingleNode("//appSettings");
                element = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (element != null)
                {
                    return element.GetAttribute("value");
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
                Message.Warning(e.Message);
                throw e;
            }
        }

        public static string GetItemValue(string key,string filepath)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(filepath);
                XmlNode node;
                XmlElement element;
                node = document.SelectSingleNode("//appSettings");
                element = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (element != null)
                {
                    return element.GetAttribute("value");
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
                Message.Warning(e.Message);
                throw e;
            }
        }

        public static void SetItemValue(string key, string value)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(FileName);
                XmlNode node;
                XmlElement element;
                node = document.SelectSingleNode("//appSettings");
                element = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (element != null)
                {
                    element.SetAttribute("value", value);
                }
                else
                {
                    element = document.CreateElement("add");
                    element.SetAttribute("key", key);
                    element.SetAttribute("value", value);
                    node.AppendChild(element);
                }
                document.Save(FileName);
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
                Message.Warning(e.Message);
                throw e;
            }
        }

        public static void SetItemValue(string key, string value,string filepath)
        {
            XmlDocument document = new XmlDocument();
            try
            {
                document.Load(filepath);
                XmlNode node;
                XmlElement element;
                node = document.SelectSingleNode("//appSettings");
                element = (XmlElement)node.SelectSingleNode("//add[@key='" + key + "']");
                if (element != null)
                {
                    element.SetAttribute("value", value);
                }
                else
                {
                    element = document.CreateElement("add");
                    element.SetAttribute("key", key);
                    element.SetAttribute("value", value);
                    node.AppendChild(element);
                }
                document.Save(filepath);
            }
            catch (Exception e)
            {
                Log.Write(e.Message);
                Message.Warning(e.Message);
                throw e;
            }
        }
    }
}
