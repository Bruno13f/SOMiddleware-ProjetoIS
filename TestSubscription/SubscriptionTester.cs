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

        private void btnGetAllContainers_Click(object sender, EventArgs e)
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

            if (response.IsSuccessful)
            {
                richTextBoxSubscriptions.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

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
                MessageBox.Show("Error getting all subscriptions from " + container);
            }
        }

        private void btnGetContainer_Click(object sender, EventArgs e)
        {
            if (textBoxNameApp2.Text == null)
            {
                MessageBox.Show("Application not specified");
                return;
            }

            if (textBoxNameContainer.Text == null)
            {
                MessageBox.Show("Container not specified");
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
                        case "event":

                            break;
                        case "endpoint":
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error getting subcription " + textBoxNameSubscription.Text + " info");
            }

        }
    }
}
