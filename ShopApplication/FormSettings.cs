using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ShopApplication.Models;

namespace ShopApplication
{
    public partial class FormSettings : Form
    {
        MainForm mainForm;
        AppConfig appConfig;

        public FormSettings(MainForm parentForm)
        {
            mainForm = parentForm;

            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            //    < add key = "SerwerName" value = "" />
            //    < add key = "DatabaseName" value = "" />
            //    < add key = "UserName" value = "" />
            //    < add key = "UserPassword" value = "" />

            //mainForm.appConfig = new AppConfig();
            appConfig = new AppConfig();

            this.txbSerwer.Text = appConfig.connection.serverName;
            this.txbBaza.Text = appConfig.connection.databaseName;
            this.txbUzytkownik.Text = appConfig.connection.userName;
            this.txbHaslo.Text = appConfig.connection.userPassword;
            //this.txbSerwer.Text = mainForm.appConfig.connection.serverName;
            //this.txbBaza.Text = mainForm.appConfig.connection.databaseName;
            //this.txbUzytkownik.Text = mainForm.appConfig.connection.userName;
            //this.txbHaslo.Text = mainForm.appConfig.connection.userPassword;
            //this.txbSerwer.Text = ConfigurationManager.AppSettings["SerwerName"];
            //this.txbBaza.Text = ConfigurationManager.AppSettings["DatabaseName"];
            //this.txbUzytkownik.Text = ConfigurationManager.AppSettings["UserName"];
            //this.txbHaslo.Text = ConfigurationManager.AppSettings["UserPassword"];

        }

        private void FormSettings_Load(object sender, EventArgs e)
        {


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            MainForm form = new MainForm(appConfig);
            form.gridViewManager.RefillData();
            //mainForm.Show();
            this.Close();
            mainForm.Show();
            //MainForm mainForm = new MainForm();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txbSerwer.Text != "" && this.txbBaza.Text != "" && this.txbUzytkownik.Text != "" && this.txbHaslo.Text != "")
            {

                DBConnection connection = new DBConnection(this.txbSerwer.Text, this.txbBaza.Text, this.txbUzytkownik.Text, this.txbHaslo.Text);

                if (connection.TestConnection())
                {
                    MessageBox.Show("Test połączenia przebiegł pozytywnie.\nDane zostaną zaktualizowane w pliklu konfiguracyjnym");
                    connection.SaveToConfigFile();
                    appConfig.connection = connection;
                    appConfig.connectionOK = true;
                    //this.mainForm.appConfig.connection = connection;
                    //this.mainForm.appConfig.connectionOK = true;
                    //this.mainForm.gridViewManager.RefillData();

                }
                else
                {
                    MessageBox.Show("Test połączenia zakończył się niepowodzeniem!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Proszę wypełnic wszystkie dane połączenia");
            }
                //Test Connection

                //Save configuration data
            //    this.txbSerwer.Text = ConfigurationManager.AppSettings["SerwerName"];
            //this.txbBaza.Text = ConfigurationManager.AppSettings["DatabaseName"];
            //this.txbUzytkownik.Text = ConfigurationManager.AppSettings["UserName"];
            //this.txbHaslo.Text = ConfigurationManager.AppSettings["UserPassword"];

        }
    }
}
