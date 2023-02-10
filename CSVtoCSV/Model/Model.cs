using System;
using CsvHelper.Configuration.Attributes;
using exceltool.Utils;

namespace  Model.DTO
{
    public class FileInformation
    {

        [Name("요청시간(UTC)")]
        public string RequestTimeUtc { get; set; }
        [Name("요청시간(한국)")]

        public string RequestDateKorea { get; set; }
        [Name("로그 분류")]

        public string LogType { get; set; }
        [Name("요청 URL")]

        public string RequestUrl { get; set; }
        [Name("유저 아이디")]

        public string UserId { get; set; }

        public static string GetFullPathNames(string filePath, string fileName)
        {
            return Utils.RestClient(filePath, fileName);
        }

        
        public static FileInformation CsvLineToCollection(string csvLine)
        {

            FileInformation fileInfo = new FileInformation();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            (DateTime utcTime, DateTime koreaTime) multiTime = Utils.ReturnDateTime(csvValues[2]);

            fileInfo.RequestTimeUtc = multiTime.utcTime.ToString("yyyy/MM/dd HH:mm:ss");
            fileInfo.RequestDateKorea = multiTime.koreaTime.ToString("yyyy/MM/dd HH:mm:ss");
            fileInfo.LogType = csvValues[7].Replace('\"', ' ').Trim();
            fileInfo.RequestUrl = csvValues[9].Replace('\"', ' ').Trim();
            fileInfo.UserId = csvValues[10].Replace('\"', ' ').Trim();

            return fileInfo;
            
        }

    }

    public class DownloadFilePathInfo
    {
        [Name("ID")]
        public string FileId { get; set; }
        [Name("다운로드 파일명")]
        public string FullFilePath { get; set; }

        public static DownloadFilePathInfo CsvLineToCollection(string csvLine)
        {
            DownloadFilePathInfo fileInfo = new DownloadFilePathInfo();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            if (csvLine.Length > 0)
            {
                fileInfo.FileId = csvValues[0];
                if (csvValues.Length > 2)
                {
                    fileInfo.FullFilePath = csvValues[1] + csvValues[2];
                }
                else
                {
                    fileInfo.FullFilePath = csvValues[1];
                }
                
            }

            return fileInfo;

        }
    }

    public class DownloadFolderInfo
    {


        [Name("요청시간(UTC)")]
        public string RequestTimeUtc { get; set; }
        [Name("요청시간(한국)")]

        public string RequestDateKorea { get; set; }
        [Name("로그 분류")]

        public string LogType { get; set; }
        [Name("클라이언트 IP")]
        public string ClientIp { get; set; }
        [Name("요청 URL")]

        public string RequestUrl { get; set; }
        [Name("유저 아이디")]
        public string UserId { get; set; }

        public static DownloadFolderInfo CsvLineToCollection(string csvLine)
        {

            DownloadFolderInfo folderInfo = new DownloadFolderInfo();

            string[] csvValues = Utils.ReturnSplitString(csvLine);

            (DateTime utcTime, DateTime koreaTime) multiTime = Utils.ReturnDateTime(csvValues[2]);


            folderInfo.RequestTimeUtc = multiTime.utcTime.ToString("yyyy/MM/dd HH:mm:ss");
            folderInfo.RequestDateKorea = multiTime.koreaTime.ToString("yyyy/MM/dd HH:mm:ss");
            folderInfo.LogType = csvValues[7].Replace('\"', ' ').Trim();
            folderInfo.ClientIp = csvValues[8].Replace('\"', ' ').Trim();
            folderInfo.RequestUrl = csvValues[9].Replace('\"', ' ').Trim();
            folderInfo.UserId = csvValues[10].Replace('\"', ' ').Trim();

            return folderInfo;

        }

    }

}



