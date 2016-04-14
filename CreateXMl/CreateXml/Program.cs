using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace CreateXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0","utf-8","");
            xmlDoc.AppendChild(node);

            XmlNode root = xmlDoc.CreateElement("Users");
            xmlDoc.AppendChild(root);

            List<string> zhs = new List<string>();
            zhs.Add("15808098980");

            List<string> ls = new List<string>();
            ls.Add("13808098980");
            ls.Add("13709829798");
            ls.Add("15210837652");

            CreateNode(xmlDoc, root, "张三", zhs);
            CreateNode(xmlDoc, root, "李四", ls);

            try
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                xmlDoc.Save(Directory.GetCurrentDirectory() + "//contact.xml");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        static void CreateNode(XmlDocument xmlDoc, XmlNode parent, string nameValue, List<string> telList)
        {
            XmlNode userNode = xmlDoc.CreateNode(XmlNodeType.Element, "User", null);
            parent.AppendChild(userNode);

            XmlNode nameNode = xmlDoc.CreateNode(XmlNodeType.Element, "name", null);
            nameNode.InnerText = nameValue;
            userNode.AppendChild(nameNode);

            foreach(string telNumber in telList)
            {
                XmlNode telNode = xmlDoc.CreateNode(XmlNodeType.Element, "telphone", null);
                telNode.InnerText = telNumber;
                userNode.AppendChild(telNode);
            }
        }
    }
}
