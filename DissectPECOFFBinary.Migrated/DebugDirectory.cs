using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct DebugDirectory : IPECOFFPart
    {
        public static long StartingPosition(OptionalHeaderDataDirectories optionalHeaderDataDirectories, List<SectionTable> sectionTables)
        {
            foreach (var sectionTable in sectionTables)
            {
                if (optionalHeaderDataDirectories.DebugAddress >= sectionTable.VirtualAddress
                    &&
                  optionalHeaderDataDirectories.DebugAddress <= sectionTable.VirtualAddress + sectionTable.VirtualSize)
                {
                    return sectionTable.PointerToRawData + optionalHeaderDataDirectories.DebugAddress - sectionTable.VirtualAddress;
                }
            }
            throw new ArgumentOutOfRangeException("OptionalHeaderDataDirectories Exception Handling Table Address", "The OptionalHeaderDataDirectories Exception Handling Table Address did not fall within the address range of any of the Section Tables");
        }


        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Characteristics;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 TimeDateStamp;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MajorVersion;

        [FieldOffset(0xA)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MinorVersion;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Type;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfData;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 AddressOfRawData;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 PointerToRawData;


        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Characteristics: 0x{0:X}", Characteristics);
            returnValue.AppendLine();
            returnValue.AppendFormat("TimeDateStamp: 0x{0:X}", TimeDateStamp);
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorVersion: {0}", MajorVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorVersion: {0}", MinorVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("Type: 0x{0:X}", Type);
            returnValue.AppendLine();
            returnValue.AppendFormat("Type (decoded): {0:X}", DecodeType(Type));
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfData: 0x{0:X}", SizeOfData);
            returnValue.AppendLine();
            returnValue.AppendFormat("AddressOfRawData: 0x{0:X}", AddressOfRawData);
            returnValue.AppendLine();
            returnValue.AppendFormat("PointerToRawData: 0x{0:X}", PointerToRawData);
            returnValue.AppendLine();
            return returnValue.ToString();
        }

        private string DecodeType(uint type)
        {
            string decodedType = string.Empty;
            switch (type)
            {
                case 0:
                    decodedType = "IMAGE_DEBUG_TYPE_UNKNOWN"; //Unknown value, ignored by all tools.
                    break;
                case 1:
                    decodedType = "IMAGE_DEBUG_TYPE_COFF"; //COFF debugging information(line numbers, symbol table, and string table). This type of debugging information is also pointed to by fields in the file headers.
                    break;
                case 2:
                    decodedType = "IMAGE_DEBUG_TYPE_CODEVIEW"; //CodeView debugging information.The format of the data block is described by the CodeView 4.0 specification.
                    break;
                case 3:
                    decodedType = "IMAGE_DEBUG_TYPE_FPO"; //Frame pointer omission(FPO) information.This information tells the debugger how to interpret nonstandard stack frames, which use the EBP register for a purpose other than as a frame pointer.
                    break;
                case 4:
                    decodedType = "IMAGE_DEBUG_TYPE_MISC"; //Miscellaneous information.
                    break;
                case 5:
                    decodedType = "IMAGE_DEBUG_TYPE_EXCEPTION"; //Exception information.
                    break;
                case 6:
                    decodedType = "IMAGE_DEBUG_TYPE_FIXUP"; //Fixup information.
                    break;
                case 7:
                    decodedType = "IMAGE_DEBUG_TYPE_OMAP_TO_SRC"; //The mapping from an RVA in image to an RVA in source image.
                    break;
                case 8:
                    decodedType = "IMAGE_DEBUG_TYPE_OMAP_FROM_SRC"; //The mapping from an RVA in source image to an RVA in image.
                    break;
                case 9:
                    decodedType = "IMAGE_DEBUG_TYPE_BORLAND"; //Borland debugging information.
                    break;
                case 10:
                    decodedType = "IMAGE_DEBUG_TYPE_RESERVED10"; //Reserved.
                    break;
                case 11:
                    decodedType = "IMAGE_DEBUG_TYPE_CLSID"; //Reserved.
                    break;
                case 16:
                    decodedType = "IMAGE_DEBUG_TYPE_REPRO"; //PE determinism or reproducibility.
                    break;
                default:
                    decodedType = "Undefined"; //Should not be hit
                    break;
            }
            return decodedType;
        }
    }
}
