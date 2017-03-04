using System;
using System.Collections.Generic;
using System.IO;

namespace DissectPECOFFBinary
{
    public class ImportAddressTable : IPECOFFPart
    {
        public static long StartingPosition(OptionalHeaderDataDirectories optionalHeaderDataDirectories, List<SectionTable> sectionTables)
        {
            foreach (var sectionTable in sectionTables)
            {
                if(optionalHeaderDataDirectories.IATAddress >= sectionTable.VirtualAddress 
                    &&
                  optionalHeaderDataDirectories.IATAddress <= sectionTable.VirtualAddress + sectionTable.VirtualSize)
                {
                    return sectionTable.PointerToRawData + sectionTable.VirtualAddress - optionalHeaderDataDirectories.IATAddress;
                }
            }
            throw new ArgumentOutOfRangeException("OptionalHeaderDataDirectories IAT Address", "The OptionalHeaderDataDirectories IAT Address did not fall within the address range of any of the Section Tables");
        }

        public static List<UInt32> ReadImportAddresses(FileStream inputFile, OptionalHeaderDataDirectories optionalHeaderDataDirectories, List<SectionTable> sectionTables)
        {
            inputFile.Position = ImportAddressTable.StartingPosition(optionalHeaderDataDirectories, sectionTables);
            var importAddresses = new List<UInt32>();
            for (int i = 0; i < optionalHeaderDataDirectories.IATSize; i++)
            {
                importAddresses.Add(inputFile.ReadStructure<UInt32>().Value);
            }
            return importAddresses;
        }
    }
}
