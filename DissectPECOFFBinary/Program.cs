using DissectPECOFFBinary;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        DissectFile(args[0]);
    }

    private static void DissectFile(string fileName)
    {
        Dictionary<string, SectionTable> sectionTables =
            new Dictionary<string, SectionTable>();
        using (FileStream inputFile = File.OpenRead(fileName))
        {
            WriteStartingAddress("MSDOS20Section",inputFile);
            MSDOS20Section? msdos20Section =
                inputFile.ReadStructure<MSDOS20Section>();
            Console.WriteLine(msdos20Section.ToString());
            WriteStartingAddress("PESignature",inputFile);
            PESignature? peSignature =
                inputFile.ReadStructure<PESignature>();
            Console.WriteLine(peSignature.ToString());
            WriteStartingAddress("COFFHeader",inputFile);
            COFFHeader? coffHeader =
                inputFile.ReadStructure<COFFHeader>();
            Console.WriteLine(coffHeader.ToString());
            WriteStartingAddress("COFFOptionalHeaderStandardFields",inputFile);
            COFFOptionalHeaderStandardFields?
                coffOptionalHeaderStandardFields = inputFile.
                    ReadStructure<COFFOptionalHeaderStandardFields>();
            Console.WriteLine(
                coffOptionalHeaderStandardFields.ToString());
            if (coffOptionalHeaderStandardFields.Value.Magic == 0x10b)
            {
                WriteStartingAddress("OptionalHeaderWindowsSpecificPE32",inputFile);
                OptionalHeaderWindowsSpecificPE32?
                    optionalHeaderWindowsSpecificPE32 = inputFile.
                        ReadStructure<OptionalHeaderWindowsSpecificPE32>();
                Console.WriteLine(
                    optionalHeaderWindowsSpecificPE32.ToString());
            }
            else
            {
                WriteStartingAddress("OptionalHeaderWindowsSpecificPE32Plus",inputFile);
                OptionalHeaderWindowsSpecificPE32Plus?
                    optionalHeaderWindowsSpecificPE32Plus =
                    inputFile.ReadStructure<
                        OptionalHeaderWindowsSpecificPE32Plus>();
                Console.WriteLine(
                    optionalHeaderWindowsSpecificPE32Plus.ToString());
            }
            WriteStartingAddress("OptionalHeaderDataDirectories",inputFile);
            OptionalHeaderDataDirectories?
                optionalHeaderDataDirectories = inputFile.
                    ReadStructure<OptionalHeaderDataDirectories>();
            Console.WriteLine(
                optionalHeaderDataDirectories.ToString());
            for (int i = 0; i < coffHeader.Value.NumberOfSections; i++)
            {
                WriteStartingAddress(string.Format("OptionalHeaderDataDirectories {0}",i),inputFile);
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
                OrderBy(x => x.Value.PointerToRawData))
            {
                byte[] buffer = new byte[sectionTable.Value.VirtualSize];
                inputFile.Position = sectionTable.Value.PointerToRawData;
                WriteStartingAddress(sectionTable.Key, inputFile);
                inputFile.Read(buffer, 0,
                    (int)sectionTable.Value.VirtualSize);
                Console.WriteLine("Raw dump of section {0}", sectionTable.Key);
                Console.WriteLine(HexDump(buffer));
            }

            DissectTextSection(sectionTables, inputFile, optionalHeaderDataDirectories);
        }
    }

    private static void DissectTextSection(Dictionary<string, SectionTable> sectionTables, FileStream inputFile, OptionalHeaderDataDirectories? optionalHeaderDataDirectories)
    {
        //Import Address Table
        var importAddresses = ImportAddressTable.ReadImportAddresses(inputFile, optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
        WriteStartingAddress("ImportAddressTable", inputFile);
        foreach (var importAddress in importAddresses)
        {
            Console.WriteLine("   Import Address {0:X}", importAddress);
        }

        //CLR Header
        inputFile.Position = CLRHeader.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
        WriteStartingAddress("CLRHeader",inputFile);
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
            WriteStartingAddress("StrongNameSignature",inputFile);
            strongNameSignature = inputFile.
                    ReadStructure<StrongNameSignature>();
            Console.WriteLine(
                strongNameSignature.ToString());
        }

        //IL Code and Managed Structure Exception Handling Tables 
        ExceptionHandlingTable? exceptionHandlingTable;
        if (optionalHeaderDataDirectories.Value.ExceptionTableAddress != 0)
        {
            inputFile.Position = ExceptionHandlingTable.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
            WriteStartingAddress("ExceptionHandlingTable",inputFile);
            exceptionHandlingTable = inputFile.
                    ReadStructure<ExceptionHandlingTable>();
            Console.WriteLine(
                exceptionHandlingTable.ToString());
        }

        //Debug Directory
        DebugDirectory? debugDirectory;
        CodeViewHeader? codeViewHeader;
        if (optionalHeaderDataDirectories.Value.DebugAddress != 0)
        {
            inputFile.Position = DebugDirectory.StartingPosition(optionalHeaderDataDirectories.Value, sectionTables.Values.ToList());
            WriteStartingAddress("DebugDirectory",inputFile);
            debugDirectory = inputFile.ReadStructure<DebugDirectory>();
            Console.WriteLine(
                debugDirectory.ToString());

            inputFile.Position = CodeViewHeader.StartingPosition(debugDirectory.Value, sectionTables.Values.ToList());
            WriteStartingAddress("CodeViewHeader",inputFile);
            codeViewHeader = inputFile.ReadStructure<CodeViewHeader>();
            Console.WriteLine(
                codeViewHeader.ToString());
        }

        GeneralMetadataHeader generalMetadataHeader =
            new GeneralMetadataHeader(clrHeader.Value, sectionTables.Values.ToList(), inputFile);
        WriteStartingAddress("GeneralMetadataHeader",generalMetadataHeader.startingAddress);
        Console.WriteLine(
            generalMetadataHeader.ToString());

        inputFile.Position = MetadataStorageHeader.StartingPosition(generalMetadataHeader);
        WriteStartingAddress("MetadataStorageHeader",inputFile);
        MetadataStorageHeader? metadataStorageHeader =
            inputFile.ReadStructure<MetadataStorageHeader>();
        Console.WriteLine(metadataStorageHeader.ToString());

        Dictionary<string, MetadataStreamHeader> streams = new Dictionary<string, MetadataStreamHeader>();
        for (int i = 0; i < metadataStorageHeader.Value.iStreams; i++)
        {
            WriteStartingAddress("MetadataStreamHeader",inputFile);
            MetadataStreamHeader
                streamHeader = new MetadataStreamHeader(inputFile);
            Console.WriteLine(
                streamHeader.ToString());
            streams.Add(streamHeader.rcName, streamHeader);
        }
    }

    private static void WriteStartingAddress(string sectionName, FileStream inputFile)
    {
        WriteStartingAddress(sectionName, inputFile.Position);
    }

    private static void WriteStartingAddress(string sectionName, long startingAddress)
    {
        var defaultForegroundColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{1} - Starting Address: 0x{0:X}", startingAddress, sectionName);
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