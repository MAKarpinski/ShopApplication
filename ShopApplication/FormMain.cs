using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ShopApplication.Models;

namespace ShopApplication
{
    public partial class MainForm : Form
    {
        public AppConfig appConfig;
        public GridViewManager gridViewManager;

        public MainForm(AppConfig config = null)
        {
            InitializeComponent();

            if (config == null)
                appConfig = new AppConfig();
            else
                appConfig = config;

            gridViewManager = new GridViewManager();


            //CreateProductAddingWithPriceTest();
            //ErrorTest();
            //CreateDBTest();
            //CreateTableTest();
            //


        }

        private void InitApplication()
        {

            if (!appConfig.connectionOK)
            {
                FormSettings settingsForm = new FormSettings(this);
                this.Close();
                settingsForm.ShowDialog();
            }

            gridViewManager.InitializeDataGridView(this.dataGridView1, appConfig.connection);
        }



        private void CreateTableTest()
        {
            DBConnection dbConn = new DBConnection(@"USER-KOMPUTER\SERWERSQL2012", "ShopDB5", "sa", "P@ssw0rd");
            DBTableTest.DBTestTableCreator testCreator = new DBTableTest.DBTestTableCreator();
            testCreator.CreateTest(Table.Product, dbConn);


        }

        private void CreateDBTest()
        {
            DBData.DBCreate dbCreate = new DBData.DBCreate(@"USER-KOMPUTER\SERWERSQL2012", "ShopDB8", "sa", "P@ssw0rd", "C:\\Projekty");

            if (dbCreate.Create())
            {
                MessageBox.Show("Baza Danych została utworzona");
            }
            else
                MessageBox.Show("Nie udało się utworzyć Bazy Danych!");

        }

        private void ErrorTest()
        {
            AppError.SaveError("Error test");
  
        }

        private void ConnectionTest()
        {


            DBConnection dbConn = new DBConnection(@"USER-KOMPUTER\SERWERSQL2012", "ShopDB", "sa", "P@ssw0rd");
            if (dbConn.TestConnection())
            {
                MessageBox.Show("Połaczenie z Bazą Danych jest OK");
            }
            else
                MessageBox.Show("Nie udało sie nawiązać połaczenie z Bazą Danych!");

            // DBTableTest test = new DBTableTest();
            //DBTableTest.DBTestCreator testCreator = new DBTableTest.DBTestCreator();
            //testCreator.CreateTest(Table.Product, dbConn);

        }

        private void CreateProductAddingWithPriceTest()
        {
            DBConnection dbConn = new DBConnection(@"USER-KOMPUTER\SERWERSQL2012", "ShopDB", "sa", "P@ssw0rd");
            DBTableTest.DBTestTableCreator testCreator = new DBTableTest.DBTestTableCreator();
            testCreator.AddingRecordTest(Table.Product, DBTableTest.Test.ProduktCena, dbConn);
        }


        private void btnDBConnect_Click(object sender, EventArgs e)
        {
            //InitAppTest();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            //AddTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitApplication();

            
        }

        private void btnChangeSettings_Click(object sender, EventArgs e)
        {
            FormSettings settingsForm = new FormSettings(this);
            settingsForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteRow_Click(object sender, EventArgs e)
        {

            int selectedId = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.gridViewManager.DeleteRow(selectedId);
            this.gridViewManager.RefillData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string selectedId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txbId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txbName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txbEan.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txbVal.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txbTax.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

            if (selectedId != "")
            {
                btnAddRow.Enabled = false;
                btnDeleteRow.Enabled = true;
                btnEditRow.Enabled = true;
            }
            else
            {
                btnAddRow.Enabled = true;
                btnDeleteRow.Enabled = false;
                btnEditRow.Enabled = false;
            }

        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            //TODO Check data
            this.gridViewManager.AddRow(txbName.Text, Int32.Parse(txbEan.Text), Convert.ToDecimal(txbVal.Text), Int32.Parse(txbTax.Text)) ;
            this.gridViewManager.RefillData();
        }

        private void btnEditRow_Click(object sender, EventArgs e)
        {
            //TODO Check data
            int selectedId = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            this.gridViewManager.UpdateRow(selectedId, txbName.Text, Int32.Parse(txbEan.Text), Convert.ToDecimal(txbVal.Text), Int32.Parse(txbTax.Text));
            this.gridViewManager.RefillData();
            
        }
    }
}
