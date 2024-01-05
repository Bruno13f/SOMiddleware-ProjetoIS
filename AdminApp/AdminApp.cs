using RestSharp;
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

namespace AdminApp
{
    public partial class AdminApp : Form
    {
        string baseURI = @"http://localhost:50591";
        RestClient client = null;
        public AdminApp()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
            createLibrary();
        }

        private void createLibrary()
        {
            var request = new RestRequest("/api/somiod", Method.Post);
            request.AddParameter("application/xml", createXmlDocument("LibraryAdmin").OuterXml, ParameterType.RequestBody);

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
            var mainRequest = new RestRequest("/api/somiod/LibraryAdmin", Method.Get);
            mainRequest.RequestFormat = DataFormat.Xml;
            mainRequest.AddHeader("somiod-discover", "container");
            mainRequest.AddHeader("Accept", "application/xml");

            var mainResponse = client.Execute(mainRequest);

            if (mainResponse.IsSuccessful)
            {
                XmlDocument mainXmlDoc = new XmlDocument();
                mainXmlDoc.LoadXml(mainResponse.Content);

                if (mainXmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxOpenOffices.AppendText("No Containers");
                    richTextBoxOccupiedOffices.AppendText("No Containers");
                    return;
                }

                foreach (XmlNode containerNode in mainXmlDoc.DocumentElement.ChildNodes)
                {
                    var contname = containerNode.InnerText;

                    var containerRequest = new RestRequest("/api/somiod/LibraryAdmin/{container}", Method.Get);
                    containerRequest.AddUrlSegment("container", contname);
                    containerRequest.RequestFormat = DataFormat.Xml;
                    containerRequest.AddHeader("somiod-discover", "data");
                    containerRequest.AddHeader("Accept", "application/xml");

                    var containerResponse = client.Execute(containerRequest);

                    if (containerResponse.IsSuccessful)
                    {
                        XmlDocument containerXmlDoc = new XmlDocument();
                        containerXmlDoc.LoadXml(containerResponse.Content);

                        if (containerXmlDoc.DocumentElement.ChildNodes.Count == 0)
                        {
                            richTextBoxOpenOffices.AppendText(contname + Environment.NewLine);
                        }
                        else
                        {
                            richTextBoxOccupiedOffices.AppendText(contname + Environment.NewLine);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error getting data for container {contname}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error getting open offices");
            }
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxCreateNameOffice.Text == "")
            {
                MessageBox.Show("Office name not specified");
                return;
            }

            var request = new RestRequest("/api/somiod/LibraryAdmin", Method.Post);
            request.AddParameter("application/xml", createXmlDocument(textBoxCreateNameOffice.Text).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                getAllOffices();
                MessageBox.Show(response.Content.ToString());
                textBoxCreateNameOffice.Clear();
            }
            else
            {
                MessageBox.Show("Error creating " + textBoxCreateNameOffice.Text + " container");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonVacantOffice_Click(object sender, EventArgs e)
        {

        }

        private XmlDocument createXmlDocument(string name)
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
    }
}
