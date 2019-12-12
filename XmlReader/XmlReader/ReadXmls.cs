using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XmlReader
{
    class ReadXmls
    {
        internal static void ReadDirectory(String pDirectoryPath)
        {
            try
            {
                StringBuilder FileText = new StringBuilder();

                FileText.AppendLine("NumNota; indPag; tPag; vPag; nDup; dVenc; vDup");
                while(!File.Exists(pDirectoryPath))
                {
                    ConsolePrint.GetDirectory(1);
                }
                String[] XmlFilesList = Directory.GetFiles(pDirectoryPath, "*.xml", SearchOption.AllDirectories);
                Console.WriteLine("Arquivos Encontrados");
                foreach (var File in XmlFilesList)
                {
                    try
                    {
                        XDocument doc = XDocument.Load(File);
                        XNamespace name = "http://www.portalfiscal.inf.br/nfe";

                        //Busca os valores da Tag fat
                        var vQueryDetPag = from detPag in doc.Descendants(name + "detPag")
                                           select new
                                           {
                                               indPag = (string)detPag.Element(name + "indPag"),
                                               tPag = (string)detPag.Element(name + "tPag"),
                                               vPag = (string)detPag.Element(name + "vPag")
                                           };

                        foreach (var vDetPag in vQueryDetPag)
                        {
                            String vFatValues = vDetPag.indPag + "," + vDetPag.tPag + "," + vDetPag.vPag;

                            if (vDetPag.tPag == "15")
                            {
                                String vNNF = String.Empty;
                                var vIdeQuery = from ide in doc.Descendants(name + "ide")
                                                select new
                                                {
                                                    nNF = (string)ide.Element(name + "nNF"),
                                                    dhEmi = (string)ide.Element(name + "dhEmi")
                                                };
                                foreach (var item in vIdeQuery)
                                {
                                    vNNF = item.nNF;
                                }
                                //busca os Valores da Tag dup
                                var vDupQuery = from dup in doc.Descendants(name + "dup")
                                                select new
                                                {
                                                    nDup = (string)dup.Element(name + "nDup"),
                                                    dVenc = (string)dup.Element(name + "dVenc"),
                                                    vDup = (string)dup.Element(name + "vDup")
                                                };

                                foreach (var vDup in vDupQuery)
                                {
                                    FileText.AppendLine($"\"" + vNNF + "\";\"" + vDetPag.indPag + "\";\"" + vDetPag.tPag + "\";\"" + vDetPag.vPag + "\";\"" + vDup.nDup + "\";\"" + vDup.dVenc + "\";\"" + vDup.vDup + "\"");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", vNNF, vDetPag.indPag, vDetPag.tPag, vDetPag.vPag, vDup.nDup, vDup.dVenc, vDup.vDup);
                                }
                                break;
                            }
                            else
                            {
                                var vIdeQuery = from ide in doc.Descendants(name + "ide")
                                                select new
                                                {
                                                    nNF = (string)ide.Element(name + "nNF"),
                                                    dhEmi = (string)ide.Element(name + "dhEmi")
                                                };
                                foreach (var vIde in vIdeQuery)
                                {
                                    FileText.AppendLine("\"" + vIde.nNF + "\";\"" + vDetPag.indPag + "\";\"" + vDetPag.tPag + "\";\"" + vDetPag.vPag + "\";;\"" + vIde.dhEmi.Split('T')[0] + "\";");
                                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", vIde.nNF, vDetPag.indPag, vDetPag.tPag, vDetPag.vPag, vIde.dhEmi.Split('T')[0]);
                                }
                                break;
                            }
                        }
                    }
                    catch (Exception Ex)
                    {
                        ConsolePrint.ErrorMessage(1030, Ex.Message);
                    }
                }
                SaveFile.CsvFile(FileText);
            }
            catch (Exception Ex)
            {
                ConsolePrint.ErrorMessage(1040, Ex.Message);
            }
        }
    }
}
