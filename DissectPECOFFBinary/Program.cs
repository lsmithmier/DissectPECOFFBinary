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
            Dictionary<string, SectionTable> sectionTables = 
                new Dictionary<string, SectionTable>();
            using(FileStream inputFile = File.OpenRead(fileName))
            {
                WriteStartingAddress(inputFile);
                MSDOS20Section? msdos20Section =
                    inputFile.ReadStructure<MSDOS20Section>();
                Console.WriteLine(msdos20Section.ToString());
                WriteStartingAddress(inputFile);
                PESignature? peSignature =
                    inputFile.ReadStructure<PESignature>();
                Console.WriteLine(peSignature.ToString());
                WriteStartingAddress(inputFile);
                COFFHeader? coffHeader =
                    inputFile.ReadStructure<COFFHeader>();
                Console.WriteLine(coffHeader.ToString());
                WriteStartingAddress(inputFile);
                COFFOptionalHeaderStandardFields?
                    coffOptionalHeaderStandardFields = inputFile.
                        ReadStructure<COFFOptionalHeaderStandardFields>();
                Console.WriteLine(
                    coffOptionalHeaderStandardFields.ToString());
                if (coffOptionalHeaderStandardFields.Value.Magic == 0x10b)
                {
                    WriteStartingAddress(inputFile);
                    OptionalHeaderWindowsSpecificPE32?
                        optionalHeaderWindowsSpecificPE32 = inputFile.
                            ReadStructure<OptionalHeaderWindowsSpecificPE32>();
                    Console.WriteLine(
                        optionalHeaderWindowsSpecificPE32.ToString());
                }
                else
                {
                    WriteStartingAddress(inputFile);
                    OptionalHeaderWindowsSpecificPE32Plus?
                        optionalHeaderWindowsSpecificPE32Plus =
                        inputFile.ReadStructure<
                            OptionalHeaderWindowsSpecificPE32Plus>();
                    Console.WriteLine(
                        optionalHeaderWindowsSpecificPE32Plus.ToString());
                }
                WriteStartingAddress(inputFile);
                OptionalHeaderDataDirectories?
                    optionalHeaderDataDirectories = inputFile.
                        ReadStructure<OptionalHeaderDataDirectories>();
                Console.WriteLine(
                    optionalHeaderDataDirectories.ToString());
                for (int i = 0; i < coffHeader.Value.NumberOfSections; i++)
                {
                    WriteStartingAddress(inputFile);
                    SectionTable?
                        sectionTable = inputFile.
                            ReadStructure<SectionTable>();
                    Console.WriteLine(
                        sectionTable.ToString());
                    if (sectionTable.HasValue)
                    {
                        sectionTables.Add(sectionTable.Value.Name, sectionTable.Value);
                    }
                }
                foreach (var sectionTable in sectionTables.
                    OrderBy(x=>x.Value.PointerToRawData))
                {
                    byte[] buffer = new byte[sectionTable.Value.VirtualSize];
                    inputFile.Position = sectionTable.Value.PointerToRawData;
                    WriteStartingAddress(inputFile);
                    inputFile.Read(buffer, 0,
                        (int)sectionTable.Value.VirtualSize);
                    Console.WriteLine("Raw dump of section {0}",sectionTable.Key);
                    Console.WriteLine(HexDump(buffer));
                }
                var importAddresses = ImportAddressTable.ReadImportAddresses(inputFile, optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
                Console.WriteLine("Import Address Table");
                Console.WriteLine("====================");
                foreach (var importAddress in importAddresses)
                {
                    Console.WriteLine("   Import Address {0:X}", importAddress);
                }

                //CLR Header
                inputFile.Position = CLRHeader.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
                WriteStartingAddress(inputFile);
                CLRHeader?
                    clrHeader = inputFile.
                        ReadStructure<CLRHeader>();
                Console.WriteLine(
                    clrHeader.ToString());

                //Strong Name Signature
                StrongNameSignature? strongNameSignature;
                if (clrHeader.Value.StrongNameSignature != 0)
                {
                    inputFile.Position = StrongNameSignature.StartingPosition(clrHeader.Value, sectionTables.Values.ToList());
                    WriteStartingAddress(inputFile);
                    strongNameSignature = inputFile.
                            ReadStructure<StrongNameSignature>();
                    Console.WriteLine(
                        strongNameSignature.ToString());
                }

                //IL Code and Managed Structure Exception Handling Tables 
                ExceptionHandlingTable? exceptionHandlingTable;
                if (optionalHeaderDataDirectories.Value.ExceptionTable != 0)
                {
                    inputFile.Position = ExceptionHandlingTable.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
                    WriteStartingAddress(inputFile);
                    exceptionHandlingTable = inputFile.
                            ReadStructure<ExceptionHandlingTable>();
                    Console.WriteLine(
                        exceptionHandlingTable.ToString());
                }

                //Debug Directory
                DebugDirectory? debugDirectory;
                CodeViewHeader? codeViewHeader;
                if (optionalHeaderDataDirectories.Value.Debug != 0)
                {
                    inputFile.Position = DebugDirectory.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
                    WriteStartingAddress(inputFile);
                    debugDirectory = inputFile.ReadStructure<DebugDirectory>();
                    Console.WriteLine(
                        debugDirectory.ToString());

                    inputFile.Position = CodeViewHeader.StartingPosition(debugDirectory.Value, sectionTables.Values.ToList());
                    WriteStartingAddress(inputFile);
                    codeViewHeader = inputFile.ReadStructure<CodeViewHeader>();
                    Console.WriteLine(
                        codeViewHeader.ToString());
                }

                GeneralMetadataHeader generalMetadataHeader = new GeneralMetadataHeader(clrHeader.Value, sectionTables.Values.ToList(), inputFile);
                WriteStartingAddress(generalMetadataHeader.startingAddress);
                Console.WriteLine(
                    generalMetadataHeader.ToString());
            }
        }

        private static void WriteStartingAddress(FileStream inputFile)
        {
            WriteStartingAddress(inputFile.Position);
        }

        private static void WriteStartingAddress(long startingAddress)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting Address: 0x{0:X}", startingAddress);
            Console.ForegroundColor = defaultForegroundColor;
        }

        public static string HexDump(byte[] bytes, int bytesPerLine = 16)
        {
            if (bytes == null) return "<null>";
            int bytesLength = bytes.Length;

            char[] HexChars = "0123456789ABCDEF".ToCharArray();

            int firstHexColumn =
                  8                   // 8 characters for the address
                + 3;                  // 3 spaces

            int firstCharColumn = firstHexColumn
                + bytesPerLine * 3       // - 2 digit for the hexadecimal value and 1 space
                + (bytesPerLine - 1) / 8 // - 1 extra space every 8 characters from the 9th
                + 2;                  // 2 spaces 

            int lineLength = firstCharColumn
                + bytesPerLine           // - characters to show the ascii value
                + Environment.NewLine.Length; // Carriage return and line feed (should normally be 2)

            char[] line = (new String(' ', lineLength - Environment.NewLine.Length) + Environment.NewLine).ToCharArray();
            int expectedLines = (bytesLength + bytesPerLine - 1) / bytesPerLine;
            StringBuilder result = new StringBuilder(expectedLines * lineLength);

            for (int i = 0; i < bytesLength; i += bytesPerLine)
            {
                line[0] = HexChars[(i >> 28) & 0xF];
                line[1] = HexChars[(i >> 24) & 0xF];
                line[2] = HexChars[(i >> 20) & 0xF];
                line[3] = HexChars[(i >> 16) & 0xF];
                line[4] = HexChars[(i >> 12) & 0xF];
                line[5] = HexChars[(i >> 8) & 0xF];
                line[6] = HexChars[(i >> 4) & 0xF];
                line[7] = HexChars[(i >> 0) & 0xF];

                int hexColumn = firstHexColumn;
                int charColumn = firstCharColumn;

                for (int j = 0; j < bytesPerLine; j++)
                {
                    if (j > 0 && (j & 7) == 0) hexColumn++;
                    if (i + j >= bytesLength)
                    {
                        line[hexColumn] = ' ';
                        line[hexColumn + 1] = ' ';
                        line[charColumn] = ' ';
                    }
                    else
                    {
                        byte b = bytes[i + j];
                        line[hexColumn] = HexChars[(b >> 4) & 0xF];
                        line[hexColumn + 1] = HexChars[b & 0xF];
                        line[charColumn] = (b < 32 ? '·' : (char)b);
                    }
                    hexColumn += 3;
                    charColumn++;
                }
                result.Append(line);
            }
            return result.ToString();
        }
    }
}