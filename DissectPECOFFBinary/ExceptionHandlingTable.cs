using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ExceptionHandlingTable : IPECOFFPart
    {
        public static long StartingPosition(OptionalHeaderDataDirectories optionalHeaderDataDirectories, List<SectionTable> sectionTables)
        {
            foreach (var sectionTable in sectionTables)
            {
                if (optionalHeaderDataDirectories.ExceptionTableAddress >= sectionTable.VirtualAddress
                    &&
                  optionalHeaderDataDirectories.ExceptionTableAddress <= sectionTable.VirtualAddress + sectionTable.VirtualSize)
                {
                    return sectionTable.PointerToRawData + optionalHeaderDataDirectories.ExceptionTableAddress - sectionTable.VirtualAddress;
                }
            }
            throw new ArgumentOutOfRangeException("OptionalHeaderDataDirectories Exception Handling Table Address", "The OptionalHeaderDataDirectories Exception Handling Table Address did not fall within the address range of any of the Section Tables");
        }
        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Exception Handling Table: {0}", "todo");
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
