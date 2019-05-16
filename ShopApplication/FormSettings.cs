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
        //AppConfig appConfig;

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

            //appConfig = new AppConfig();

            //this.txbSerwer.Text = appConfig.connection.serverName.ToString();
            //this.txbBaza.Text = appConfig.connection.databaseName.ToString();
            //this.txbUzytkownik.Text = appConfig.connection.userName.ToString();
            //this.txbHaslo.Text = appConfig.connection.userPassword.ToString();
            this.txbSerwer.Text = mainForm.appConfig.connection.serverName;
            this.txbBaza.Text = mainForm.appConfig.connection.databaseName;
            this.txbUzytkownik.Text = mainForm.appConfig.connection.userName;
            this.txbHaslo.Text = mainForm.appConfig.connection.userPassword;
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
            //MainForm form = new MainForm(appConfig);
            //mainForm.gridViewManager.RefillData();
            //mainForm.Show();
            this.Close();
            //mainForm.Show();
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
                    //appConfig.connection = connection;
                    //appConfig.connectionOK = true;
                    this.mainForm.InitGridView(connection);
                }
                else
                {
                    MessageBox.Show("Test połączenia zakończył się niepowodzeniem!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Proszę wypełnić wszystkie dane połączenia");
            }
                //Test Connection

                //Save configuration data
            //    this.txbSerwer.Text = ConfigurationManager.AppSettings["SerwerName"];
            //this.txbBaza.Text = ConfigurationManager.AppSettings["DatabaseName"];
            //this.txbUzytkownik.Text = ConfigurationManager.AppSettings["UserName"];
            //this.txbHaslo.Text = ConfigurationManager.AppSettings["UserPassword"];

        }

        //private void CreateTable()
        //{
        //    DBConnection dbConn = new DBConnection(@"USER-KOMPUTER\SERWERSQL2012", "ShopDB5", "", "");
        //    DBTableTest.DBTestTableCreator testCreator = new DBTableTest.DBTestTableCreator();
        //    testCreator.CreateTest(Table.Product, dbConn);


        //}

        private bool CreateDB(string dbPath)
        {
            if (this.txbSerwer.Text != "" && this.txbBaza.Text != "" && this.txbUzytkownik.Text != "" && this.txbHaslo.Text != "" && txbDBPath.Text != "")
            {
                //Create Database 
                DBData.DBCreate dbCreate = new DBData.DBCreate(txbSerwer.Text, txbBaza.Text, txbUzytkownik.Text, txbHaslo.Text, dbPath);

                if (dbCreate.Create())
                {
                    MessageBox.Show("Baza Danych została utworzona");
                }
                else
                    MessageBox.Show("Nie udało się utworzyć Bazy Danych!");

                //New Connection          

                DBConnection connection = new DBConnection(this.txbSerwer.Text, this.txbBaza.Text, this.txbUzytkownik.Text, this.txbHaslo.Text);

                if (connection.TestConnection())
                {
                    //MessageBox.Show("Test połączenia przebiegł pozytywnie.\nDane zostaną zaktualizowane w pliklu konfiguracyjnym");
                    connection.SaveToConfigFile();
                    //appConfig.connection = connection;
                    //appConfig.connectionOK = true;

                    ///Create Tables
                    DBProduct productTable = new DBProduct(connection);
                    productTable.Create();
                    DBPrice priceTable = new DBPrice(connection);
                    priceTable.Create();

                    //Initialize Gridview on Main Form
                    this.mainForm.InitGridView(connection);

                    return true;
                }
                else
                {
                    MessageBox.Show("Test połączenia zakończył się niepowodzeniem!");
                }

            }
            else
            {
                MessageBox.Show("Proszę wypełnić wszystkie dane połączenia");
            }

            //Test Conn



            return false;


        }

        private void btnDBCreate_Click(object sender, EventArgs e)
        {
            if (CreateDB(@txbDBPath.Text))
            {
                MessageBox.Show("Baza Utworzona z powodzeniem");
            }

        }
    }
}
