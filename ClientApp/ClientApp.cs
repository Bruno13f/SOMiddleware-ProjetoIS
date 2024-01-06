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
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace ClientApp
{
    public partial class ClientApp : Form
    {
        MqttClient mClient = new MqttClient("127.0.0.1");
        string[] topic = { "updateOffices" };
        string baseURI = @"http://localhost:50591";
        string app = "LibraryApp";
        string appAdmin = "LibraryAdmin";
        RestClient client = null;
        public ClientApp()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
            createLibrary();
            getAllOffices();
            this.FormClosing += ClientApp_FormClosing;

            mClient.Connect(Guid.NewGuid().ToString());
            if (!mClient.IsConnected)
            {
                Console.WriteLine("Failed to connect to mqtt");
            }
            else
            {
                mClient.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
                
                byte[] qosLevels = { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE };
                mClient.Subscribe(topic, qosLevels);
            }
        }

        private void ClientApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            var request = new RestRequest("/api/somiod/{application}", Method.Delete);
            request.AddUrlSegment("application", app);

            client.Execute(request);

            if (mClient.IsConnected)
            {
                mClient.Unsubscribe(topic);
                mClient.Disconnect();
            }
        }

        private void Client_MqttMsgPublishReceived(object sender, uPLibrary.Networking.M2Mqtt.Messages.MqttMsgPublishEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate () {
                string message = Encoding.UTF8.GetString(e.Message);
                MessageBox.Show(message);
                getAllOffices();
            });
        }

        private void createLibrary()
        {
            var requestVerify = new RestRequest("/api/somiod/{application}", Method.Get);
            requestVerify.AddUrlSegment("application", app);
            requestVerify.RequestFormat = DataFormat.Xml;
            requestVerify.AddHeader("Accept", "application/xml");

            var responseVerify = client.Execute(requestVerify);

            if (!responseVerify.IsSuccessful)
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
        }

        private void getAllOffices()
        {
            var request = new RestRequest("/api/somiod/{application}", Method.Get);
            request.AddUrlSegment("application", appAdmin);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "container");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                richTextBoxOffices.Clear();
                comboBoxOffices.Items.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

                if (xmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxOffices.AppendText("No Offices");
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

            if (VerifyIfReserved(comboBoxOffices.SelectedItem.ToString()))
            {
                MessageBox.Show("Office already reserved");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Post);
            request.AddUrlSegment("application", appAdmin);
            request.AddUrlSegment("container", comboBoxOffices.SelectedItem.ToString());
            request.AddParameter("application/xml", createXmlDocumentData(textBoxName.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            string container = comboBoxOffices.SelectedItem.ToString();

            if (response.IsSuccessful)
            {
                MessageBox.Show(comboBoxOffices.SelectedItem.ToString() + " reserved");
                getAllOffices();
            }
            else
            {
                MessageBox.Show("Error creating " + textBoxName.Text + " data");
            }

        }

        private bool VerifyIfReserved (string container)
        {
            var request = new RestRequest("/api/somiod/{application}/{container}", Method.Get);
            request.AddUrlSegment("application", appAdmin);
            request.AddUrlSegment("container", container);
            request.RequestFormat = DataFormat.Xml;
            request.AddHeader("somiod-discover", "data");
            request.AddHeader("Accept", "application/xml");

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response.Content);

                if (xmlDoc.DocumentElement.ChildNodes.Count != 0)
                {
                    return true;
                }

            }

            return false;
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
            contElement.InnerText = "Reserved";
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
