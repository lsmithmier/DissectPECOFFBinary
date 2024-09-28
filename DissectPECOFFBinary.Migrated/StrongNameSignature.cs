using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct StrongNameSignature : IPECOFFPart
    {
        public static long StartingPosition(CLRHeader clrHeader, List<SectionTable> sectionTables)
        {
            foreach (var sectionTable in sectionTables)
            {
                if (clrHeader.StrongNameSignatureAddress >= sectionTable.VirtualAddress
                    &&
                  clrHeader.StrongNameSignatureAddress <= sectionTable.VirtualAddress + sectionTable.VirtualSize)
                {
                    return sectionTable.PointerToRawData + clrHeader.StrongNameSignatureAddress - sectionTable.VirtualAddress;
                }
            }
            throw new ArgumentOutOfRangeException("CLRHeader Strong Name Signature Address", "The CLRHeader Strong Name Signature Address did not fall within the address range of any of the Section Tables");
        }

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Strong Name Signature: {0}", "todo");
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
