using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Xml;
using System.Xml.Linq;
using System.Security.AccessControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;

namespace ClientApp
{
    public partial class ClientApp : Form
    {
        string baseURI = @"http://localhost:50591";
        string app = "LibraryApp";
        RestClient client = null;
        public ClientApp()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
            createLibrary();
            getAllOffices();
        }

        private void createLibrary()
        {
            var request = new RestRequest("/api/somiod", Method.Post);
            request.AddParameter("application/xml", createXmlDocumentApp(app).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                Console.WriteLine("Library Created!");
            }
            else
            {
                Console.WriteLine("Error - Library not Created!");
            }

        }

        private void getAllOffices()
        {
            var request = new RestRequest("/api/somiod/{application}", Method.Get);
            request.AddUrlSegment("application", app);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "container");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                richTextBoxOffices.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

                if (xmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxOffices.AppendText("No Offices");
                    comboBoxOffices.Items.Add("No Offices");
                    comboBoxOffices.SelectedIndex = 0;
                    return;
                }

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    richTextBoxOffices.AppendText(node.InnerText + Environment.NewLine);
                    comboBoxOffices.Items.Add(node.InnerText);
                }

            }
            else
            {
                MessageBox.Show("Error getting all containers name");
            }
        }

        private void btnReserveOffice_Click(object sender, EventArgs e)
        {
            if (comboBoxOffices.SelectedItem == null || comboBoxOffices.SelectedItem.ToString() == "No Offices") 
            {
                MessageBox.Show("Invalid Office");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("Name not specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Post);
            request.AddUrlSegment("application", app);
            request.AddUrlSegment("container", comboBoxOffices.SelectedItem.ToString());
            request.AddParameter("application/xml", createXmlDocumentData(textBoxName.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                richTextBoxActiveReserves.AppendText(comboBoxOffices.SelectedItem.ToString() + " reserved" + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("Error creating " + textBoxName.Text + " data");
            }

        }

        private XmlDocument createXmlDocumentApp(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Application");
            rootElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            rootElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/MiddlewareDatabaseAPI.Models");
            xmlDoc.AppendChild(rootElement);
            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = name;
            rootElement.AppendChild(nameElement);

            return xmlDoc;
        }

        private XmlDocument createXmlDocumentData(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("DataOrSubscription");
            rootElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            rootElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/MiddlewareDatabaseAPI.Models");
            xmlDoc.AppendChild(rootElement);

            XmlElement contElement = xmlDoc.CreateElement("content");
            contElement.InnerText = "";
            rootElement.AppendChild(contElement);

            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = name;
            rootElement.AppendChild(nameElement);

            XmlElement resTypeElement = xmlDoc.CreateElement("res_type");
            resTypeElement.InnerText = "data";
            rootElement.AppendChild(resTypeElement);

            return xmlDoc;
        }

    }
}
