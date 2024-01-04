﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MiddlewareDatabaseAPI.Controllers
{
    public abstract class SomiodController : ApiController
    {
        protected string connStr = Properties.Settings.Default.ConnStr;
        protected int GetAppId(string applicationName)
        {
            int id = 0;
            string queryApp = "SELECT id FROM Application WHERE name = @nameApplication";

            using (SqlConnection connection = new SqlConnection(connStr))
            {

                SqlCommand commandApp = new SqlCommand(queryApp, connection);
                commandApp.Parameters.AddWithValue("@nameApplication", applicationName);
                commandApp.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandApp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            id = (int)reader["id"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

            }

            return id;
        }

        protected bool UniqueName(string nameValue, string table)
        {
            List<string> listOfApplications = new List<string>();
            string helpQuerryString = "SELECT * FROM " + table;

            try
            {
                using (SqlConnection connection = new SqlConnection(connStr))
                {
                    SqlCommand command = new SqlCommand(helpQuerryString, connection);
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listOfApplications.Add((string)reader["name"]);
                        }
                    }
                }
            }
            catch (Exception)
            {
                InternalServerError();
            }

            foreach (string name in listOfApplications)
            {
                if (name == nameValue)
                    return false;
            }

            return true;
        }

        protected string NewName(string nameValue, string table)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz";

            char[] word = new char[4];

            bool flag = true;
            while (flag)
            {

                for (int i = 0; i < 4; i++)
                {
                    word[i] = chars[random.Next(chars.Length)];
                }

                flag = !UniqueName(new String(word), table);
            }
            return nameValue + "_" + new String(word);
        }

        protected int[] VerifyOwnership(string application, string container)
        {
            int idApp = 0, idContParent = 0, idCont = 0;
            string queryApp = "SELECT id FROM Application WHERE name = @nameApplication";
            string queryCont = "SELECT id, parent FROM Container WHERE name = @nameContainer";

            using (SqlConnection connection = new SqlConnection(connStr))
            {

                SqlCommand commandCont = new SqlCommand(queryCont, connection);
                commandCont.Parameters.AddWithValue("@nameContainer", container);
                commandCont.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandCont.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idContParent = (int)reader["parent"];
                            idCont = (int)reader["id"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }


                commandCont.Connection.Close();

                SqlCommand commandApp = new SqlCommand(queryApp, connection);
                commandApp.Parameters.AddWithValue("@nameApplication", application);
                commandApp.Connection.Open();

                try
                {
                    using (SqlDataReader reader = commandApp.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idApp = (int)reader["id"];
                        }
                    }
                }
                catch (Exception)
                {
                    InternalServerError();
                }

            }

            return new int[] { idApp, idContParent, idCont };
        }

    }
}