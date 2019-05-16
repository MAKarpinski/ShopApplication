using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ShopApplication.Models
{
    //public class Customer
    //{
    //    public int id { get; set; }

    //    string Name;

    //}



    class DBData
    {
        public interface IDBData<T> where T : class
        {
            T GetData(int id);
            T GetData(string query);
            void Add(T item);
            void Remove(T item);
            void Update(T item);                                                                
            
        }

        //public interface ICustomerData : IDBData<Customer>
        //{

        //}



        //public class CustomerData : ICustomerData
        //{
            
        //    private List<Customer> customers;
        //    //private IDataContext m_DataContext = null;
        //    public CustomerData(SqlConnection connection)
        //    {
        //        //SqlConnection = connection;
        //        // inicjalizacja 
        //    }
        //    public Customer GetData(int id)
        //    {
                
        //        int index = customers.FindIndex(qu => qu.id == id);
        //        Customer customer = customers[index];
        //        return customer;
        //    }

        //    public Customer GetData(string query)
        //    {
        //        //??
        //        //int index = customers.FindIndex(qu => qu.id == id);
        //        Customer customer = customers[0];
        //        return customer;
        //    }

        //    public void Add(Customer item)
        //    {
        //        customers.Add(item);
        //    }
        //    public void Remove(Customer item)
        //    {
        //        customers.Remove(item);
        //    }
        //    public void Update(Customer item)
        //    {
        //        //customers.Update(item);
        //    }

        //}




        public interface IPriceData
        {
            Price Get(int id);
            Price GetByGuid(Guid guid);

        }

        public interface IProductData
        {
            Product Get(int id);
        }

        public class DBCreate
        {
            //private string serverName;
            //private string databaseName;
            //private string userName;
            //private string userPassword;
            //private string path;
            private string connectionString;
            private string creationString;

            /// <summary>
            /// 
            /// </summary>
            /// <param name="serverName"></param>
            /// <param name="databaseName"></param>
            /// <param name="userName"></param>
            /// <param name="userPassword"></param>
            /// <param name="path"></param>
            public DBCreate(string serverName, string databaseName, string userName, string userPassword, string path, int size = 5)
            {
                //SqlConnection connectionString = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");
                connectionString = @"Server = " + serverName + "; User ID = " + userName + "; Password = " + userPassword + "; database = master";
                //TODO: chenge into  StringBuilder

                creationString = "CREATE DATABASE " + databaseName + " ON " +
                "(NAME = " + databaseName + "_DATA, FILENAME = '" + path + "\\" + databaseName + ".mdf', " +
                "SIZE = " + size + ") "; //+
                //"LOG ON (NAME = " + databaseName + "_Log, " +
                //"FILENAME = '" + path + "\\" + databaseName + "_Log.ldf', " +
                //"SIZE = 2MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";
                //TODO: chenge into  StringBuilder
            }

            public bool Create()
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(creationString, connection);
                bool ret = false;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    ret = true;
                }
                catch (System.Exception ex)
                {
                    AppError.SaveError(ex.Message);
                    ret = false;
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

                return ret;

            }
        }

    }
}
