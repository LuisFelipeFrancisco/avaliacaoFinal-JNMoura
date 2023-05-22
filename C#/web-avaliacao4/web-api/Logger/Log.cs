using System;
using System.IO;

namespace Logger
{
    public class Log
    {
        public static void write(Exception ex, string LogPath)
        {
            using (StreamWriter sw = new StreamWriter(LogPath, true))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("Data: " + DateTime.Now.ToString());
                sb.AppendLine("Mensagem: " + ex.Message);
                sb.AppendLine("StackTrace: " + ex.StackTrace);
                sb.AppendLine("InnerException: " + ex.InnerException);
                sb.AppendLine("Type: " + ex.GetType());
                sb.AppendLine("Source: " + ex.Source);
                sb.AppendLine("TargetSite: " + ex.TargetSite);
                sb.AppendLine("--------------------------------------------------");
                sw.WriteLine(sb.ToString());
            }
        }
    }
}
