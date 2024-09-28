using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SectionTable : IPECOFFPart
    {
        public static long StartingPosition(MSDOS20Section msdos20Section, COFFOptionalHeaderStandardFields coffOptionalHeaderStandardFields)
        {
            if (coffOptionalHeaderStandardFields.Magic == 0x10b)
            {
                return msdos20Section.OffsetToPEHeader
                    + (Int64)Marshal.SizeOf<PESignature>()
                    + (Int64)Marshal.SizeOf<COFFHeader>()
                    + (Int64)Marshal.SizeOf<COFFOptionalHeaderStandardFields>()
                    + (Int64)Marshal.SizeOf<OptionalHeaderWindowsSpecificPE32>()
                    +(Int64)Marshal.SizeOf<OptionalHeaderDataDirectories>();
            }
            else
            {
                return msdos20Section.OffsetToPEHeader
                    + (Int64)Marshal.SizeOf<PESignature>()
                    + (Int64)Marshal.SizeOf<COFFHeader>()
                    + (Int64)Marshal.SizeOf<COFFOptionalHeaderStandardFields>()
                    + (Int64)Marshal.SizeOf<OptionalHeaderWindowsSpecificPE32Plus>()
                    + (Int64)Marshal.SizeOf<OptionalHeaderDataDirectories>();
            }
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x8)]
        public string Name;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 VirtualSize;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 VirtualAddress;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfRawData;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 PointerToRawData;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 PointerToRelocations;

        [FieldOffset(0x1C)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 PointerToLinenumbers;

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 NumberOfRelocations;

        [FieldOffset(0x22)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 NumberOfLinenumbers;

        [FieldOffset(0x24)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Characteristics;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("Name: {0}", Name);
            returnValue.AppendLine();
            returnValue.AppendFormat("VirtualSize: {0}", VirtualSize);
            returnValue.AppendLine();
            returnValue.AppendFormat("VirtualAddress: 0x{0:X}",
                VirtualAddress);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfRawData: {0}", SizeOfRawData);
            returnValue.AppendLine();
            returnValue.AppendFormat("PointerToRawData: 0x{0:X}",
                PointerToRawData);
            returnValue.AppendLine();
            returnValue.AppendFormat("PointerToRelocations: 0x{0:X}",
                PointerToRelocations);
            returnValue.AppendLine();
            returnValue.AppendFormat("PointerToLinenumbers: 0x{0:X}",
                PointerToLinenumbers);
            returnValue.AppendLine();
            returnValue.AppendFormat("NumberOfRelocations: {0}",
                NumberOfRelocations);
            returnValue.AppendLine();
            returnValue.AppendFormat("NumberOfLinenumbers: {0}",
                NumberOfLinenumbers);
            returnValue.AppendLine();
            returnValue.AppendFormat("Characteristics: 0x{0:X}",
                Characteristics);
            returnValue.AppendLine();
            returnValue.AppendFormat("Characteristics (decoded): {0}",
                DecodeCharacteristics(Characteristics));
            returnValue.AppendLine();
            return returnValue.ToString();
        }

        private string DecodeCharacteristics(uint characteristics)
        {
            List<string> setCharacteristics = new List<string>();
            if ((characteristics == 0x00000000))
            {
                //                0x00000000  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000001) != 0)
            {
                //                0x00000001  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000002) != 0)
            {
                //                0x00000002  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000004) != 0)
            {
                //                0x00000004  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000008) != 0)
            {
                //IMAGE_SCN_TYPE_NO_PAD   0x00000008  The section should not
                //              be padded to the next boundary.This flag is
                //              obsolete and is replaced by
                //              IMAGE_SCN_ALIGN_1BYTES.This is valid only for
                //              object files.
                setCharacteristics.Add("IMAGE_SCN_TYPE_NO_PAD");
            }
            if ((characteristics & 0x00000010) != 0)
            {
                //  0x00000010  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000020) != 0)
            {
                //IMAGE_SCN_CNT_CODE  0x00000020  The section contains
                //              executable code.
                setCharacteristics.Add("IMAGE_SCN_CNT_CODE");
            }
            if ((characteristics & 0x00000040) != 0)
            {
                //IMAGE_SCN_CNT_INITIALIZED_DATA  0x00000040  The section
                //              contains initialized data.
                setCharacteristics.Add("IMAGE_SCN_CNT_INITIALIZED_DATA");
            }
            if ((characteristics & 0x00000080) != 0)
            {
                //IMAGE_SCN_CNT_UNINITIALIZED_ DATA   0x00000080  The section
                //              contains uninitialized data.
                setCharacteristics.Add("IMAGE_SCN_CNT_UNINITIALIZED_DATA");
            }
            if ((characteristics & 0x00000100) != 0)
            {
                //IMAGE_SCN_LNK_OTHER 0x00000100  Reserved for future use.
                setCharacteristics.Add("IMAGE_SCN_LNK_OTHER");
            }
            if ((characteristics & 0x00000200) != 0)
            {
                //IMAGE_SCN_LNK_INFO  0x00000200  The section contains
                //              comments or other information.The.drectve
                //              section has this type.This is valid for object
                //              files only.
                setCharacteristics.Add("IMAGE_SCN_LNK_INFO");
            }
            if ((characteristics & 0x00000400) != 0)
            {
                // 0x00000400  Reserved for future use.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((characteristics & 0x00000800) != 0)
            {
                //IMAGE_SCN_LNK_REMOVE    0x00000800  The section will not
                //              become part of the image.This is valid only
                //              for object files.
                setCharacteristics.Add("IMAGE_SCN_LNK_REMOVE");
            }
            if ((characteristics & 0x00001000) != 0)
            {
                //IMAGE_SCN_LNK_COMDAT    0x00001000  The section contains
                //              COMDAT data.For more information, see section
                //              5.5.6, “COMDAT Sections(Object Only).” This is
                //              valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_LNK_COMDAT");
            }
            if ((characteristics & 0x00008000) != 0)
            {
                //IMAGE_SCN_GPREL 0x00008000  The section contains data
                //              referenced through the global pointer(GP).
                setCharacteristics.Add("IMAGE_SCN_GPREL");
            }
            if ((characteristics & 0x00020000) != 0)
            {
                //IMAGE_SCN_MEM_PURGEABLE 0x00020000  Reserved for future use.
                setCharacteristics.Add("IMAGE_SCN_MEM_PURGEABLE");
            }
            if ((characteristics & 0x00020000) != 0)
            {
                //IMAGE_SCN_MEM_16BIT 0x00020000  Reserved for future use.
                setCharacteristics.Add("IMAGE_SCN_MEM_16BIT");
            }
            if ((characteristics & 0x00040000) != 0)
            {
                //IMAGE_SCN_MEM_LOCKED    0x00040000  Reserved for future use.
                setCharacteristics.Add("IMAGE_SCN_MEM_LOCKED");
            }
            if ((characteristics & 0x00080000) != 0)
            {
                //IMAGE_SCN_MEM_PRELOAD   0x00080000  Reserved for future
                //              use.
                setCharacteristics.Add("IMAGE_SCN_MEM_PRELOAD");
            }
            if ((characteristics & 0x00100000) != 0)
            {
                //IMAGE_SCN_ALIGN_1BYTES  0x00100000  Align data on a 1 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_1BYTES");
            }
            if ((characteristics & 0x00200000) != 0)
            {
                //IMAGE_SCN_ALIGN_2BYTES  0x00200000  Align data on a 2 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_2BYTES");
            }
            if ((characteristics & 0x00300000) != 0)
            {
                //IMAGE_SCN_ALIGN_4BYTES  0x00300000  Align data on a 4 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_4BYTES");
            }
            if ((characteristics & 0x00400000) != 0)
            {
                //IMAGE_SCN_ALIGN_8BYTES  0x00400000  Align data on an 8 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_8BYTES");
            }
            if ((characteristics & 0x00500000) != 0)
            {
                //IMAGE_SCN_ALIGN_16BYTES 0x00500000  Align data on a 16 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_16BYTES");
            }
            if ((characteristics & 0x00600000) != 0)
            {
                //IMAGE_SCN_ALIGN_32BYTES 0x00600000  Align data on a 32 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_32BYTES");
            }
            if ((characteristics & 0x00700000) != 0)
            {
                //IMAGE_SCN_ALIGN_64BYTES 0x00700000  Align data on a 64 -
                //              byte boundary.Valid only for object files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_64BYTES");
            }
            if ((characteristics & 0x00800000) != 0)
            {
                //IMAGE_SCN_ALIGN_128BYTES    0x00800000  Align data on a
                //              128 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_128BYTES");
            }
            if ((characteristics & 0x00900000) != 0)
            {
                //IMAGE_SCN_ALIGN_256BYTES    0x00900000  Align data on a
                //              256 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_256BYTES");
            }
            if ((characteristics & 0x00A00000) != 0)
            {
                //IMAGE_SCN_ALIGN_512BYTES    0x00A00000  Align data on a
                //              512 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_512BYTES");
            }
            if ((characteristics & 0x00B00000) != 0)
            {
                //IMAGE_SCN_ALIGN_1024BYTES   0x00B00000  Align data on a
                //              1024 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_1024BYTES");
            }
            if ((characteristics & 0x00C00000) != 0)
            {
                //IMAGE_SCN_ALIGN_2048BYTES   0x00C00000  Align data on a
                //              2048 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_2048BYTES");
            }
            if ((characteristics & 0x00D00000) != 0)
            {
                //IMAGE_SCN_ALIGN_4096BYTES   0x00D00000  Align data on a
                //              4096 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_4096BYTES");
            }
            if ((characteristics & 0x00E00000) != 0)
            {
                //IMAGE_SCN_ALIGN_8192BYTES   0x00E00000  Align data on an
                //              8192 - byte boundary.Valid only for object
                //              files.
                setCharacteristics.Add("IMAGE_SCN_ALIGN_8192BYTES");
            }
            if ((characteristics & 0x01000000) != 0)
            {
                //IMAGE_SCN_LNK_NRELOC_OVFL   0x01000000  The section
                //              contains extended relocations.
                setCharacteristics.Add("IMAGE_SCN_LNK_NRELOC_OVFL");
            }
            if ((characteristics & 0x02000000) != 0)
            {
                // IMAGE_SCN_MEM_DISCARDABLE   0x02000000  The section can
                //              be discarded as needed.
                setCharacteristics.Add("IMAGE_SCN_MEM_DISCARDABLE");
            }
            if ((characteristics & 0x04000000) != 0)
            {
                // IMAGE_SCN_MEM_NOT_CACHED    0x04000000  The section
                //              cannot be cached.
                setCharacteristics.Add("IMAGE_SCN_MEM_NOT_CACHED");
            }
            if ((characteristics & 0x08000000) != 0)
            {
                // IMAGE_SCN_MEM_NOT_PAGED 0x08000000  The section is not
                //              pageable.
                setCharacteristics.Add("IMAGE_SCN_MEM_NOT_PAGED");
            }
            if ((characteristics & 0x10000000) != 0)
            {
                // IMAGE_SCN_MEM_SHARED    0x10000000  The section can be
                //              shared in memory.
                setCharacteristics.Add("IMAGE_SCN_MEM_SHARED");
            }
            if ((characteristics & 0x20000000) != 0)
            {
                // IMAGE_SCN_MEM_EXECUTE   0x20000000  The section can be
                //              executed as code.
                setCharacteristics.Add("IMAGE_SCN_MEM_EXECUTE");
            }
            if ((characteristics & 0x40000000) != 0)
            {
                // IMAGE_SCN_MEM_READ  0x40000000  The section can be read.
                setCharacteristics.Add("IMAGE_SCN_MEM_READ");
            }
            if ((characteristics & 0x80000000) != 0)
            {
                // IMAGE_SCN_MEM_WRITE 0x80000000  The section can be
                //              written to.
                setCharacteristics.Add("IMAGE_SCN_MEM_WRITE");
            }
            return string.Join(",", setCharacteristics);
        }
    }
}
