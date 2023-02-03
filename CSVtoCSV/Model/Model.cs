using System;
using CsvHelper.Configuration.Attributes;
using exceltool.Utils;

namespace  Model.DTO
{
    public class FileInformation
    {

        [Name("요청시간(UTC)")]
        public string requestTimeUTC { get; set; }
        [Name("요청시간(한국)")]

        public string requestDateKorea { get; set; }
        [Name("로그 분류")]

        public string logType { get; set; }
        [Name("요청 URL")]

        public string requestURL { get; set; }
        [Name("유저 아이디")]

        public string userID { get; set; }

        public static string GetFullPathNames(string filePath, string fileName)
        {
            string uri = "http://api.eland.co.kr/file-service/v1/system/file-info/csv-file";

            return Utils.RestClient(uri, filePath, fileName);
        }

        
        public static FileInformation csvLineToCollection(string csvLine)
        {

            FileInformation fileInfo = new FileInformation();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            (DateTime dt, DateTime cstTime) multiTime = Utils.ReturnDateTime(csvValues[2]);

            fileInfo.requestTimeUTC = multiTime.dt.ToString("yyyy/MM/dd HH:mm:ss");
            fileInfo.requestDateKorea = multiTime.cstTime.ToString("yyyy/MM/dd HH:mm:ss");
            fileInfo.logType = csvValues[7];
            fileInfo.requestURL = csvValues[9];
            fileInfo.userID = csvValues[10];

            return fileInfo;
            
        }

    }

    public class DownloadFilePathInfo
    {
        [Name("ID")]
        public string fileID { get; set; }
        [Name("다운로드 파일명")]
        public string fullFilePath { get; set; }

        public static DownloadFilePathInfo csvLineToCollection(string csvLine)
        {
            DownloadFilePathInfo fileInfo = new DownloadFilePathInfo();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            if (csvLine.Length > 0)
            {
                fileInfo.fileID = csvValues[0];
                if (csvValues.Length > 2)
                {
                    fileInfo.fullFilePath = csvValues[1] + csvValues[2];
                }
                else
                {
                    fileInfo.fullFilePath = csvValues[1];
                }
                
            }

            return fileInfo;

        }
    }

    public class DownloadFolderInfo
    {


        [Name("요청시간(UTC)")]
        public string requestTimeUTC { get; set; }
        [Name("요청시간(한국)")]

        public string requestDateKorea { get; set; }
        [Name("로그 분류")]

        public string logType { get; set; }
        [Name("클라이언트 IP")]
        public string clientIP { get; set; }
        [Name("요청 URL")]

        public string requestURL { get; set; }
        [Name("유저 아이디")]
        public string userID { get; set; }

        public static DownloadFolderInfo csvLineToCollection(string csvLine)
        {

            DownloadFolderInfo folderInfo = new DownloadFolderInfo();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            (DateTime dt, DateTime cstTime) multiTime = Utils.ReturnDateTime(csvValues[2]);


            folderInfo.requestTimeUTC = multiTime.dt.ToString("yyyy/MM/dd HH:mm:ss");
            folderInfo.requestDateKorea = multiTime.cstTime.ToString("yyyy/MM/dd HH:mm:ss");
            folderInfo.logType = csvValues[7];
            folderInfo.clientIP = csvValues[8];
            folderInfo.requestURL = csvValues[9];
            folderInfo.userID = csvValues[10];

            return folderInfo;

        }

    }

}



