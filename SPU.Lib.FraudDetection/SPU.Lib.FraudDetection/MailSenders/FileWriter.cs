namespace SPU.Lib.FraudDetection.MailSenders
{
    using System.IO;

    public class FileWriter
    {
        public static void WriteFile(string content)
        {
            File.WriteAllText("suspicious-statistics.txt", content);
        }
    }
}