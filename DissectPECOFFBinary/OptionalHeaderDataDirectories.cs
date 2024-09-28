using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct OptionalHeaderDataDirectories : IPECOFFPart
    {
        public static long StartingPosition(MSDOS20Section msdos20Section, COFFOptionalHeaderStandardFields coffOptionalHeaderStandardFields)
        {
            if (coffOptionalHeaderStandardFields.Magic == 0x10b) {
                return msdos20Section.OffsetToPEHeader
                    + (Int64)Marshal.SizeOf<PESignature>()
                    + (Int64)Marshal.SizeOf<COFFHeader>()
                    + (Int64)Marshal.SizeOf<COFFOptionalHeaderStandardFields>()
                    + (Int64)Marshal.SizeOf<OptionalHeaderWindowsSpecificPE32>();
            } else
            {
                return msdos20Section.OffsetToPEHeader
                    + (Int64)Marshal.SizeOf<PESignature>()
                    + (Int64)Marshal.SizeOf<COFFHeader>()
                    + (Int64)Marshal.SizeOf<COFFOptionalHeaderStandardFields>()
                    + (Int64)Marshal.SizeOf<OptionalHeaderWindowsSpecificPE32Plus>();
            }
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ExportTable;

        public UInt32 ExportTableAddress
        {
            get { return (UInt32)(ExportTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 ExportTableSize
        {
            get { return (UInt32)(ExportTable >> 32); }
        }

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ImportTable;

        public UInt32 ImportTableAddress
        {
            get { return (UInt32)(ImportTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 ImportTableSize
        {
            get { return (UInt32)(ImportTable >> 32); }
        }

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ResourceTable;

        public UInt32 ResourceTableAddress
        {
            get { return (UInt32)(ResourceTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 ResourceTableSize
        {
            get { return (UInt32)(ResourceTable >> 32); }
        }

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ExceptionTable;

        public UInt32 ExceptionTableAddress
        {
            get { return (UInt32)(ExceptionTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 ExceptionTableSize
        {
            get { return (UInt32)(ExceptionTable >> 32); }
        }

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 CertificateTable;

        public UInt32 CertificateTableAddress
        {
            get { return (UInt32)(CertificateTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 CertificateTableSize
        {
            get { return (UInt32)(CertificateTable >> 32); }
        }

        [FieldOffset(0x28)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 BaseRelocationTable;

        public UInt32 BaseRelocationTableAddress
        {
            get { return (UInt32)(BaseRelocationTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 BaseRelocationTableSize
        {
            get { return (UInt32)(BaseRelocationTable >> 32); }
        }

        [FieldOffset(0x30)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Debug;

        public UInt32 DebugAddress
        {
            get { return (UInt32)(Debug & 0x00000000FFFFFFFF); }
        }

        public UInt32 DebugSize
        {
            get { return (UInt32)(Debug >> 32); }
        }

        [FieldOffset(0x38)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ArchitectureData;

        public UInt32 ArchitectureDataAddress
        {
            get { return (UInt32)(ArchitectureData & 0x00000000FFFFFFFF); }
        }

        public UInt32 ArchitectureDataSize
        {
            get { return (UInt32)(ArchitectureData >> 32); }
        }

        [FieldOffset(0x40)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 GlobalPtrAndReserve;

        public UInt32 GlobalPtr
        {
            get { return (UInt32)(GlobalPtrAndReserve & 0x00000000FFFFFFFF); }
        }

        public UInt32 Reserve1
        {
            get { return (UInt32)(GlobalPtrAndReserve >> 32); }
        }

        [FieldOffset(0x48)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 TLSTable;

        public UInt32 TLSTableAddress
        {
            get { return (UInt32)(TLSTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 TLSTableSize
        {
            get { return (UInt32)(TLSTable >> 32); }
        }

        [FieldOffset(0x50)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 LoadConfigTable;

        public UInt32 LoadConfigTableAddress
        {
            get { return (UInt32)(LoadConfigTable & 0x00000000FFFFFFFF); }
        }

        public UInt32 LoadConfigTableSize
        {
            get { return (UInt32)(LoadConfigTable >> 32); }
        }

        [FieldOffset(0x58)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 BoundImport;

        public UInt32 BoundImportAddress
        {
            get { return (UInt32)(BoundImport & 0x00000000FFFFFFFF); }
        }

        public UInt32 BoundImportSize
        {
            get { return (UInt32)(BoundImport >> 32); }
        }

        [FieldOffset(0x60)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 IAT;

        public UInt32 IATAddress
        {
            get { return (UInt32)(IAT & 0x00000000FFFFFFFF); }
        }

        public UInt32 IATSize
        {
            get { return (UInt32)(IAT >> 32); }
        }

        [FieldOffset(0x68)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 DelayImportDescriptor;

        public UInt32 DelayImportDescriptorAddress
        {
            get { return (UInt32)(DelayImportDescriptor & 0x00000000FFFFFFFF); }
        }

        public UInt32 DelayImportDescriptorSize
        {
            get { return (UInt32)(DelayImportDescriptor >> 32); }
        }

        [FieldOffset(0x70)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 CLRRuntimeHeader;

        public UInt32 CLRRuntimeHeaderAddress
        {
            get { return (UInt32)(CLRRuntimeHeader & 0x00000000FFFFFFFF); }
        }

        public UInt32 CLRRuntimeHeaderSize
        {
            get { return (UInt32)(CLRRuntimeHeader >> 32); }
        }

        [FieldOffset(0x78)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Reserved;

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
            returnValue.AppendFormat("Architecture: 0x{0:X}", ArchitectureData);
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
