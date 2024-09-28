using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MetadataStorageHeader : IPECOFFPart
    {
        public static long StartingPosition(GeneralMetadataHeader generalMetadataHeader)
        {
            return generalMetadataHeader.startingAddress + 0x10 + 
                                generalMetadataHeader.iVersionString;
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U1)]
        public Byte fFlags;

        [FieldOffset(0x1)]
        [MarshalAs(UnmanagedType.U1)]
        public Byte padding;

        [FieldOffset(0x2)]
        [MarshalAs(UnmanagedType.I2)]
        public Int16 iStreams;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("fFlage: 0x{0:X}", fFlags);
            returnValue.AppendLine();
            returnValue.AppendFormat("padding: 0x{0:X}", padding);
            returnValue.AppendLine();
            returnValue.AppendFormat("iStreams: {0}", iStreams);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
