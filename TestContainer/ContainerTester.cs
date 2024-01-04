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

namespace TestContainer
{
    public partial class ContainerTester : Form
    {
        string baseURI = @"http://localhost:50591";
        RestClient client = null;
        public ContainerTester()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
        }

        private void btnGetAllContainers_Click(object sender, EventArgs e)
        {
            getAllContainers(textBoxNameApp.Text);
        }

        private void getAllContainers(string name)
        {
            textBoxNameApp.Text = name;

            if (name == "")
            {
                MessageBox.Show("No Application specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}", Method.Get);
            request.AddUrlSegment("application", name);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "container");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                richTextBoxContainers.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

                if (xmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxContainers.AppendText("No Containers");
                    return;
                }

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    richTextBoxContainers.AppendText(node.InnerText + Environment.NewLine);
                }

            }
            else
            {
                MessageBox.Show("Error getting all containers name");
            }
        }

        private void btnGetContainer_Click(object sender, EventArgs e)
        {

            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No Application specified");
                return;
            }

            if (textBoxNameContainer.Text == "")
            {
                MessageBox.Show("No Container specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Get);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer.Text);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            int id, parent;

            if (response.IsSuccessful)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    switch (node.Name)
                    {
                        case "creation_dt":
                            textBoxDTC.Text = node.InnerText;
                            break;
                        case "id":
                            int.TryParse(node.InnerText, out id);
                            textBoxID.Text = id.ToString();
                            break;
                        case "name":
                            textBoxName.Text = node.InnerText;
                            break;
                        case "parent":
                            int.TryParse(node.InnerText, out parent);
                            textBoxParent.Text = parent.ToString();
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error getting " + textBoxNameContainer.Text + " information");
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No Application specified");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("No name specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}", Method.Post);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddParameter("application/xml", createXmlDocument(textBoxName.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                getAllContainers(textBoxNameApp2.Text);
                MessageBox.Show(response.Content.ToString());
                textBoxID.Clear();
                textBoxDTC.Clear();
            }
            else
            {
                MessageBox.Show("Error creating " + textBoxNameContainer.Text + " container");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "" && textBoxNameContainer.Text == "" && textBoxID.Text == "" && textBoxDTC.Text == "" && textBoxParent.Text == "")
            {
                MessageBox.Show("No container loaded");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("No name specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Put);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer.Text);
            request.AddParameter("application/xml", createXmlDocument(textBoxName.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                getAllContainers(textBoxNameApp2.Text);
                MessageBox.Show(response.Content.ToString());
                textBoxNameContainer.Clear();
            }
            else
            {
                MessageBox.Show("Error editing " + textBoxNameContainer.Text + " container");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No Application specified");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("No name specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Delete);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxName.Text);
            request.AddParameter("application/xml", createXmlDocument(textBoxName.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                getAllContainers(textBoxNameApp2.Text);
                MessageBox.Show(response.Content.ToString());
                clearTxtBoxes();
            }
            else
            {
                MessageBox.Show("Error editing " + textBoxNameContainer.Text + " container");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTxtBoxes();
        }

        private void clearTxtBoxes()
        {
            textBoxID.Clear();
            textBoxDTC.Clear();
            textBoxName.Clear();
            textBoxParent.Clear();
        }

        private XmlDocument createXmlDocument(string name)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Container");
            rootElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            rootElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/MiddlewareDatabaseAPI.Models");
            xmlDoc.AppendChild(rootElement);
            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = name;
            rootElement.AppendChild(nameElement);

            return xmlDoc;
        }

       
    }
}
