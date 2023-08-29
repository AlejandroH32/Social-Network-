using CsHarpSocialNetworkManager.Utilitis.Log;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsHarpSocialNetworkManager.Utilitis._Log
{
    public class LogTest : ILogs<string> ,ILogText
    {
        public string GetLogText()
        {

            string LogPath = Directory.GetCurrentDirectory() + "\\Log.txt";
            string currentContent = string.Empty;
            if (File.Exists(LogPath))
            {
                var streamReader = new StreamReader(LogPath);
                currentContent = streamReader.ReadToEnd();
                streamReader.Close();
            }
            return currentContent;

        }

        public void saveLog(string action)
        {

            string LogPath = Directory.GetCurrentDirectory() + "\\Log.txt";
            string currentContent = string.Empty;
            if (File.Exists(LogPath))
            {
                var streamReader = new StreamReader(LogPath);
                currentContent = streamReader.ReadToEnd();
                streamReader.Close();
            }


            

           var streamWriter = new StreamWriter(LogPath);
            
            streamWriter.WriteLine($"{DateTime.Now} - {action}");
            streamWriter.WriteLine(currentContent);
            streamWriter.Close();
        } 
    }
}
