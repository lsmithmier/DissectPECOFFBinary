using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CodeViewHeader : IPECOFFPart
    {
        public static long StartingPosition(DebugDirectory debugDirectory, 
                                            List<SectionTable> sectionTables)
        {
            return debugDirectory.PointerToRawData;
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x5)]
        public string CvSignature;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.I4)]
        public Int32 a;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.I2)]
        public Int16 b;

        [FieldOffset(0xA)]
        [MarshalAs(UnmanagedType.I2)]
        public Int16 c;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] d;

        public Guid Signature
        {
            get { return d==null?Guid.Empty:new Guid(a, b, c, d); }
        }

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Age;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x104)]
        public string PdbFileName;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("CvSignature: {0}", CvSignature);
            returnValue.AppendLine();
            returnValue.AppendFormat("Signature: {0}", Signature);
            returnValue.AppendLine();
            returnValue.AppendFormat("Age: 0x{0:X}", Age);
            returnValue.AppendLine();
            returnValue.AppendFormat("PdbFileName: {0}", PdbFileName);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
