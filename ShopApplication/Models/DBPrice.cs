using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    //class DBPrice
    //{
        class DBPrice : DBTable
        {
            //        Table 2 Columns(Price) :
            //Id           as int notnull,
            //Net        as decimal (5,2) default 0.00
            //Tax        as integer default 23

            /// <summary>
            /// DBPrice Vontruction
            /// </summary>
            /// <param name="connection">Connection data to DB</param>
            public DBPrice(DBConnection connection)
            {
                //dBConnection = config;
                //sqlConnection = connection;
                dbConnection = connection;
                name = "Price";

                //If not exists(SELECT name FROM sysobjects WHERE name = 'PriceTest5')  CREATE TABLE PriceTest5(Id INT NOT NULL, Net decimal(10, 2) DEFAULT(0.00), tax INT DEFAULT(23));
                creationStr = " If not exists(SELECT name FROM sysobjects WHERE name = '" + name + "')  CREATE TABLE " + name +
                    "(Id INT NOT NULL, Net decimal(10, 2) DEFAULT(0.00), tax INT DEFAULT(23)); ";



                //TODO: Change to StringBuilder!



            }

        /// <summary>
        /// Function creates Price table in DB
        /// </summary>
            public override void Create()
            {
                using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand(creationStr, sqlConnection))
                            command.ExecuteNonQuery();
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
            /// Function Sets Default Price values 
            /// </summary>
            /// <param name="id"></param>
            public void AddRecord(int id)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (name != "")
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Price(id) VALUES (" + id + ") ", sqlConnection);
                            sqlConnection.Open();

                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Record Updated Successfully");
                            sqlConnection.Close();
                        }
                        else
                        {
                            //MessageBox.Show("Please Select Record to Update");
                        }
                    }
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

        /// <summary>
        /// Function adds data into Price table
        /// </summary>
        /// <param name="id"></param>
        /// <param name="net"></param>
        /// <param name="tax"></param>
            public void AddRecord(int id, decimal net, int tax)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (id > 0)
                        {


                            SqlCommand cmd = new SqlCommand("INSERT INTO Price(id, Net, Tax) VALUES (" + id + ", " + net + ", " + tax + ") ", sqlConnection);
                            sqlConnection.Open();

                            cmd.ExecuteNonQuery();
                            //MessageBox.Show("Record Inserted Successfully");
                            sqlConnection.Close();
                        }
                        else
                        {
                        }
                    }
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



            public void AddRecord(Price price)
            {
                AddRecord(price.id, price.net, price.tax);
            }

            /// <summary>
            ///  Function Updates data in Price table
            /// </summary>
            /// <param name="id"></param>
            /// <param name="net"></param>
            /// <param name="tax"></param>
            public void UpdateRecord(int id, decimal net, int tax)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (id > 0)
                        {

                            SqlCommand sqlCommand = new SqlCommand("UPDATE Price SET Net=@net, tax=@tax WHERE id=@id", sqlConnection);
                            sqlConnection.Open();
                            sqlCommand.Parameters.AddWithValue("@id", id);
                            sqlCommand.Parameters.AddWithValue("@net", net);
                            sqlCommand.Parameters.AddWithValue("@tax", tax);
                            sqlCommand.ExecuteNonQuery();
                            //MessageBox.Show("Product Record Updated");
                            sqlConnection.Close();
                        }
                        else
                        {
                            //MessageBox.Show("Parametr id, net nie może być pusty");
                            //TODO: check id, net, tax
                        }
                    }
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

            public void UpdateRecord(Price price)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (price.id > 0)
                        {

                            SqlCommand sqlCommand = new SqlCommand("UPDATE Price SET Net=@net, tax=@tax WHERE id=@id", sqlConnection);
                            sqlConnection.Open();
                            sqlCommand.Parameters.AddWithValue("@id", price.id);
                            sqlCommand.Parameters.AddWithValue("@net", price.net);
                            sqlCommand.Parameters.AddWithValue("@tax", price.tax);
                            sqlCommand.ExecuteNonQuery();
                            //MessageBox.Show("Product Record Updated");
                            sqlConnection.Close();
                        }
                        else
                        {
                            //MessageBox.Show("Parametr id, net nie może być pusty");
                            //TODO: check id, net, tax
                        }
                    }
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

            public override void AddRecord()
            {
                throw new NotImplementedException();
            }
        }

//    }
}
