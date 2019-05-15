using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApplication.Models
{
    public class GridViewManager
    {


        public enum Column
        { Id, Nazwa, Ean, Cena, Podatek}

        public int selectedId = -1;

        BindingSource bindingSource;
        DataGridView dataGridView;
        DBConnection dbConnection;

        public GridViewManager()
        {
            bindingSource = new BindingSource();
            
        }

        /// <summary>
        /// Function Sets the specified DataGridView with Rows Frm Product Table with Price.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="dbConnection">Connection data</param>
        public void InitializeDataGridView(DataGridView dataGridView, DBConnection connection)
        {
            this.dataGridView = dataGridView;
            this.dbConnection = connection;

            try
            {
                // 
                //dataGridView.Dock = DockStyle.Fill;
                //BindingSource bindingSource;
                DBProduct productTable = new DBProduct(dbConnection);
                bindingSource.DataSource = productTable.GetData();
                dataGridView.DataSource = bindingSource;

                dataGridView.AutoGenerateColumns = true;
                if (dataGridView.ColumnCount > 0)
                {
                    dataGridView.Columns[0].ReadOnly = true;
                    dataGridView.Columns[3].Visible = false;
                }


                    dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                AppError.SaveError(" Rised by: InitializeDataGridView message: " + ex.Message);

                MessageBox.Show("" +
                    " Access to database faild!.", "ERROR: ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        public void RefillData()
        { 
            try
            {
                // 
                //dataGridView.Dock = DockStyle.Fill;
                //BindingSource bindingSource;
                DBProduct productTable = new DBProduct(dbConnection);
                bindingSource.DataSource = productTable.GetData();
                dataGridView.DataSource = bindingSource;

                dataGridView.AutoGenerateColumns = true;
                dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
                dataGridView.BorderStyle = BorderStyle.Fixed3D;
                dataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            }
            catch (Exception ex)
            {
                AppError.SaveError(" Rised by: InitializeDataGridView message: " + ex.Message);

                MessageBox.Show("" +
                    " Access to database faild!.", "ERROR: ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }

        public void InitializeDataGridViewByList(DataGridView dataGridView, DBConnection dbConnection)
        {
            this.dataGridView = dataGridView;

            try
            {
                List<Product> produkt = new List<Product>();
                dataGridView.DataSource = produkt.ToList();
              
            }
            catch (Exception ex)
            {
                AppError.SaveError(" Rised by: InitializeDataGridView message: " + ex.Message);

                MessageBox.Show("" +
                    " Access to database faild!.", "ERROR: ",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                System.Threading.Thread.CurrentThread.Abort();
            }
        }



        public void DeleteRow(int id)
        {
            DBProduct productTable = new DBProduct(dbConnection);
            productTable.DeleteRecord(id);
            //InitializeDataGridView(dataGridView, appConfig.connection);
            dataGridView.Refresh();
        }

        public void AddRow(string name, int ean, decimal net, int tax)
        {
            DBProduct productTable = new DBProduct(dbConnection);
            productTable.AddRecord(name, ean, net, tax);
            //InitializeDataGridView(dataGridView, appConfig.connection);
            dataGridView.Refresh();
        }

        public void UpdateRow(int id, string name, int ean, decimal net, int tax)
        {
            DBProduct productTable = new DBProduct(dbConnection);
            productTable.UpdateRecord( id, name, ean);
            DBPrice priceTable = new DBPrice(dbConnection);
            priceTable.UpdateRecord(id, net, tax);

            //InitializeDataGridView(dataGridView, appConfig.connection);
            dataGridView.Refresh();
        }

        //public void AddNewRow()
        //{
        //    int rowId = dataGridView.Rows.Add();

        //    DataGridViewRow row = dataGridView1.Rows[rowId];

        //    // Add the data
        //    row.Cells["Column1"].Value = "Value1";
        //    row.Cells["Column2"].Value = "Value2";

        //}

    }

    public class DataGridViewProductRow
    {
        int Id;
        string Nazwa;
        int Ean;
        decimal Cena;
        int Podatek;
    }

}

