using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace exceltool.Utils
{
    public class  Utils
    {

        public static (DateTime dt, DateTime cstTime) ReturnDateTime(string beforeString)
        {

            // "\"2022-12-26 04:04:54.000\""
            beforeString = beforeString.Replace('\"', ' ').Trim();
            DateTime UTC =  Convert.ToDateTime(beforeString);
            DateTime koreaTime = UTC.AddHours(9);
            return (UTC, koreaTime);
        }

        public static string[] ReturnSplitString(string csvLine)
        {
            return Regex.Split(csvLine, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        }
        

        public static string RestClient(string filePath, string fileName)
        {
            WebResponse response = null;

            try
            {
                string sWebAddress = ConfigurationSettings.AppSettings["api-url"];

                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(sWebAddress);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;

                wr.Headers.Add("api-key", ConfigurationSettings.AppSettings["api-key"]);

                Stream stream = wr.GetRequestStream();
                string formdataTemplate = "Content-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}";

                stream.Write(boundarybytes, 0, boundarybytes.Length);
                byte[] formitembytes = System.Text.Encoding.UTF8.GetBytes(filePath);
                stream.Write(formitembytes, 0, formitembytes.Length);
                stream.Write(boundarybytes, 0, boundarybytes.Length);
                string headerTemplate = "Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
                string header = string.Format(headerTemplate, "file", Path.GetFileName(filePath), Path.GetExtension(filePath));
                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(header);
                stream.Write(headerbytes, 0, headerbytes.Length);

                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] buffer = new byte[4096];
                int bytesRead = 0;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) != 0)
                    stream.Write(buffer, 0, bytesRead);
                fileStream.Close();

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                stream.Write(trailer, 0, trailer.Length);
                stream.Close();

                response = wr.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(responseStream);
                string responseData = streamReader.ReadToEnd();
                return responseData;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                if (response != null)
                    response.Close();
            }

        }






        //public static string RestClientPost(string uri, string filePath, string fileName)
        //{
        //    var client = new RestClient(uri);
        //    var request = new RestRequest(uri, Method.Post);
        //    request.AddHeader("Content-Type", "multipart/form-data");
        //    request.AddHeader("Accept", "*/*");
        //    request.AddHeader("Accept-Encoding", "gzip, deflate,br");
        //    request.AddHeader("api-key", "987098797098");

        //    //request.AddFile(Path.GetFileNameWithoutExtension(fileName), filePath);
        //    request.AddFile(fileName, filePath);


        //    var result = "";
        //    var response = client.Execute(request);

        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        result = response.Content;
        //    }
        //    else
        //    {
        //        result = response.StatusCode.ToString();
        //    }
        //    //Console.WriteLine(result);
        //    return result;
        //}

    }
}
