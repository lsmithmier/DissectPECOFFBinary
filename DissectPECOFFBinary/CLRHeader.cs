using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CLRHeader
    {
        public static long StartingPosition(OptionalHeaderDataDirectories optionalHeaderDataDirectories, List<SectionTable> sectionTables)
        {
            foreach (var sectionTable in sectionTables)
            {
                if (optionalHeaderDataDirectories.CLRRuntimeHeaderAddress >= sectionTable.VirtualAddress
                    &&
                  optionalHeaderDataDirectories.CLRRuntimeHeaderAddress <= sectionTable.VirtualAddress + sectionTable.VirtualSize)
                {
                    return sectionTable.PointerToRawData + optionalHeaderDataDirectories.CLRRuntimeHeaderAddress - sectionTable.VirtualAddress;
                }
            }
            throw new ArgumentOutOfRangeException("OptionalHeaderDataDirectories CLR Runtime Header Address", "The OptionalHeaderDataDirectories CLR Runtime Header Address did not fall within the address range of any of the Section Tables");
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Cb;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MajorRuntimeVersion;

        [FieldOffset(0x6)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MinorRuntimeVersion;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Metadata;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Flags;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 EntryPoint;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Resources;

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 StrongNameSignature;

        [FieldOffset(0x28)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 CodeManagerTable;

        [FieldOffset(0x30)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 VTableFixups;

        [FieldOffset(0x38)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ExportAddressTableJumps;

        [FieldOffset(0x40)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 ManagedNativeHeader;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Cb: {0:X}", Cb);
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorRuntimeVersion: {0:X}", MajorRuntimeVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorRuntimeVersion: {0:X}", MinorRuntimeVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("Metadata: {0:X}", Metadata);
            returnValue.AppendLine();
            returnValue.AppendFormat("Flags: {0:X}", Flags);
            returnValue.AppendLine();
            returnValue.AppendFormat("EntryPoint: {0:X}", EntryPoint);
            returnValue.AppendLine();
            returnValue.AppendFormat("Resources: {0:X}", Resources);
            returnValue.AppendLine();
            returnValue.AppendFormat("StrongNameSignature: {0:X}", StrongNameSignature);
            returnValue.AppendLine();
            returnValue.AppendFormat("CodeManagerTable: {0:X}", CodeManagerTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("VTableFixups: {0:X}", VTableFixups);
            returnValue.AppendLine();
            returnValue.AppendFormat("ExportAddressTableJumps: {0:X}", ExportAddressTableJumps);
            returnValue.AppendLine();
            returnValue.AppendFormat("ManagedNativeHeader: {0:X}", ManagedNativeHeader);
            returnValue.AppendLine();
            return returnValue.ToString();
        }

    }
}
