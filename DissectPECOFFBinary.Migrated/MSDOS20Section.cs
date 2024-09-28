using System;
using System.Runtime.InteropServices;
using System.Text;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MSDOS20Section : IPECOFFPart
    {
        public static UInt32 StartingPosition() {
            return 0;
        }

        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x4)]
        public string Signature;

        [FieldOffset(4)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x37)]
        byte[] MSDOSEXEHeader;

        [FieldOffset(0x3C)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 OffsetToPEHeader;

        [FieldOffset(0x40)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x40)]
        byte[] MSDOSStub;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Signature: {0}", Signature);
            returnValue.AppendLine();
            returnValue.AppendFormat("OffsetToPEHeader: {0:X}", OffsetToPEHeader);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
