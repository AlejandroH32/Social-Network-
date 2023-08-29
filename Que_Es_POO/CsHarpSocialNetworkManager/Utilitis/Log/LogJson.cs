using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Utilitis._Log
{
    public class LogJson : ILogs<LogObject> , ILogs<string>
    {
        public void saveLog(LogObject action)
        {

            string LogPath = Directory.GetCurrentDirectory() + "\\Log.Json";
            string currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            if (File.Exists(LogPath))
            {
                var streamReader = new StreamReader(LogPath);
                currentContent = streamReader.ReadToEnd();
                logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent);
                streamReader.Close();
            }




            var streamWriter = new StreamWriter(LogPath);
           
          
            logObjects.Add(action);

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);
            streamWriter.Close();
        }

        public void saveLog(string action)
        {

            string LogPath = Directory.GetCurrentDirectory() + "\\Log.Json";
            string currentContent = string.Empty;

            var logObjects = new List<LogObject>();

            if (File.Exists(LogPath))
            {
                var streamReader = new StreamReader(LogPath);
                currentContent = streamReader.ReadToEnd();
                logObjects = JsonConvert.DeserializeObject<List<LogObject>>(currentContent);
                streamReader.Close();
            }




            var streamWriter = new StreamWriter(LogPath);


            logObjects.Add(new LogObject() { Action = action, LogDate = DateTime.Now});

            var jsonResult = JsonConvert.SerializeObject(logObjects);

            streamWriter.WriteLine(jsonResult);
            streamWriter.Close();
        }
    }
}
