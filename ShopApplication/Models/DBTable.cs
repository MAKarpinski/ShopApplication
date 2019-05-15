using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ShopApplication.Models
{
    public enum Table
    {
        Customer, Product, Price
    }

    //klasa bazowa Tabeli
    public abstract class DBTable
    {
        public string name { get; set; }
        protected string creationStr { get; set; }
        protected string connString { get; set; }
        protected SqlConnection sqlConnection { get; set; }
        protected DBConnection dbConnection { get; set; }



        /// <summary>
        /// Function creates tabl    
        /// </summary>
        public abstract void Create();

        /// <summary>
        /// Function deletes table!!!        
        /// /// </summary>
        public virtual void DeleteTable()
        {
            //Connect to DB

            using (SqlConnection sqlConnection = new SqlConnection(dbConnection.connectionString))
            {

                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand("DROP TABLE " + name , sqlConnection))
                        sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    AppError.SaveError(ex.Message);
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }

                }
            }
        }

        /// <summary>
        /// Function adds object from table 
        /// </summary>
        public abstract void AddRecord();




        /// <summary>
        /// Function deletes object from table
        /// </summary>
        /// <param name="id">Id object to delete</param>
        public virtual void DeleteRecord(int id)
        {
            if (id != 0)
            {
                try
                {
                    SqlCommand sqlCommand = new SqlCommand("DELETE @table_name WHERE id=@id", sqlConnection);
                    sqlConnection.Open();
                    sqlCommand.Parameters.AddWithValue("@table_name", name);
                    sqlCommand.Parameters.AddWithValue("@id", id);
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    //MessageBox.Show("Record Deleted Successfully!");
                    //DisplayData;
                    //ClearData
                }
                catch(SqlException ex)
                {
                    AppError.SaveError(ex.Message);
                }
                catch(Exception ex)
                {
                    AppError.SaveError(ex.Message);
                }
                finally
                {
                    if (sqlConnection.State == ConnectionState.Open)
                    {
                        sqlConnection.Close();
                    }
                }

            }
            else
            {

                //MessageBox.Show("Please Select Record to Delete");
            }

        }

      
        //public void UpdateRecord();
    }
   
   
    

    //abstract class DBTableCreator
    //{
    //    public abstract DBTable CteateTable(string dbName);

    //}

    interface IDBTableCreator
    {
         DBTable CreateTable(Table tableName, DBConnection connection);
    }

    class TableCreator : IDBTableCreator
     {
        //public DBTable overide CteateTable(string dbName)
        //{
        //    return null;
        //}

        public DBTable CreateTable(Table tableName, DBConnection connection)
        {
            DBTable table = null;
            //DBConnection dBConnection = new DBConnection(connection.connectionString);

            switch (tableName)
            {
                //case Table.Customer:
                //    table = new DBTableCustomer();
                //    break;

                case Table.Product:
                    table = new DBProduct(connection);
                    break;

                //case Table.Price:
                //    table = new DBTablePrice();
                //    break;

                default: 
                    break;
            }

            return table;

        }
    }
}
