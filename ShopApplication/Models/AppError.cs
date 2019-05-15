using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApplication.Models
{
    class AppError
    {
        
        const string errorFolderName = "Logs";
        const string errorFileName = "errorsLog";
        const int maxFileSize = 500000;

        /// <summary>
        /// Function saves error message to file in logs folder
        /// </summary>
        /// <param name="errorText">error message</param>
        public static void SaveError(string errorText)
        {
            try
            {
                string fileDir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), errorFolderName);
                string filePath = Path.Combine(fileDir, errorFileName + ".txt");

                if (File.Exists(filePath))
                {
                    filePath = Directory.GetFiles(fileDir).OrderByDescending(f => new FileInfo(f).Name).FirstOrDefault(); 

                    FileInfo fileInfo = new FileInfo(filePath);
                    if (fileInfo.Length < maxFileSize)
                    {
                        SaveErrorToFile(filePath, errorText);
                    }
                    else
                    {
                        string fileName = fileInfo.Name;
                        int index = GetFileIndex(fileName);
                                    index++;
                        filePath = Path.Combine(fileDir, "Logs", errorFileName + "_" + index + ".txt");
                        FileStream stream = File.Create(filePath);
                        stream.Close();

                        SaveErrorToFile(filePath, errorText);
                    }
                }
                else
                {
                    FileStream stream = File.Create(filePath);
                    stream.Close();

                    SaveErrorToFile(filePath, errorText);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bład zapisu do pliku: " + ex.Message);
            }
        }


        /// <summary>
        /// Function returns numer of log specified file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static int GetFileIndex(string fileName)
        {
            string indexStr = fileName.Substring(errorFileName.Length - 1, fileName.IndexOf('.') - errorFileName.Length);
            int index = Int32.Parse(indexStr);
            return index;
        }

        /// <summary>
        /// Function saves message to specified file
        /// </summary>
        /// <param name="filePath">file path</param>
        /// <param name="errorText">message</param>
        private static void SaveErrorToFile(string filePath, string errorText)
        {
            StreamWriter writer = File.AppendText(filePath);//new StreamWriter(file);        
            writer.WriteLine("ERROR [" + DateTime.Now + "]: " + errorText);
            writer.Close();
        }
    }
}
