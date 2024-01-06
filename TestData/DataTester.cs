using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using RestSharp;

namespace TestData
{
    public partial class DataTester : Form
    {
        string baseURI = @"http://localhost:50591";
        RestClient client = null;
        public DataTester()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
        }

        private void btnGetAllDatas_Click(object sender, EventArgs e)
        {
            getAllDatas(textBoxNameApp.Text,textBoxNameContainer.Text);
        }

        private void getAllDatas(string appname, string contname)
        {
            textBoxNameApp.Text = appname;
            textBoxNameContainer.Text = contname;

            if(appname == "")
            {
                MessageBox.Show("No application specified");
                return;
            }

            if(contname == "")
            {
                MessageBox.Show("No container specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Get);
            request.AddUrlSegment("application", appname);
            request.AddUrlSegment("container", contname);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "data");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                richTextBoxDatas.Clear();

                if (xmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxDatas.AppendText("No Data");
                    return;
                }

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    richTextBoxDatas.AppendText(node.InnerText + Environment.NewLine);
                }

            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error getting all data names");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            if(textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No application specified");
                return;
            }

            if (textBoxNameContainer2.Text == "")
            {
                MessageBox.Show("No container specified");
                return;
            }

            if (textBoxNameData2.Text == "")
            {
                MessageBox.Show("No data specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}/data/{data}", Method.Get);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer2.Text);
            request.AddUrlSegment("data", textBoxNameData2.Text);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            int id, parent;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                
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
                        case "content":
                            textBoxContent.Text = node.InnerText;
                            break;
                    }
                }
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error getting " + textBoxNameContainer.Text + " information");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }
        }

        private void btnCreateData_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No app specified");
                return;
            }

            if (textBoxNameContainer2.Text == "")
            {
                MessageBox.Show("No container specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Post);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer2.Text);
            request.AddParameter("application/xml", createXmlDocument(textBoxName.Text, textBoxContent.Text).OuterXml, ParameterType.RequestBody);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                getAllDatas(textBoxNameApp2.Text, textBoxNameContainer2.Text);
                MessageBox.Show(xmlDoc.DocumentElement.InnerText);
                textBoxID.Clear();
                textBoxDTC.Clear();
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error creating " + textBoxName.Text + " data");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(textBoxID.Text == "" || textBoxDTC.Text == "" || textBoxParent.Text == "")
            {
                MessageBox.Show("No data loaded");
                return;
            }

            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("No app specified");
                return;
            }

            if (textBoxNameContainer2.Text == "")
            {
                MessageBox.Show("No container specified");
                return;
            }

            if (textBoxNameData2.Text == "")
            {
                MessageBox.Show("No Data name specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}/data/{data}", Method.Delete);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer2.Text);
            request.AddUrlSegment("data", textBoxNameData2.Text);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                getAllDatas(textBoxNameApp2.Text, textBoxNameContainer2.Text);
                MessageBox.Show(xmlDoc.DocumentElement.InnerText);
                clearTxtBoxes();
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error deleting " + textBoxName.Text + " data");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }
        }

        private XmlDocument createXmlDocument(string name, string content)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("DataOrSubscription");
            rootElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            rootElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/MiddlewareDatabaseAPI.Models");
            xmlDoc.AppendChild(rootElement);

            XmlElement contElement = xmlDoc.CreateElement("content");
            contElement.InnerText = content;
            rootElement.AppendChild(contElement);

            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = name;
            rootElement.AppendChild(nameElement);

            XmlElement resTypeElement = xmlDoc.CreateElement("res_type");
            resTypeElement.InnerText = "data";
            rootElement.AppendChild(resTypeElement);

            return xmlDoc;
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
            textBoxContent.Clear();
        }
    }
}

