using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ShiningMoonVending
{
    class XMLConfigWorker
    {
        private readonly FileInfo xmlConfig = new FileInfo($@"{Directory.GetCurrentDirectory()}\config.xml");
        public XMLConfigWorker() 
        {
            if (!currentDirectoryContainseXMLConfigFile()) createXMLConfigFile();
        }
        private bool currentDirectoryContainseXMLConfigFile()
        {
            bool fileExist = xmlConfig.Exists;
            return fileExist;
        }

        private void createXMLConfigFile()
        {
            if (currentDirectoryContainseXMLConfigFile()) return;
            FileStream fsCreateXMLConfig= xmlConfig.Create();
            fsCreateXMLConfig.Close();

            loadXMLConfigTemplateInNewConfigFile();
            return;
        }

        private void loadXMLConfigTemplateInNewConfigFile()
        {
            XmlDocument configXML = new XmlDocument();
            configXML.LoadXml(@"<config><diseredItems></diseredItems></config>");
            configXML.Save(xmlConfig.FullName);
        }
        
        public XmlDocument GetXMLConfig()
        {
            XmlDocument configXML = new XmlDocument();
            configXML.Load(xmlConfig.FullName);
            return configXML;
        }
        public void SaveXMLConfig(XmlDocument XMLDoc)
        {
            XMLDoc.Save(xmlConfig.FullName);
        }
    }
}
