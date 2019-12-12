using System;

namespace XmlReader
{
    class ConsolePrint
    {
        internal static void ConsoleHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t------- XML READER -------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        internal static String GetDirectory(int pFirsTry)
        {
            Console.ForegroundColor = ConsoleColor.White;
            switch (pFirsTry)
            {
                case 0:
                    {
                        Console.Write("\tDigite o endereço completo do diretório com os Xmls à serem lido: ");
                        break;
                    }
                case 1:
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n\tO diretório digitado não existe!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\tDigite novamente o endereço completo do diretório com os Xmls à serem lido: ");
                        break;
                    }
                default:
                    ErrorMessage(1010, "Funcionalidade de diretórios não está implementada corretamente");
                    break;
            }
            return Console.ReadLine();
        }
        internal static void ErrorMessage(int pNumber, String pMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\tERRO ENCONTRADO!");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\tA aplicação encontrou o erro: {pNumber}");
            Console.WriteLine("\tDescrição: {pMessage}");
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }
}
