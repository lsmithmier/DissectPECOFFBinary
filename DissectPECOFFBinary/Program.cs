using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                if(!string.IsNullOrEmpty(options.FileName) && 
                    File.Exists(options.FileName))
                {
                    DissectFile(options.FileName);
                } else
                {
                    Console.WriteLine(options.GetUsage());
                }
            }
            if (options.ShowingHelp)
            {
                return;
            }
            Console.WriteLine("Press return to exit");
            Console.ReadLine();
        }

        private static void DissectFile(string fileName)
        {
            Dictionary<string, SectionTable?> sectionTables = 
                new Dictionary<string, SectionTable?>();
            using(FileStream inputFile = File.OpenRead(fileName))
            {
                MSDOS20Section? msdos20Section = 
                    inputFile.ReadStructure<MSDOS20Section>();
                Console.WriteLine(msdos20Section.ToString());
                PESignature? peSignature = 
                    inputFile.ReadStructure<PESignature>();
                Console.WriteLine(peSignature.ToString());
                COFFHeader? coffHeader =
                    inputFile.ReadStructure<COFFHeader>();
                Console.WriteLine(coffHeader.ToString());
                COFFOptionalHeaderStandardFields? 
                    coffOptionalHeaderStandardFields = inputFile.
                        ReadStructure<COFFOptionalHeaderStandardFields>();
                Console.WriteLine(
                    coffOptionalHeaderStandardFields.ToString());
                if(coffOptionalHeaderStandardFields.Value.Magic == 0x10b)
                {
                    OptionalHeaderWindowsSpecificPE32?
                        optionalHeaderWindowsSpecificPE32 = inputFile.
                            ReadStructure<OptionalHeaderWindowsSpecificPE32>();
                    Console.WriteLine(
                        optionalHeaderWindowsSpecificPE32.ToString());
                }
                else
                {
                    OptionalHeaderWindowsSpecificPE32Plus?
                        optionalHeaderWindowsSpecificPE32Plus = 
                        inputFile.ReadStructure<
                            OptionalHeaderWindowsSpecificPE32Plus>();
                    Console.WriteLine(
                        optionalHeaderWindowsSpecificPE32Plus.ToString());
                }
                OptionalHeaderDataDirectories?
                    optionalHeaderDataDirectories = inputFile.
                        ReadStructure<OptionalHeaderDataDirectories>();
                Console.WriteLine(
                    optionalHeaderDataDirectories.ToString());
                for (int i = 0; i < coffHeader.Value.NumberOfSections; i++)
                {

                    SectionTable?
                        sectionTable = inputFile.
                            ReadStructure<SectionTable>();
                    Console.WriteLine(
                        sectionTable.ToString());
                    sectionTables.Add(sectionTable.Value.Name, sectionTable);
                }
            }
        }
    }
}