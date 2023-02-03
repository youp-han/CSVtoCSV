using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace exceltool.Utils
{
    public class  Utils
    {

        public static (DateTime dt, DateTime cstTime) ReturnDateTime(string beforeString)
        {

            string[] splitbeforeString = beforeString.Split(' ');

            //date
            string dateStr = splitbeforeString[0].Remove(0, 1);
            string[] dateStrSplit = dateStr.Split('-');

            //time
            string timeStr = splitbeforeString[1];
            string[] timeStrSplitToMilleSecond = timeStr.Split('.');
            string timeStrNoMilissecond = timeStrSplitToMilleSecond[0];
            string timeStrMilli = timeStrSplitToMilleSecond[1].Remove(3, 1);
            string[] timeStrSplitToHHMMSS = timeStrNoMilissecond.Split(':');


            DateTime dt = new DateTime(
                Convert.ToInt16(dateStrSplit[0]),
                Convert.ToInt16(dateStrSplit[1]),
                Convert.ToInt16(dateStrSplit[2]),
                Convert.ToInt16(timeStrSplitToHHMMSS[0]),
                Convert.ToInt16(timeStrSplitToHHMMSS[1]),
                Convert.ToInt16(timeStrSplitToHHMMSS[2]),
                Convert.ToInt16(timeStrMilli)
            );

            DateTime cstTime = dt.AddHours(9);

            return (dt, cstTime);
        }

        public static string[] ReturnSplitString(string csvLine)
        {
            return Regex.Split(csvLine, "[,]{1}(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        }




        public static string RestClient(string uri, string filePath, string fileName)
        {
            WebResponse response = null;
            try
            {
                string sWebAddress = uri;

                string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
                byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");
                HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(sWebAddress);
                wr.ContentType = "multipart/form-data; boundary=" + boundary;
                wr.Method = "POST";
                wr.KeepAlive = true;

                wr.Headers.Add("api-key", "0HBNAMZkWG3rDZKrooapZgIk28davRVF");

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
        //    request.AddHeader("api-key", "0HBNAMZkWG3rDZKrooapZgIk28davRVF");

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
