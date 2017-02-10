﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct MSDOS20Section
    {
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
