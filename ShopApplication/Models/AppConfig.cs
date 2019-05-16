using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Models
{
    public class AppConfig
    {
        public DBConnection connection;
        public bool connectionOK = false;
        
        public AppConfig()
        {
            //string serwer = ConfigurationManager.AppSettings["SerwerName"];
            //string baza = ConfigurationManager.AppSettings["DatabaseName"];
            //string uzytkownik = ConfigurationManager.AppSettings["UserName"];
            //string haslo = ConfigurationManager.AppSettings["UserPassword"];
            string serwer = ConfigurationManager.AppSettings[Setting.SerwerName.ToString()];
            string baza = ConfigurationManager.AppSettings[Setting.DatabaseName.ToString()];
            string uzytkownik = ConfigurationManager.AppSettings[Setting.UserName.ToString()];
            string haslo = ConfigurationManager.AppSettings[Setting.UserPassword.ToString()];

            connection = new DBConnection(serwer, baza, uzytkownik, haslo);

            if (serwer == "" || baza == "" || uzytkownik == "" || haslo == "")
            {
                connectionOK = false;
                
            }
            else
            {
                //connection = new DBConnection(serwer, baza, uzytkownik, haslo);
                if (connection.TestConnection())
                    connectionOK = true;
                else
                    connectionOK = false;
            }
        }

    }
}
