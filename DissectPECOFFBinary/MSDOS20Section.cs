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

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 Sig;

        public string Signature => IPECOFFPart.ConvertUInt16ToString(Sig);

        [FieldOffset(0x2)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CBLP;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CP;

        [FieldOffset(0x6)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CRLC;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CPARHDR;

        [FieldOffset(0xa)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MINALLOC;

        [FieldOffset(0xc)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MAXALLOC;

        [FieldOffset(0xe)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 SS;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 SP;

        [FieldOffset(0x12)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CSUM;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 IP;

        [FieldOffset(0x16)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 CS;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 LFARLC;

        [FieldOffset(0x1a)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 OVNO;

        [FieldOffset(0x1c)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED1;

        [FieldOffset(0x1e)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED2;

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED3;

        [FieldOffset(0x22)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED4;

        [FieldOffset(0x24)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 OEMID;

        [FieldOffset(0x26)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 OEMINFO;

        [FieldOffset(0x28)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED5;

        [FieldOffset(0x2a)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED6;

        [FieldOffset(0x2c)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED7;

        [FieldOffset(0x2e)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED8;

        [FieldOffset(0x30)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED9;

        [FieldOffset(0x32)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED10;

        [FieldOffset(0x34)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED11;

        [FieldOffset(0x36)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED12;

        [FieldOffset(0x38)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED13;

        [FieldOffset(0x3a)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 RESERVED14;

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
