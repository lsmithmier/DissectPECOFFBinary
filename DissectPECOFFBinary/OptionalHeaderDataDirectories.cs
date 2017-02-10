﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct OptionalHeaderDataDirectories
    {
        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 ExportTable;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 ImportTable;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 ResourceTable;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 ExceptionTable;

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 CertificateTable;

        [FieldOffset(0x28)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 BaseRelocationTable;

        [FieldOffset(0x30)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 Debug;

        [FieldOffset(0x38)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 Architecture;

        [FieldOffset(0x40)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 GlobalPtr;

        [FieldOffset(0x48)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 TLSTable;

        [FieldOffset(0x50)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 LoadConfigTable;

        [FieldOffset(0x58)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 BoundImport;

        [FieldOffset(0x60)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 IAT;

        [FieldOffset(0x68)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 DelayImportDescriptor;

        [FieldOffset(0x70)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 CLRRuntimeHeader;

        [FieldOffset(0x78)]
        [MarshalAs(UnmanagedType.U8)]
        UInt64 Reserved;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("ExportTable: 0x{0:X}", ExportTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("ImportTable: 0x{0:X}", ImportTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("ResourceTable: 0x{0:X}",
                ResourceTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("ExceptionTable: 0x{0:X}",
                ExceptionTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("CertificateTable: 0x{0:X}",
                CertificateTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("BaseRelocationTable: 0x{0:X}",
                BaseRelocationTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("Debug: 0x{0:X}", Debug);
            returnValue.AppendLine();
            returnValue.AppendFormat("Architecture: 0x{0:X}", Architecture);
            returnValue.AppendLine();
            returnValue.AppendFormat("GlobalPtr: 0x{0:X}", GlobalPtr);
            returnValue.AppendLine();
            returnValue.AppendFormat("TLSTable: 0x{0:X}", TLSTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("LoadConfigTable: 0x{0:X}",
                LoadConfigTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("BoundImport: 0x{0:X}", BoundImport);
            returnValue.AppendLine();
            returnValue.AppendFormat("IAT: 0x{0:X}", IAT);
            returnValue.AppendLine();
            returnValue.AppendFormat("DelayImportDescriptor: 0x{0:X}",
                DelayImportDescriptor);
            returnValue.AppendLine();
            returnValue.AppendFormat("CLRRuntimeHeader: 0x{0:X}",
                CLRRuntimeHeader);
            returnValue.AppendLine();
            returnValue.AppendFormat("Reserved: 0x{0:X}", Reserved);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
