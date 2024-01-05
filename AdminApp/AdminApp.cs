﻿using RestSharp;
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
        string app = "LibraryAdmin";
        RestClient client = null;
        public AdminApp()
        {
            InitializeComponent();
            client = new RestClient(baseURI);
            createLibrary();
            getAllOffices();
            this.FormClosing += ClientApp_FormClosing;
        }

        private void ClientApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            var request = new RestRequest("/api/somiod/{application}", Method.Delete);
            request.AddUrlSegment("application", app);

            client.Execute(request);
        }

        private void createLibrary()
        {
            var request = new RestRequest("/api/somiod", Method.Post);
            request.AddParameter("application/xml", createXmlDocument("LibraryAdmin", true).OuterXml, ParameterType.RequestBody);

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
            var mainRequest = new RestRequest("/api/somiod/{application}", Method.Get);
            mainRequest.AddUrlSegment("application", app);
            mainRequest.RequestFormat = DataFormat.Xml;
            mainRequest.AddHeader("somiod-discover", "container");
            mainRequest.AddHeader("Accept", "application/xml");

            var mainResponse = client.Execute(mainRequest);

            if (mainResponse.IsSuccessful)
            {
                XmlDocument mainXmlDoc = new XmlDocument();
                mainXmlDoc.LoadXml(mainResponse.Content);

                richTextBoxOpenOffices.Clear();
                richTextBoxOccupiedOffices.Clear();

                if (mainXmlDoc.DocumentElement.ChildNodes.Count == 0)
                {
                    richTextBoxOpenOffices.AppendText("No Open Offices");
                    richTextBoxOccupiedOffices.AppendText("No Occupied Offices");
                    return;
                }

                foreach (XmlNode containerNode in mainXmlDoc.DocumentElement.ChildNodes)
                {
                    var containerRequest = new RestRequest("/api/somiod/{application}/{container}", Method.Get);
                    containerRequest.AddUrlSegment("application", app);
                    containerRequest.AddUrlSegment("container", containerNode.InnerText);
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
                            richTextBoxOpenOffices.AppendText(containerNode.InnerText + Environment.NewLine);
                        }
                        else
                        {
                            richTextBoxOccupiedOffices.AppendText(containerNode.InnerText + Environment.NewLine);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Error getting data for container {containerNode.InnerText}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Error getting Offices");
            }
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (textBoxCreateNameOffice.Text == "")
            {
                MessageBox.Show("Office name not specified");
                return;
            }

            var request = new RestRequest("/api/somiod/{application}", Method.Post);
            request.AddUrlSegment("application", app);
            request.AddParameter("application/xml", createXmlDocument(textBoxCreateNameOffice.Text, false).OuterXml, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.IsSuccessful)
            {
                getAllOffices();
                MessageBox.Show("Created Office " + textBoxCreateNameOffice.Text);
                textBoxCreateNameOffice.Clear();
            }
            else
            {
                MessageBox.Show("Error creating " + textBoxCreateNameOffice.Text + " office");
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

        }

        private void buttonVacantOffice_Click(object sender, EventArgs e)
        {

        }

        private XmlDocument createXmlDocument(string name, bool flag)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = flag ? xmlDoc.CreateElement("Application") : xmlDoc.CreateElement("Container");
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
