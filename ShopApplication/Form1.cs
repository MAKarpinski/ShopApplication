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

namespace ShopApplication
{
    public partial class MainForm : Form
    {
        private BindingSource bindingSource1 = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            //InitApp();

        }

        public void InitApp()
        {
            //string connStr = @"Data Source=USER-KOMPUTER\SERWERSQL2012";
            //SqlConnection sqlConnection;
            string connetionString = @"Data Source=USER-KOMPUTER\SERWERSQL2012;Initial Catalog=ShopDB;User ID=sa;Password=P@ssw0rd";
            SqlConnection con = new SqlConnection(connetionString);

            try
            {

                con.Open();
                MessageBox.Show("Connection is Open!");
                //con.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }




            }

        private void InitializeDataGridView()
        {
            try
            {
                // Set up the DataGridView.
                dataGridView1.Dock = DockStyle.Fill;

                // Automatically generate the DataGridView columns.
                dataGridView1.AutoGenerateColumns = true;
                    

        // Set up the data source.
        bindingSource1.DataSource = GetData("Select * From Customers");
                dataGridView1.DataSource = bindingSource1;

                // Automatically resize the visible rows.
                dataGridView1.AutoSizeRowsMode =
                    DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

                // Set the DataGridView control's border.
                dataGridView1.BorderStyle = BorderStyle.Fixed3D;

                // Put the cells in edit mode when user enters them.
                dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this sample replace connection.ConnectionString" +
                    " with a valid connection string to a Northwind" +
                    " database accessible to your system.", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        private static DataTable GetData(string sqlCommand)
        {
            string connectionStr = @"Data Source=USER-KOMPUTER\SERWERSQL2012;Initial Catalog=ShopDB;User ID=sa;Password=P@ssw0rd";

            SqlConnection northwindConnection = new SqlConnection(connectionStr);

            SqlCommand command = new SqlCommand(sqlCommand, northwindConnection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            DataTable table = new DataTable();
            table.Locale = System.Globalization.CultureInfo.InvariantCulture;
            adapter.Fill(table);

            return table;
        }

        public void AddTable()
        {

            string connetionString = @"Data Source=USER-KOMPUTER\SERWERSQL2012;Initial Catalog=ShopDB;User ID=sa;Password=P@ssw0rd";
            //    SqlConnection con = new SqlConnection(connetionString);
            //    SqlCommand sqlCommand;
            //    SqlDataReader sqlDataReader;


            //    con.Open();
            //    MessageBox.Show("Connection is Open!");
            //    con.Close();
            //}
            //catch (SqlException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            using (SqlConnection con = new SqlConnection(connetionString))
            {

                try
                {
                    //
                    // Open the SqlConnection.
                    //
                    con.Open();
                    //
                    // The following code uses an SqlCommand based on the SqlConnection.
                    //
                    using (SqlCommand command = new SqlCommand(" If not exists (select name from sysobjects where name = 'Customer2')  CREATE TABLE Customer2(First_Name char(50),Last_Name char(50),Address char(50),City char(50),Country char(25),Birth_Date datetime);", con))
                        command.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }

                }
            }
        }

        private void btnDBConnect_Click(object sender, EventArgs e)
        {
            InitApp();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            AddTable();
        }
    }
}
