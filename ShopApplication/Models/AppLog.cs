using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApplication.Models
{
    class AppLog
    {
        //class CLogFile
        //{
        //    const string logFolderName = "Logs";
        //    const string errorFolderName = "Logs";
        //    const string logFileName = "log";
        //    const string errorFileName = "errors";
        //    const string logFileExtension = "txt";
        //    const string errorFileExtension = "txt";
        //    const string backupLogSeparator = "|";
        //    static string applicationDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
        //    string path = Path.GetDirectoryName(Application.ExecutablePath);

        //    /// <summary>
        //    /// Function saves message to Error log file
        //    /// </summary>
        //    /// <param name="message"></param>
        //    public static void SaveErrorMessage(string message)
        //    {
        //        string filePath = applicationDirectory + @"\" + errorFolderName + @"\" + errorFileName + "." + errorFileExtension;

        //        SaveMessage(filePath, CreateMessage(message));

        //    }

        //    /// <summary>
        //    /// Function saves message to Log file
        //    /// </summary>
        //    /// <param name="message"></param>
        //    public static void SaveLogMessage(string message)
        //    {
        //        string filePath = GetAppLogPath() + @"\" + logFileName + "_"
        //            + DateTime.Now.ToShortDateString().Replace('.', '-') + "." + logFileExtension;

        //        SaveMessage(filePath, CreateMessage(message));
        //    }

        //    public static void SaveMessage(string filePath, string message)
        //    {
        //        File.AppendAllText(filePath, message + Environment.NewLine);

        //    }

        //    /// <summary>
        //    /// Function Save info about copied files/directories to specyfied Log file
        //    /// </summary>
        //    /// <param name="fileName">Specyfied Log file</param>
        //    /// <param name="message">Info to save</param>
        //    public static void SaveBackupPathStatus(string fileName, string message)
        //    {
        //        Console.WriteLine("Save beckup info to: " + GetAppLogPath() + @"\" + fileName);
        //        File.AppendAllText(GetAppLogPath() + @"\" + fileName, message + backupLogSeparator + " ["
        //            + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]" + Environment.NewLine);

        //    }

        //    /// <summary>
        //    /// Return Copied Catalog/File path without extra information from specyfied message
        //    /// </summary>
        //    /// <param name="message"></param>
        //    /// <returns>File path</returns>
        //    public static string GetBackupPathInfo(string message)
        //    {
        //        if (message.Length > 0)
        //            if (message.Contains(backupLogSeparator))
        //                return message.Substring(0, message.IndexOf(backupLogSeparator));
        //            else
        //                return message;
        //        else
        //            return "";

        //    }

        //    /// <summary>
        //    /// Function returns application Log path
        //    /// </summary>
        //    /// <returns>Application Log Path</returns>
        //    public static string GetAppLogPath()
        //    {
        //        return applicationDirectory + logFolderName;
        //    }

        //    /// <summary>
        //    /// Function prepare Message to write (adds date to message)
        //    /// </summary>
        //    /// <param name="message"></param>
        //    /// <returns></returns>
        //    private static string CreateMessage(string message)
        //    {
        //        return "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "] " + message;
        //    }


        //}
    }

}

