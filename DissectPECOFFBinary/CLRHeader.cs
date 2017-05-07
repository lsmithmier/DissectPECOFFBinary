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

        public UInt32 MetadataAddress
        {
            get { return (UInt32)(Metadata & 0x00000000FFFFFFFF); }
        }

        public UInt32 MetadataSize
        {
            get { return (UInt32)(Metadata >> 32); }
        }

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

        public UInt32 StrongNameSignatureAddress
        {
            get { return (UInt32)(StrongNameSignature & 0x00000000FFFFFFFF); }
        }

        public UInt32 StrongNameSignatureSize
        {
            get { return (UInt32)(StrongNameSignature >> 32); }
        }

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
            returnValue.AppendFormat("Flags (decoded): {0:X}", DecodeFlags(Flags));
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

        private object DecodeFlags(uint flags)
        {
            List<string> setflags = new List<string>();
            if ((flags == 0x00000000))
            {
                //                0x00000000  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000001) != 0)
            {
                //COMIMAGE_FLAGS_ILONLY (0x00000001): The image file contains IL code only, 
                //              with no embedded native unmanaged code except the start-up  
                //              stub (which simply executes an indirect jump to the CLR entry  
                //              point). Common language runtime–aware operating systems (such  
                //              as Windows XP and newer) ignore the start-up stub and invoke  
                //              the CLR automatically, so for all practical purposes the file  
                //              can be considered pure IL. However, setting this flag can cause  
                //              certain problems when running under Windows XP and newer. If  
                //              this flag is set, the OS loader of Windows XP and newer ignores  
                //              not only the start-up stub but also the .reloc section, which in  
                //              this case contains single relocation (or single pair of  
                //              relocations in IA64-specific images) for the CLR entry point.  
                //              However, the .reloc section can contain relocations for the beginning  
                //              and end of the .tls section as well as relocations for what is  
                //              referred to as data on data (that is, data constants that are pointers  
                //              to other data constants). Among existing managed compilers, only the  
                //              VC++ and the IL assembler can produce these items. The VC++ of v7.0  
                //              and v7.1 (corresponding to CLR versions 1.0 and 1.1) never set this  
                //              flag because the image file it generated was never pure IL. In v2.0  
                //              this situation has changed, and currently, the VC++ and IL assembler  
                //              are the only two capable of producing pure-IL image files that might  
                //              require additional relocations in the .reloc section. To resolve this  
                //              problem, the IL assembler, if TLS-based data or data on data is  
                //              emitted, clears this flag and, if the target platform is 32-bit, sets  
                //              the COMIMAGE_FLAGS_32BITREQUIRED flag instead.
                setflags.Add("COMIMAGE_FLAGS_ILONLY");
            }
            if ((flags & 0x00000002) != 0)
            {
                //COMIMAGE_FLAGS_32BITREQUIRED (0x00000002): The image file can be loaded only 
                //              into a 32-bit process. This flag is set alone when native unmanaged 
                //              code is embedded in the PE file or when the .reloc section contains 
                //              additional relocations or is set in combination with _ILONLY when 
                //              the executable does not contain additional relocations but is in 
                //              some way 32-bit specific (for example, invokes an unmanaged 32-bit 
                //              specific API or uses 4-byte integers to store pointers).
                setflags.Add("COMIMAGE_FLAGS_32BITREQUIRED");
            }
            if ((flags & 0x00000004) != 0)
            {
                //COMIMAGE_FLAGS_IL_LIBRARY (0x00000004): This flag is obsolete and should not be 
                //              set. Setting it—as the IL assembler allows, using the .corflags 
                //              directive—will render your module unloadable.
                setflags.Add("COMIMAGE_FLAGS_IL_LIBRARY");
            }
            if ((flags & 0x00000008) != 0)
            {
                //COMIMAGE_FLAGS_STRONGNAMESIGNED (0x00000008): The image file is protected with 
                //              a strong name signature. The strong name signature includes the 
                //              public key and the signature hash and is a part of an assembly’s 
                //              identity, along with the assembly name, version number, and culture 
                //              information. This flag is set when the strong name signing procedure 
                //              is applied to the image file. No compiler, including ILAsm, can set 
                //              this flag explicitly.
                setflags.Add("COMIMAGE_FLAGS_STRONGNAMESIGNED");
            }
            if ((flags & 0x00000010) != 0)
            {
                //COMIMAGE_FLAGS_NATIVE_ENTRYPOINT (0x00000010): The executable’s entry point is 
                //              an unmanaged method. The EntryPointToken/EntryPointRVA field of 
                //              the CLR header contains the RVA of this native method. This flag 
                //              was introduced in version 2.0 of the CLR.
                setflags.Add("COMIMAGE_FLAGS_NATIVE_ENTRYPOINT");
            }
            if ((flags & 0x00000020) != 0)
            {
                //                0x00000020  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000040) != 0)
            {
                //                0x00000040  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000080) != 0)
            {
                //                0x00000080  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000100) != 0)
            {
                //                0x00000100  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000200) != 0)
            {
                //                0x00000200  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000400) != 0)
            {
                // 0x00000400  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00000800) != 0)
            {
                // 0x00000800  Reserved for future use.
                setflags.Add("Reserved flag set");
            }
            if ((flags & 0x00001000) != 0)
            {
                //COMIMAGE_FLAGS_TRACKDEBUGDATA (0x00010000): The CLR loader and the JIT compiler 
                //              are required to track debug information about the methods. This 
                //              flag is not used.
                setflags.Add("COMIMAGE_FLAGS_TRACKDEBUGDATA");
            }
            if ((flags & 0x00002000) != 0)
            {
                //COMIMAGE_FLAGS_32BITPREFERRED (0x00002000): The image file can be loaded into any 
                //              process, but preferably into a 32-bit process. This flag can be 
                //              only set together with flag COMIMAGE_FLAGS_32BITREQUIRED. When 
                //              set, these two flags mean the image is platform-neutral, but prefers 
                //              to be loaded as 32-bit when possible. This flag was introduced in CLR v4.0.
                setflags.Add("COMIMAGE_FLAGS_32BITPREFERRED");
            }
            return string.Join(",", setflags);
        }
    }
}
