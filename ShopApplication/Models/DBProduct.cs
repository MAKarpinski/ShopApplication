using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    //class DBProduct
    //{
        class DBProduct : DBTable
        {
            /// <summary>
            /// DBProduct Constructor
            /// </summary>
            /// <param name="connection">Connection data to DB</param>
            public DBProduct(DBConnection connection)
            {
                //Initialization
                //dBConnection = config;
                //sqlConnection = connection;
                dbConnection = connection;
                name = "Product";

                //        Table 1 Columns(Product) :
                //Id           as int notnull, primarykey
                //name    as varchar(20) not null
                //ean       as numeric not null, unique

                creationStr = " If not exists(SELECT name FROM sysobjects WHERE name = '" + name + "')  CREATE TABLE " + name +
                    "(Id INT NOT NULL PRIMARY KEY IDENTITY(1, 1), name Varchar(20) NOT NULL, ean NUMERIC (10) NOT NULL UNIQUE); ";
            }

        /// <summary>
        /// Function creates Product table in DB
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
            /// Function add record to Product table with default values 
            /// </summary>
            public override void AddRecord()
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (name != "")
                        {

                            //Check if unique ean exist?
                            //INSERT INTO table_name VALUES(value1, value2, value3, ...);
                            SqlCommand cmd = new SqlCommand("INSERT INTO Product(name, ean) VALUES ('Produkt', 23) ", sqlConnection);
                            sqlConnection.Open();

                            cmd.ExecuteNonQuery();
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
            /// Function add record to Product table
            /// </summary>
            /// <param name="productName">Product name</param>
            /// <param name="ean">Produc ean</param>
            public void AddRecord(string name, int ean)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        SqlCommand sqlCommand = new SqlCommand("INSERT INTO Product(name, ean) VALUES (@name, @ean) ", sqlConnection);

                        sqlConnection.Open();
                        //sqlCommand.Parameters.AddWithValue("@id", ID); auto inc
                        sqlCommand.Parameters.AddWithValue("@name", name);
                        sqlCommand.Parameters.AddWithValue("@ean", ean);
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
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

            public void AddRecord(Product product)
            {
                AddRecord(product.name, product.ean);
            }



        /// <summary>
        /// Function add record to Product and Product Price table
        /// </summary>
        /// <param name="name">Product name</param>
        /// <param name="ean">Produc ean</param>
        /// <param name="name">Price net</param>
        /// <param name="ean">Price tax</param>
        public void AddRecord(string name, int ean, decimal net, int tax)
        {
            try
            {
                //using (SqlConnection connection = new SqlConnection(dbConnection.connectionString))
                using (sqlConnection = new SqlConnection(dbConnection.connectionString)) 
                {
                    SqlCommand sqlCommand = new SqlCommand("INSERT INTO Product(name, ean) VALUES (@name, @ean); SELECT SCOPE_IDENTITY(); ", sqlConnection);

                    //sqlCommand.Parameters.AddWithValue("@id", ID); auto inc
                    sqlCommand.Parameters.AddWithValue("@name", name);
                    sqlCommand.Parameters.AddWithValue("@ean", ean);
                    sqlConnection.Open();
                    //sqlCommand.ExecuteNonQuery();

                    //string sqlQuery = "Select SCOPE_IDENTITY()";
                    //sqlCommand.CommandText = sqlQuery;
                    sqlCommand.CommandType = CommandType.Text;
                    var productId = sqlCommand.ExecuteScalar();

                    if (productId != null)
                    {
                        sqlCommand = new SqlCommand("INSERT INTO Price(id, net, tax) VALUES (@id, @net, @tax) ", sqlConnection);
                        //connection.Open();
                        sqlCommand.Parameters.AddWithValue("@id", productId.ToString());
                        sqlCommand.Parameters.AddWithValue("@net", net);
                        sqlCommand.Parameters.AddWithValue("@tax", tax);
                        sqlCommand.ExecuteNonQuery();
                    }

                    sqlConnection.Close();
           
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
        /// Function Update Product Data 
        /// </summary>
        /// <param name="id">Id product to update</param>
        /// <param name="name">New Name od poroduct</param>
        /// <param name="ean">New ean</param>
        public void UpdateRecord(int id, string name, int ean)
            {
                try
                {
                    using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                    {
                        if (name == "" || ean < 0)
                        {

                            SqlCommand sqlCommand = new SqlCommand("UPDATE Product SET name=@name, ean=@ean WHERE ID=@id", sqlConnection);
                            sqlConnection.Open();
                            //cmd.Parameters.AddWithValue("@id", ID); auto inc
                            sqlCommand.Parameters.AddWithValue("@name", name);
                            sqlCommand.Parameters.AddWithValue("@ean", ean);
                            sqlCommand.ExecuteNonQuery();
                            //MessageBox.Show("Product Record Updated");
                            sqlConnection.Close();
                        }
                        else
                        {
                            //MessageBox.Show("Parametr name nie może być pusty");
                            //TODO: check ean - //Parametr ean nie może być pusty, ujemny ???
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

        public void UpdateRecord(Product product)
        {
                UpdateRecord(product.id, product.name, product.ean);
        }

        public void UpdateRecord(Product product, Price price)
        {
            try
            {
                using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                {
                    if (product.name == "" || product.ean < 0)
                    {

                        //BEGIN TRANSACTIONS;

                        SqlCommand sqlCommand = new SqlCommand("UPDATE Product SET name=@name, ean=@ean WHERE ID=@id", sqlConnection);
                        sqlConnection.Open();
                        //cmd.Parameters.AddWithValue("@id", ID); auto inc
                        sqlCommand.Parameters.AddWithValue("@name", product.name);
                        sqlCommand.Parameters.AddWithValue("@ean", product.ean);
                        sqlCommand.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("UPDATE Price SET net=@net, tax=@tax WHERE ID=@id", sqlConnection);

                        //cmd.Parameters.AddWithValue("@id", ID); auto inc
                        sqlCommand.Parameters.AddWithValue("@net", price.net);
                        sqlCommand.Parameters.AddWithValue("@tax", price.tax);
                        sqlCommand.ExecuteNonQuery();

                        //MessageBox.Show("Product Record Updated");
                        //COMMIT

                        sqlConnection.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Parametr name nie może być pusty");
                        //TODO: check ean - //Parametr ean nie może być pusty, ujemny ???
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
        /// Function Delete Data from table Price
        /// </summary>
        /// <param name="id"></param>
        public override void DeleteRecord(int id)
        {
            try
            {
                using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                {
                    {

                        //BEGIN TRANSACTIONS;

                        SqlCommand sqlCommand = new SqlCommand("If exists(SELECT id FROM Price WHERE id = @id) DELETE Price WHERE Id=@id", sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlCommand.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("DELETE Product WHERE Id=@id", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@id", id);
                        sqlCommand.ExecuteNonQuery();

                        //MessageBox.Show("Product Record Updated");
                        //COMMIT

                        sqlConnection.Close();
                    }
                    //else
                    //{
                    //    //MessageBox.Show("Parametr name nie może być pusty");
                    //    //TODO: check ean - //Parametr ean nie może być pusty, ujemny ???
                    //}
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

        public void DeleteRecord(Product product)
        {
            try
            {
                using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                {
                    if (product.name == "" || product.ean < 0)
                    {

                        //BEGIN TRANSACTIONS;

                        SqlCommand sqlCommand = new SqlCommand("DELETE Price WHERE Id=@id", sqlConnection);
                        sqlConnection.Open();
                        sqlCommand.Parameters.AddWithValue("@id", product.id);
                        sqlCommand.ExecuteNonQuery();

                        sqlCommand = new SqlCommand("DELECTE Product  WHERE Id=@id", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@id", product.id);
                        sqlCommand.ExecuteNonQuery();

                        //MessageBox.Show("Product Record Updated");
                        //COMMIT

                        sqlConnection.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Parametr name nie może być pusty");
                        //TODO: check ean - //Parametr ean nie może być pusty, ujemny ???
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
        /// Function return Product Data With Joined Price
        /// </summary>
        /// <returns>Product with price</returns>
        public DataTable GetData()
        {
            DataTable prodTable = new DataTable();

            try
            {
                using (sqlConnection = new SqlConnection(dbConnection.connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Product LEFT JOIN Price ON (Product.Id = Price.Id)", sqlConnection);
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = sqlCommand;
                    sqlConnection.Open();
                    //prodTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.Fill(prodTable);
                    sqlConnection.Close();
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

            return prodTable;
        }
    }

}
