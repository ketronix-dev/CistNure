using System.Net;
using System.Text;
using CistNure.Enums;

namespace CistNure.Requests
{
    public class Cist
    {
        public static string GetScheduleJson(long Id, ScheduleTypes Type, long StartInUnix, long EndInUnix, string Key)
        {
            string json;
            Thread.Sleep(4000);
            var webRequest = WebRequest.Create($"https://cist.nure.ua/ias/app/tt/P_API_EVEN_JSON?type_id=1&timetable_id=10304333&time_from=1662004800&time_to=1690696800&idClient=KNURESked") as HttpWebRequest;

            webRequest.ContentType = "application/json";

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            using (var webResponse = webRequest.GetResponse())
            using (var streamReader = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding("windows-1251")))
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                streamWriter.Write(streamReader.ReadToEnd());
                streamWriter.Flush();
                memoryStream.Position = 0;

                Console.WriteLine(Encoding.UTF8.GetString(memoryStream.ToArray()));

                json = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            return json;
        }
    }
}