using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct COFFOptionalHeaderStandardFields : IPECOFFPart
    {
        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 Magic;

        [FieldOffset(0x2)]
        [MarshalAs(UnmanagedType.U1)]
        byte MajorLinkerVersion;

        [FieldOffset(0x3)]
        [MarshalAs(UnmanagedType.U1)]
        byte MinorLinkerVersion;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 SizeOfCode;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 SizeOfInitializedData;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 SizeOfUninitializedData;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 AddressOfEntryPoint;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 BaseOfCode;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Magic: 0x{0:X}", Magic);
            returnValue.AppendLine();
            returnValue.AppendFormat("Magic (decoded): {0}", 
                DecodeMagic(Magic));
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorLinkerVersion: {0}", 
                MajorLinkerVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorLinkerVersion: {0}", 
                MinorLinkerVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfCode: {0}", SizeOfCode);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfInitializedData: {0}", 
                SizeOfInitializedData);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfUninitializedData: {0}",
                SizeOfUninitializedData);
            returnValue.AppendLine();
            returnValue.AppendFormat("AddressOfEntryPoint: 0x{0:X}",
                AddressOfEntryPoint);
            returnValue.AppendLine();
            returnValue.AppendFormat("BaseOfCode: 0x{0:X}", BaseOfCode);
            returnValue.AppendLine();
            return returnValue.ToString();
        }

        private string DecodeMagic(ushort magic)
        {
            string returnValue = string.Empty;
            switch (magic)
            {
                case 0x10b:
                    returnValue = "PE32";
                    break;
                case 0x20b:
                    returnValue = "PE32+";
                    break;
                default:
                    returnValue = "Undefined";
                    break;
            }
            return returnValue;
        }
    }
}
