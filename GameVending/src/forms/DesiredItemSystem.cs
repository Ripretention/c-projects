using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System;
using System.Runtime.InteropServices;

namespace ShiningMoonVending
{
    public partial class DesiredItemSystem : Form
    {
        private XMLConfigWorker XMLConfig = new XMLConfigWorker();
        private List<string> diseredItemsList;
        public DesiredItemSystem(ref List<string> diseredItemsList)
        {
            InitializeComponent();
            this.diseredItemsList = diseredItemsList;
            loadDesiredItems();
        }
        private void loadDesiredItems()
        {
            diseredItems.Items.AddRange(diseredItemsList.ToArray());
        }
        private void addItemButton_Click(object sender, EventArgs e)
        {
            string addingItemName = textBox1.Text;
            bool resultAdding = addItemToDiseredList(addingItemName);
            if (!resultAdding) return;

            diseredItemsList.Add(addingItemName);
            updateDiseredItemsList();
        }
        private bool addItemToDiseredList(string itemName)
        {
            itemName = itemName.Trim();
            if (itemName.Length < 4 || diseredItemsList.Contains(itemName)) return false;
           
            XmlDocument XMLConfigDoc = XMLConfig.GetXMLConfig();
            XmlElement disiretItemElement = XMLConfigDoc.CreateElement("diseredItem");
            XmlText disiredItemText = XMLConfigDoc.CreateTextNode(itemName);

            disiretItemElement.AppendChild(disiredItemText);
            XMLConfigDoc.DocumentElement.SelectSingleNode("diseredItems").AppendChild(disiretItemElement);

            XMLConfig.SaveXMLConfig(XMLConfigDoc);
            return true;
        }

        private void updateDiseredItemsList()
        {
            diseredItems.Items.Clear();
            diseredItems.Items.AddRange(diseredItemsList.ToArray());
        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            string removedItemName = diseredItems.SelectedItem.ToString();
            bool resultRemoved = deleteItemOfDiseredList(removedItemName);
            if (!resultRemoved) return;

            diseredItemsList.Remove(removedItemName);
            updateDiseredItemsList();
        }
        
        private bool deleteItemOfDiseredList(string itemName)
        {
            itemName = itemName.Trim();
            if (!diseredItemsList.Contains(itemName)) return false;
            
            XmlDocument XMLConfigDoc = XMLConfig.GetXMLConfig();
            XmlNode removedDisiredItem = XMLConfigDoc.DocumentElement.SelectSingleNode($@"diseredItems//*[.='{itemName}']");
            if (removedDisiredItem == null) return false;

            XMLConfigDoc.DocumentElement.SelectSingleNode("diseredItems").RemoveChild(removedDisiredItem);
            XMLConfig.SaveXMLConfig(XMLConfigDoc);
            
            return true;
        }
    }
}
