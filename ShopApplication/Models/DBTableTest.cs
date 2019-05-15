using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    class DBTableTest
    {
        public enum Test
        {
            Standard, ProduktCena 
        }


        //klasa bazowa Tabeli
        interface DBTest
        {
            bool CreateTableTest();
            bool DeleteTableTest();
            bool AddRecordTest();
            bool DeleteRecordTest();
            bool UpdateRecordTest();
        }

        public class DBProductTableTest : DBTest
        {
            //        Table 2 Columns(Price) :
            //Id           as int notnull,
            //Net        as decimal (5,2) default 0.00
            //Tax        as integer default 23
            private DBConnection dbConnection;

            public DBProductTableTest(DBConnection connection)
            {
                name = "Product";
                dbConnection = connection;
            }
            string name { get; set; }
            //public string name;// { get => name; set => name = value; }

            public bool CreateTableTest()
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.Create();

                //TODO Check if OK!

                return true;
                //throw new NotImplementedException();
            }

            public bool DeleteTableTest()
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.DeleteTable();

                //TODO Check if OK!

                return true;
                //throw new NotImplementedException();

            }

            public bool AddRecordTest()
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.AddRecord();

                //TODO Check if OK!

                return true;
            }

            public bool AddRecordTest(string productName, int ean)
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.AddRecord(productName, ean);

                //TODO Check if OK!

                return true;
            }

            public bool AddRecordTest(string productName, int ean, decimal net = 0, int tax = 23)
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.AddRecord(productName, ean, net, tax);

                //TODO Check if OK!

                return true;
            }

            public bool DeleteRecordTest(int id)
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.DeleteRecord(id);

                //TODO Check if OK!

                return true;
                //throw new NotImplementedException();
            }

            public bool UpdateRecordTest(int id, string productName, int ean)
            {
                DBProduct productTable = new DBProduct(dbConnection);
                productTable.UpdateRecord(id, productName, ean);

                //TODO Check if OK!

                return true;
                //throw new NotImplementedException();
            }

            public bool DeleteRecordTest()
            {
                throw new NotImplementedException();
            }

            public bool UpdateRecordTest()
            {
                throw new NotImplementedException();
            }
        }

        //class DBPriceTableTest : DBTest
        //{
        //    //        Table 2 Columns(Price) :
        //    //Id           as int notnull,
        //    //Net        as decimal (5,2) default 0.00
        //    //Tax        as integer default 23

        //    public DBPriceTableTest()
        //    {
        //        name = "Price";
        //    }

        //    public string name { get => name; set => name = value; }

        //    public bool AddTest()
        //    {

        //        return false;
        //    }

        //    public bool DeleteTest()
        //    {
        //        return false;
        //        //throw new NotImplementedException();
        //    }

        //    public bool UpdateTest()
        //    {
        //        return false;
        //        //throw new NotImplementedException();
        //    }

        //    public bool CreateTest()
        //    {
        //        return false;
        //        //throw new NotImplementedException();
        //    }
        //}

        interface IDBTestCreator
        {
            bool CreateTest(Table tableName, DBConnection connection);

            bool CreateFullTest(Table tableName, DBConnection connection);

            //void CreateFullTest(Table tableName);

        }

        public class DBTestTableCreator : IDBTestCreator
        {
            //public DBTable overide CteateTable(string dbName)
            //{
            //    return null;
            //}

            public bool CreateTest(Table tableName, DBConnection connection)
            {
                DBTest table = null;
                bool ret = false;
                //DBConnection dBConnection = new DBConnection()

                switch (tableName)
                {
                    //case Table.Customer:
                    //    table = new DBProTableTest();
                    //    //table.
                    //    break;

                    case Table.Product:
                        table = new DBProductTableTest(connection);
                        table.CreateTableTest();
                        

                        //TO DO: Check if OK
                        ret = true;
                        break;

                    //case Table.Price:
                    //    table = new DBTablePrice();
                    //    break;

                    default:
                        break;
                }

                return ret;

            }

            public bool AddingRecordTest(Table tableName, Test testName, DBConnection connection)
            {
                DBProductTableTest table = null;
                bool ret = false;
                //DBConnection dBConnection = new DBConnection()

                switch (tableName)
                {
                    //case Table.Customer:
                    //    table = new DBProTableTest();
                    //    //table.
                    //    break;

                    case Table.Product:
                        table = new DBProductTableTest(connection);

                        switch (testName)
                        {
                            case Test.Standard:
                                table.AddRecordTest(); // Test Domyślny
                                break;

                            case Test.ProduktCena:
                                table.AddRecordTest("produkt Test", 10011, 5, 22); //Test Dodanie Produktu z Ceną

                                break;

                            default:
                                break;
                        }
                        
                        //table.AddRecordTest();
                        

                        //TO DO: Check if OK
                        ret = true;
                        break;

                    //case Table.Price:
                    //    table = new DBTablePrice();
                    //    break;

                    default:
                        break;
                }

                return ret;

            }

            public bool UpdateRecordTest(Table tableName, DBConnection connection)
            {
                DBTest table = null;
                bool ret = false;
                //DBConnection dBConnection = new DBConnection()

                switch (tableName)
                {
                    //case Table.Customer:
                    //    table = new DBProTableTest();
                    //    //table.
                    //    break;

                    case Table.Product:
                        table = new DBProductTableTest(connection);
                        table.UpdateRecordTest();

                        //TO DO: Check if OK
                        ret = true;
                        break;

                    //case Table.Price:
                    //    table = new DBTablePrice();
                    //    break;

                    default:
                        break;
                }

                return ret;
            }

            public bool DeleteRecordTest(Table tableName, DBConnection connection)
            {
                DBTest table = null;
                bool ret = false;
                //DBConnection dBConnection = new DBConnection()

                switch (tableName)
                {
                    //case Table.Customer:
                    //    table = new DBProTableTest();
                    //    //table.
                    //    break;

                    case Table.Product:
                        table = new DBProductTableTest(connection);
                        table.AddRecordTest();

                        //TO DO: Check if OK
                        ret = true;
                        break;

                    //case Table.Price:
                    //    table = new DBTablePrice();
                    //    break;

                    default:
                        break;
                }

                return ret;
            }

            public bool CreateFullTest(Table tableName, DBConnection connection)
            {
                //TODO Implement!!!
                //throw new NotImplementedException();
                return false;
            }

            //public void CreateTest(Table tableName)
            //{
            //    throw new NotImplementedException();
            //}
        }
    }
}
