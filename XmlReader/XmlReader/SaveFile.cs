using System;
using System.IO;
using System.Text;

namespace XmlReader
{
    class SaveFile
    {
        internal static void CsvFile(StringBuilder pTextToFile)
        {
            try
            {
                String DiretoryPath = @"C:\XmlLeitura";
                String vNameArquive = @"C:\XmlLeitura\RelatórioXml.csv";

                if (!Directory.Exists(DiretoryPath))
                {
                    Directory.CreateDirectory(DiretoryPath);
                }
                StreamWriter vTextWriter = new StreamWriter(vNameArquive);
                vTextWriter.WriteLine(pTextToFile.ToString());
                vTextWriter.Close();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Arquivo .csv exportado com sucesso para pasta C:\\XmlLeitura");

            }
            catch (Exception Ex)
            {
                ConsolePrint.ErrorMessage(1050, Ex.Message);
            }
        }
    }
}
