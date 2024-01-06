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

namespace TestSubscription
{
    public partial class SubscriptionTester : Form
    {
        string baseURI = @"http://localhost:50591";
        RestClient client = null;
        public SubscriptionTester()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
        }

        private void btnGetAllSubscriptions_Click(object sender, EventArgs e)
        {
            getAllSubscriptions(textBoxNameApp.Text, textBoxContainer.Text);
        }

        private void getAllSubscriptions (string application, string container)
        {
            textBoxNameApp.Text = application;
            textBoxContainer.Text = container;

            if (application == "")
            {
                MessageBox.Show("Applicationnot specified");
                return;
            }

            if (container == "")
            {
                MessageBox.Show("Container not specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Get);
            request.AddUrlSegment("application", application);
            request.AddUrlSegment("container", container);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "subscription");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                richTextBoxSubscriptions.Clear();

                if (xmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxSubscriptions.AppendText("No Subscriptions");
                    return;
                }

                foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
                {
                    richTextBoxSubscriptions.AppendText(node.InnerText + Environment.NewLine);
                }
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error getting all subscriptions from " + container);
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }
        }

        private void btnGetContainer_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("Application not specified");
                return;
            }

            if (textBoxNameContainer.Text == "")
            {
                MessageBox.Show("Container not specified");
                return;
            }

            if(textBoxNameSubscription.Text == "")
            {
                MessageBox.Show("Subscription not specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}/subscription/{sub}", Method.Get);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer.Text);
            request.AddUrlSegment("sub", textBoxNameSubscription.Text);
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
                        case "event_mqqt":
                            if (node.InnerText == "1")
                                textBoxEvent.Text = "Creation";
                            if (node.InnerText == "2")
                                textBoxEvent.Text = "Deletion";
                            break;
                        case "endpoint":
                            textBoxEndpoint.Text = node.InnerText;
                            break;
                    }
                }
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error getting subcription " + textBoxNameSubscription.Text + " info");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "")
            {
                MessageBox.Show("Application not specified");
                return;
            }

            if (textBoxNameContainer.Text == "")
            {
                MessageBox.Show("Container not specified");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("Name not specified");
                return;
            }

            if (textBoxEndpoint.Text == "")
            {
                MessageBox.Show("Endpoint not specified");
                return;
            }

            if (textBoxEvent.Text != "Creation" && textBoxEvent.Text != "Disposal")
            {
                MessageBox.Show("Event is wrong - must be 'Creation' or 'Disposal'");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Post);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer.Text);
            String xml = createXmlDocument(textBoxName.Text, textBoxEndpoint.Text, textBoxEvent.Text).OuterXml;
            request.AddParameter("application/xml", xml, ParameterType.RequestBody);
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                getAllSubscriptions(textBoxNameApp2.Text, textBoxNameContainer.Text);
                MessageBox.Show(xmlDoc.DocumentElement.InnerText);
                clearTxtBoxes();
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error creating subcription " + textBoxName.Text);
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == "" && textBoxNameContainer.Text == "" && textBoxNameSubscription.Text == "" && textBoxID.Text == "" &&
                textBoxDTC.Text == "" && textBoxParent.Text == "" && textBoxEvent.Text == "" && textBoxEndpoint.Text == "")
            {
                MessageBox.Show("No subscription loaded");
                return;
            }

            if (textBoxName.Text == "")
            {
                MessageBox.Show("No name specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}/subscription/{subscription}", Method.Delete);
            request.AddUrlSegment("application", textBoxNameApp2.Text);
            request.AddUrlSegment("container", textBoxNameContainer.Text);
            request.AddUrlSegment("subscription", textBoxNameSubscription.Text);
            request.AddHeader("Content-type", "application/xml");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response.Content);

            if (response.IsSuccessful)
            {
                getAllSubscriptions(textBoxNameApp2.Text, textBoxContainer.Text);
                MessageBox.Show(xmlDoc.DocumentElement.InnerText);
                clearTxtBoxes();
            }
            else
            {
                if (xmlDoc.DocumentElement.InnerText == "" || xmlDoc.DocumentElement.InnerText == null)
                    MessageBox.Show("Error deliting " + textBoxNameSubscription.Text + " subscription");
                else
                    MessageBox.Show(xmlDoc.DocumentElement.InnerText);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearTxtBoxes();
        }

        private void clearTxtBoxes() {
            textBoxID.Clear();
            textBoxDTC.Clear();
            textBoxName.Clear();
            textBoxParent.Clear();
            textBoxEvent.Clear();
            textBoxEndpoint.Clear();
            textBoxNameApp2.Clear();
            textBoxNameContainer.Clear();
            textBoxNameSubscription.Clear(); 
        }

        private XmlDocument createXmlDocument(string name, string endpoint, string event_mqtt)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("DataOrSubscription");
            rootElement.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            rootElement.SetAttribute("xmlns", "http://schemas.datacontract.org/2004/07/MiddlewareDatabaseAPI.Models");
            xmlDoc.AppendChild(rootElement);
            XmlElement endpointElement = xmlDoc.CreateElement("endpoint");
            endpointElement.InnerText = endpoint;
            rootElement.AppendChild(endpointElement);
            XmlElement eventElement = xmlDoc.CreateElement("event_mqtt");
            if (event_mqtt == "Creation")
                eventElement.InnerText = "1";
            else
                eventElement.InnerText = "2";
            rootElement.AppendChild(eventElement);
            XmlElement nameElement = xmlDoc.CreateElement("name");
            nameElement.InnerText = name;
            rootElement.AppendChild(nameElement);
            XmlElement resTypeElement = xmlDoc.CreateElement("res_type");
            resTypeElement.InnerText = "subscription";
            rootElement.AppendChild(resTypeElement);

            Console.WriteLine(xmlDoc.OuterXml);

            return xmlDoc;
        }
    }
}
