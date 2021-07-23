using System.IO;

namespace DamData
{
    class OutputLogger
    {
        string filePath = @"C:\Users\IArch\Documents\C#\QuintessenceInternship\InternProjects\DamDataBST\DamData\OutputLog.txt";
        StreamWriter writer;

        public void AppendToOutputLog(string stringToLog)
        {
            using (writer = File.AppendText(filePath))
                writer.Write(stringToLog);
        }

        public void ClearOutputLogFile() => File.WriteAllText(filePath, "");
    }
}
