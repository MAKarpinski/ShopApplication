using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ShopApplication.Models
{
    //    <add key = "SerwerName" value="USER-KOMPUTER\SERWERSQL2012"/>
    //<add key = "DatabaseName" value="ShopDB"/>
    //<add key = "UserName" value="sa"/>
    //<add key = "UserPassword" value="P@ssw0rd"/>

    public enum Setting
    {
        SerwerName, DatabaseName, UserName, UserPassword
    }

    public class DBConnection
    {
        public string serverName { get; set; }
        public string databaseName;
        public string userName { get; set; }
        public string userPassword { get; set; }

        public string connectionString { get; }


        /// <summary>
        /// DBConnection obj Constructor
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <param name="userName"></param>
        /// <param name="userPassword"></param>
        public DBConnection(string serverName, string databaseName, string userName, string userPassword)
        {
            this.serverName = serverName;
            this.databaseName = databaseName;
            this.userName = userName;
            this.userPassword = userPassword;

            connectionString = @"Data Source = " + serverName + "; Initial Catalog = " + databaseName + "; User ID = " + userName + "; Password = " + userPassword + ";";
        }

        /// <summary>
        /// Function Tests Connection to DB
        /// </summary>
        /// <returns></returns>
        public bool TestConnection()
        {
            try
            { 
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                connection.Close();

                return true;
            }
            catch (SqlException ex)
            {
                AppError.SaveError(ex.Message);

                return false;
            }

        }

        /// <summary>
        /// Function Saves data from form in Config file
        /// </summary>
        /// <returns></returns>
        public bool SaveToConfigFile()
        {

            if (this.serverName != "" && this.databaseName != "" && this.userName != "" && this.userPassword != "")
            {
                try
                {
                    var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    var settings = configFile.AppSettings.Settings;


                    settings[Setting.SerwerName.ToString()].Value = this.serverName;
                    settings[Setting.DatabaseName.ToString()].Value = this.databaseName;
                    settings[Setting.UserName.ToString()].Value = this.userName;
                    settings[Setting.UserPassword.ToString()].Value = this.userPassword;
                    //settings.Add(Setting.SerwerName.ToString(), this.serverName);
                    //settings.Add(Setting.DatabaseName.ToString(), this.databaseName);
                    //settings.Add(Setting.UserName.ToString(), this.userName);
                    //settings.Add(Setting.UserPassword.ToString(), this.userPassword);

                    configFile.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
                }
                catch (ConfigurationErrorsException)
                {
                    AppError.SaveError("Bład Zapisu danych konfiguracyjnych!");
                }

                return true;
            }
            else
                AppError.SaveError("Proszę wypełnić wszystkie dane połączenia!");

            return false;

        }
    }
}
