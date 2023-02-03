using CsvHelper;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.DTO;

namespace exceltool.Contoller
{
    public class TaskController
    {
        public void GetDownloadsInfoFile(string readFromFileName, string tempWriteToFileName, string fullFilePath, string writeToFileName)
        {
            //1. Send CSV Data
            var data = FileInformation.GetFullPathNames(readFromFileName, fullFilePath);

            //////2. Write Returned Data to CSV File
            string[]dataArray = data.Split('\n');
            bool fileWriteResult = WriteStringToFile(tempWriteToFileName, dataArray);
            
            //3. Build the 2 Collections using reading 2 files
            List<FileInformation> downloadedFileInfo = File.ReadLines(readFromFileName)
                .Skip(1)
                .Select(v => FileInformation.csvLineToCollection(v))
                .ToList();

            List<DownloadFilePathInfo> filePathInfo = File.ReadLines(tempWriteToFileName)
                .Skip(1)
                .Select(x => DownloadFilePathInfo.csvLineToCollection(x))
                .ToList();

            //4. Combine 2 collection into side by side
            var newList = downloadedFileInfo.Join(filePathInfo, s => downloadedFileInfo.IndexOf(s), i => filePathInfo.IndexOf(i), (s, i) => new { sv = s, iv = i }).ToList();
            
            //5. Print it to the CVS file
            writeToCSVFile(writeToFileName, newList);
        }

        public void writeToCSVFile<T>(string writeToFileName, IEnumerable<T>newList)
        {
            var writer = new StreamWriter(writeToFileName, true, Encoding.UTF8);
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(newList);
            }
            MessageBox.Show("Finished");
        }


        public void GetFolderInfo(string readFromFileName, string writeToFileName)
        {

            //3. Build the 2 Collections using reading 2 files
            List<DownloadFolderInfo> downloadFolderInfo = File.ReadLines(readFromFileName)
                .Skip(1)
                .Select(v => DownloadFolderInfo.csvLineToCollection(v))
                .ToList();


            //5. Print it to the CVS file
            writeToCSVFile(writeToFileName, downloadFolderInfo);
        }

        private bool WriteStringToFile(string tempWriteToFileName, string[] dataArray)
        {
            File.WriteAllLines(tempWriteToFileName, dataArray);
            return true;
        }
    }
}