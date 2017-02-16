using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct OptionalHeaderWindowsSpecificPE32 : IPECOFFPart
    {
        public static long StartingPosition(MSDOS20Section msdos20Section)
        {
            return msdos20Section.OffsetToPEHeader
                + (Int64)Marshal.SizeOf<PESignature>()
                + (Int64)Marshal.SizeOf<COFFHeader>()
                + (Int64)Marshal.SizeOf<COFFOptionalHeaderStandardFields>();
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 BaseOfData;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 ImageBase;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SectionAlignment;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 FileAlignment;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MajorOperatingSystemVersion;

        [FieldOffset(0x12)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MinorOperatingSystemVersion;

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MajorImageVersion;

        [FieldOffset(0x16)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MinorImageVersion;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MajorSubsystemVersion;

        [FieldOffset(0x1A)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 MinorSubsystemVersion;

        [FieldOffset(0x1C)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Win32VersionValue;

        [FieldOffset(0x20)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfImage;

        [FieldOffset(0x24)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfHeaders;

        [FieldOffset(0x28)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 CheckSum;

        [FieldOffset(0x2C)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 Subsystem;

        [FieldOffset(0x2E)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 DllCharacteristics;

        [FieldOffset(0x30)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfStackReserve;

        [FieldOffset(0x34)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfStackCommit;

        [FieldOffset(0x38)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfHeapReserve;

        [FieldOffset(0x3C)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 SizeOfHeapCommit;

        [FieldOffset(0x40)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 LoaderFlags;

        [FieldOffset(0x44)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 NumberOfRvaAndSizes;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("BaseOfData: 0x{0:X}", BaseOfData);
            returnValue.AppendLine();
            returnValue.AppendFormat("ImageBase: 0x{0:X}", ImageBase);
            returnValue.AppendLine();
            returnValue.AppendFormat("SectionAlignment: 0x{0:X}", 
                SectionAlignment);
            returnValue.AppendLine();
            returnValue.AppendFormat("FileAlignment: 0x{0:X}",
                FileAlignment);
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorOperatingSystemVersion: {0}", 
                MajorOperatingSystemVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorOperatingSystemVersion: {0}",
                MinorOperatingSystemVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorImageVersion: {0}", 
                MajorImageVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorImageVersion: {0}", 
                MinorImageVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MajorSubsystemVersion: {0}",
                MajorSubsystemVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("MinorSubsystemVersion: {0}",
                MinorSubsystemVersion);
            returnValue.AppendLine();
            returnValue.AppendFormat("Win32VersionValue: {0}",
                Win32VersionValue);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfImage: {0}", SizeOfImage);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfHeaders: {0}", SizeOfHeaders);
            returnValue.AppendLine();
            returnValue.AppendFormat("CheckSum: 0x{0:X}", CheckSum);
            returnValue.AppendLine();
            returnValue.AppendFormat("Subsystem: 0x{0:X}", Subsystem);
            returnValue.AppendLine();
            returnValue.AppendFormat("Subsystem (decoded): {0}", 
                DecodeSubsystem(Subsystem));
            returnValue.AppendLine();
            returnValue.AppendFormat("DllCharacteristics: 0x{0:X}",
                DllCharacteristics);
            returnValue.AppendLine();
            returnValue.AppendFormat("DllCharacteristics (decoded): {0}",
                DecodeDllCharacteristics(DllCharacteristics));
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfStackReserve: {0}",
                SizeOfStackReserve);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfStackCommit: {0}",
                SizeOfStackCommit);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfHeapReserve: {0}",
                SizeOfHeapReserve);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfHeapCommit: {0}",
                SizeOfHeapCommit);
            returnValue.AppendLine();
            returnValue.AppendFormat("LoaderFlags: 0x{0:X}", LoaderFlags);
            returnValue.AppendLine();
            returnValue.AppendFormat("NumberOfRvaAndSizes: 0x{0:X}", 
                NumberOfRvaAndSizes);
            returnValue.AppendLine();
            return returnValue.ToString();
        }

        private string DecodeDllCharacteristics(ushort dllCharacteristics)
        {
            List<string> setCharacteristics = new List<string>();
            if ((dllCharacteristics & 0x0001) != 0)
            {
                //    0x0001  Reserved, must be zero.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((dllCharacteristics & 0x0002) != 0)
            {
                //    0x0002  Reserved, must be zero.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((dllCharacteristics & 0x0004) != 0)
            {
                //    0x0004  Reserved, must be zero.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((dllCharacteristics & 0x0008) != 0)
            {
                //    0x0008  Reserved, must be zero.
                setCharacteristics.Add("Reserved flag set");
            }
            if ((dllCharacteristics & 0x0020) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA    0x0020  Image
                //              can handle a high entropy 64 - bit virtual
                //              address space.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_HIGH_ENTROPY_VA");
            }
            if ((dllCharacteristics & 0x0040) != 0)
            {
                //  IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE    0x0040	DLL can
                //              be relocated at load time.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_DYNAMIC_BASE");
            }
            if ((dllCharacteristics & 0x0080) != 0)
            {
                //  IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY	0x0080	Code
                //              Integrity checks are enforced.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_FORCE_INTEGRITY");
            }
            if ((dllCharacteristics & 0x0100) != 0)
            {
                //  IMAGE_DLLCHARACTERISTICS_NX_COMPAT	0x0100	Image is NX
                //              compatible.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_NX_COMPAT");
            }
            if ((dllCharacteristics & 0x0200) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_ NO_ISOLATION	0x0200	Isolation aware, but do not isolate the image.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_NO_ISOLATION");
            }
            if ((dllCharacteristics & 0x0400) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_ NO_SEH	0x0400	Does not use
                //              structured exception (SE) handling. No SE
                //              handler may be called in this image.
                setCharacteristics.Add("IMAGE_DLLCHARACTERISTICS_ NO_SEH");
            }
            if ((dllCharacteristics & 0x0800) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_ NO_BIND	0x0800	Do not bind 
                //              the image.
                setCharacteristics.Add("IMAGE_DLLCHARACTERISTICS_NO_BIND");
            }
            if ((dllCharacteristics & 0x1000) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_APPCONTAINER	0x1000	Image must
                //              execute in an AppContainer.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_APPCONTAINER");
            }
            if ((dllCharacteristics & 0x2000) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_ WDM_DRIVER    0x2000	A WDM 
                //              driver.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_ WDM_DRIVER");
            }
            if ((dllCharacteristics & 0x4000) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_GUARD_CF   0x4000	Image
                //              supports Control Flow Guard.
                setCharacteristics.Add("IMAGE_DLLCHARACTERISTICS_GUARD_CF");
            }
            if ((dllCharacteristics & 0x8000) != 0)
            {
                //IMAGE_DLLCHARACTERISTICS_ TERMINAL_SERVER_AWARE	0x8000
                //              Terminal Server aware.
                setCharacteristics.
                    Add("IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE");
            }
            return string.Join(",", setCharacteristics);
        }
        private string DecodeSubsystem(ushort subsystem)
        {
            string returnValue = string.Empty;
            switch (subsystem)
            {
                case 0:
                    //IMAGE_SUBSYSTEM_UNKNOWN   0 An unknown subsystem
                    returnValue = "IMAGE_SUBSYSTEM_UNKNOWN";
                    break;
                case 1:
                    //IMAGE_SUBSYSTEM_NATIVE    1 Device drivers and native
                    //                              Windows processes
                    returnValue = "IMAGE_SUBSYSTEM_NATIVE";
                    break;
                case 2:
                    //IMAGE_SUBSYSTEM_WINDOWS_GUI   2 The Windows graphical
                    //                              user interface (GUI)
                    //                              subsystem
                    returnValue = "IMAGE_SUBSYSTEM_WINDOWS_GUI";
                    break;
                case 3:
                    //IMAGE_SUBSYSTEM_WINDOWS_CUI	  3	The Windows 
                    //                              character subsystem
                    returnValue = "IMAGE_SUBSYSTEM_WINDOWS_CUI";
                    break;
                case 5:
                    //IMAGE_SUBSYSTEM_OS2_CUI	  5	The OS/2 character subsystem
                    returnValue = "IMAGE_SUBSYSTEM_OS2_CUI";
                    break;
                case 7:
                    //IMAGE_SUBSYSTEM_POSIX_CUI	  7	The Posix character
                    //                              subsystem
                    returnValue = "IMAGE_SUBSYSTEM_POSIX_CUI";
                    break;
                case 8:
                    //IMAGE_SUBSYSTEM_NATIVE_WINDOWS	  8	Native Win9x driver
                    returnValue = "IMAGE_SUBSYSTEM_NATIVE_WINDOWS";
                    break;
                case 9:
                    //IMAGE_SUBSYSTEM_WINDOWS_CE_GUI	  9	Windows CE
                    returnValue = "IMAGE_SUBSYSTEM_WINDOWS_CE_GUI";
                    break;
                case 10:
                    //IMAGE_SUBSYSTEM_EFI_APPLICATION	10	An Extensible
                    //                              Firmware Interface(EFI)
                    //                              application
                    returnValue = "IMAGE_SUBSYSTEM_EFI_APPLICATION";
                    break;
                case 11:
                    //IMAGE_SUBSYSTEM_EFI_BOOT_ SERVICE_DRIVER	11	An EFI
                    //                              driver with boot
                    //                              services
                    returnValue = "IMAGE_SUBSYSTEM_EFI_BOOT_SERVICE_DRIVER";
                    break;
                case 12:
                    //IMAGE_SUBSYSTEM_EFI_RUNTIME_ DRIVER	12	An EFI
                    //                              driver
                    //                              with run-time services
                    returnValue = "IMAGE_SUBSYSTEM_EFI_RUNTIME_DRIVER";
                    break;
                case 13:
                    //IMAGE_SUBSYSTEM_EFI_ROM	13	An EFI ROM image
                    returnValue = "IMAGE_SUBSYSTEM_EFI_ROM";
                    break;
                case 14:
                    //IMAGE_SUBSYSTEM_XBOX	14	XBOX
                    returnValue = "IMAGE_SUBSYSTEM_XBOX";
                    break;
                case 16:
                    //IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION	16	Windows
                    //                              boot application.
                    returnValue =
                        "IMAGE_SUBSYSTEM_WINDOWS_BOOT_APPLICATION";
                    break;
                default:
                    returnValue = "Unknown value";
                    break;
            }
            return returnValue;
        }
    }
}
