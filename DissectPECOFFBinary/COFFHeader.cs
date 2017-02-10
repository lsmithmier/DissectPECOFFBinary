using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct COFFHeader
    {
        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U2)]
        UInt16 MachineType;

        [FieldOffset(0x2)]
        [MarshalAs(UnmanagedType.U2)]
        public UInt16 NumberOfSections;

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 TimeDateStamp;

        [FieldOffset(0x8)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 PointerToSymbolTable;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U4)]
        UInt32 NumberOfSymbols;

        [FieldOffset(0x10)]
        [MarshalAs(UnmanagedType.U2)]
        UInt16 SizeOfOptionalHeader;

        [FieldOffset(0x12)]
        [MarshalAs(UnmanagedType.U2)]
        UInt16 Characteristics;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("MachineType: 0x{0:X}", MachineType);
            returnValue.AppendLine();
            returnValue.AppendFormat("MachineType (decoded): {0}", 
                DecodeMachineType(MachineType));
            returnValue.AppendLine();
            returnValue.AppendFormat("NumberOfSections: {0}", 
                NumberOfSections);
            returnValue.AppendLine();
            returnValue.AppendFormat("TimeDateStamp: 0x{0:X}", TimeDateStamp);
            returnValue.AppendLine();
            returnValue.AppendFormat("PointerToSymbolTable: 0x{0:X}", 
                PointerToSymbolTable);
            returnValue.AppendLine();
            returnValue.AppendFormat("NumberOfSymbols: {0}", NumberOfSymbols);
            returnValue.AppendLine();
            returnValue.AppendFormat("SizeOfOptionalHeader: {0}", 
                SizeOfOptionalHeader);
            returnValue.AppendLine();
            returnValue.AppendFormat("Characteristics: 0x{0:X}", 
                Characteristics);
            returnValue.AppendLine();
            returnValue.AppendFormat("Characteristics (decoded): {0}", 
                DecodeCharacteristics(Characteristics));
            returnValue.AppendLine();
            return returnValue.ToString();
        }

        public string DecodeMachineType(UInt16 machineType)
        {
            string returnValue;
            switch (machineType)
            {
                case 0x0:
                    //IMAGE_FILE_MACHINE_UNKNOWN  0x0 The contents of this 
                    //                                field are assumed to be 
                    //                                applicable to any 
                    //                                machine type
                    returnValue = "IMAGE_FILE_MACHINE_UNKNOWN";
                    break;
                case 0x1d3:
                    //IMAGE_FILE_MACHINE_AM33 0x1d3   Matsushita AM33
                    returnValue = "IMAGE_FILE_MACHINE_AM33";
                    break;
                case 0x8664:
                    //IMAGE_FILE_MACHINE_AMD64    0x8664  x64
                    returnValue = "IMAGE_FILE_MACHINE_AMD64";
                    break;
                case 0x1c0:
                    //IMAGE_FILE_MACHINE_ARM  0x1c0   ARM little endian
                    returnValue = "IMAGE_FILE_MACHINE_ARM";
                    break;
                case 0xaa64:
                    //IMAGE_FILE_MACHINE_ARM64    0xaa64  ARM64 little endian
                    returnValue = "IMAGE_FILE_MACHINE_ARM64";
                    break;
                case 0x1c4:
                    //IMAGE_FILE_MACHINE_ARMNT    0x1c4   ARM Thumb-2 little 
                    //                                      endian
                    returnValue = "IMAGE_FILE_MACHINE_ARMNT";
                    break;
                case 0xebc:
                    //IMAGE_FILE_MACHINE_EBC  0xebc   EFI byte code
                    returnValue = "IMAGE_FILE_MACHINE_EBC";
                    break;
                case 0x14c:
                    //IMAGE_FILE_MACHINE_I386 0x14c   Intel 386 or later 
                    //                                processors and 
                    //                                compatible processors
                    returnValue = "IMAGE_FILE_MACHINE_I386";
                    break;
                case 0x200:
                    //IMAGE_FILE_MACHINE_IA64 0x200   Intel Itanium processor 
                    //                                family
                    returnValue = "IMAGE_FILE_MACHINE_IA64";
                    break;
                case 0x9041:
                    //IMAGE_FILE_MACHINE_M32R 0x9041  Mitsubishi M32R little 
                    //                                endian
                    returnValue = "IMAGE_FILE_MACHINE_M32R";
                    break;
                case 0x266:
                    //IMAGE_FILE_MACHINE_MIPS16   0x266   MIPS16
                    returnValue = "IMAGE_FILE_MACHINE_MIPS16";
                    break;
                case 0x366:
                    //IMAGE_FILE_MACHINE_MIPSFPU  0x366   MIPS with FPU
                    returnValue = "IMAGE_FILE_MACHINE_MIPSFPU";
                    break;
                case 0x466:
                    //IMAGE_FILE_MACHINE_MIPSFPU16    0x466   MIPS16 with FPU
                    returnValue = "IMAGE_FILE_MACHINE_MIPSFPU16";
                    break;
                case 0x1f0:
                    //IMAGE_FILE_MACHINE_POWERPC  0x1f0   Power PC little 
                    //                                endian
                    returnValue = "IMAGE_FILE_MACHINE_POWERPC";
                    break;
                case 0x1f1:
                    //IMAGE_FILE_MACHINE_POWERPCFP    0x1f1   Power PC with 
                    //                                floating point support
                    returnValue = "IMAGE_FILE_MACHINE_POWERPCFP";
                    break;
                case 0x166:
                    //IMAGE_FILE_MACHINE_R4000    0x166   MIPS little endian
                    returnValue = "IMAGE_FILE_MACHINE_R4000";
                    break;
                case 0x5032:
                    //IMAGE_FILE_MACHINE_RISCV32  0x5032  RISC - V 32 - bit 
                    //                                address space
                    returnValue = "IMAGE_FILE_MACHINE_RISCV32";
                    break;
                case 0x5064:
                    //IMAGE_FILE_MACHINE_RISCV64  0x5064  RISC - V 64 - bit 
                    //                                address space
                    returnValue = "IMAGE_FILE_MACHINE_RISCV64";
                    break;
                case 0x5128:
                    //IMAGE_FILE_MACHINE_RISCV128 0x5128  RISC - V 128 - bit 
                    //                                address space
                    returnValue = "IMAGE_FILE_MACHINE_RISCV128";
                    break;
                case 0x1a2:
                    //IMAGE_FILE_MACHINE_SH3  0x1a2   Hitachi SH3
                    returnValue = "IMAGE_FILE_MACHINE_SH3";
                    break;
                case 0x1a3:
                    //IMAGE_FILE_MACHINE_SH3DSP   0x1a3   Hitachi SH3 DSP
                    returnValue = "IMAGE_FILE_MACHINE_SH3DSP";
                    break;
                case 0x1a6:
                    //IMAGE_FILE_MACHINE_SH4  0x1a6   Hitachi SH4
                    returnValue = "IMAGE_FILE_MACHINE_SH4";
                    break;
                case 0x1a8:
                    //IMAGE_FILE_MACHINE_SH5  0x1a8   Hitachi SH5
                    returnValue = "IMAGE_FILE_MACHINE_SH5";
                    break;
                case 0x1c2:
                    //IMAGE_FILE_MACHINE_THUMB    0x1c2   Thumb
                    returnValue = "IMAGE_FILE_MACHINE_THUMB";
                    break;
                case 0x169:
                    //IMAGE_FILE_MACHINE_WCEMIPSV2    0x169   MIPS little
                    //                                -endian WCE v2
                    returnValue = "IMAGE_FILE_MACHINE_WCEMIPSV2";
                    break;
                default:
                    returnValue = "Unknown Machine Type";
                    break;
            }
            return returnValue;
        }
        private string DecodeCharacteristics(ushort characteristics)
        {
            List<string> setCharacteristics = new List<string>();
            if((characteristics & 0x0001) != 0)
            {
                //IMAGE_FILE_RELOCS_STRIPPED  0x0001  Image only, Windows CE, 
                //                                and Microsoft Windows NT® 
                //                                and later. This indicates 
                //                                that the file does not 
                //                                contain base relocations 
                //                                and must therefore be loaded 
                //                                at its preferred base 
                //                                address.If the base address 
                //                                is not available, the loader 
                //                                reports an error.The default 
                //                                behavior of the linker is 
                //                                to strip base relocations 
                //                                from executable(EXE) files.
                setCharacteristics.Add("IMAGE_FILE_RELOCS_STRIPPED");
            }
            if ((characteristics & 0x0002) != 0)
            {
                //IMAGE_FILE_EXECUTABLE_IMAGE 0x0002  Image only. This 
                //                                indicates that the image 
                //                                file is valid and can be run. 
                //                                If this flag is not set, it 
                //                                indicates a linker error.
                setCharacteristics.Add("IMAGE_FILE_EXECUTABLE_IMAGE");
            }
            if ((characteristics & 0x0004) != 0)
            {
                //IMAGE_FILE_LINE_NUMS_STRIPPED   0x0004  COFF line numbers 
                //                                have been removed. This 
                //                                flag is deprecated and 
                //                                should be zero.
                setCharacteristics.Add("IMAGE_FILE_LINE_NUMS_STRIPPED");
            }
            if ((characteristics & 0x0008) != 0)
            {
                //IMAGE_FILE_LOCAL_SYMS_STRIPPED  0x0008  COFF symbol table 
                //                                entries for local symbols 
                //                                have been removed. This flag 
                //                                is deprecated and should 
                //                                be zero.
                setCharacteristics.Add("IMAGE_FILE_LOCAL_SYMS_STRIPPED");
            }
            if ((characteristics & 0x0010) != 0)
            {
                //IMAGE_FILE_AGGRESSIVE_WS_TRIM   0x0010  Obsolete.
                //                                Aggressively trim working 
                //                                set. This flag is deprecated 
                //                                for Windows 2000 and later 
                //                                and must be zero.
                setCharacteristics.Add("IMAGE_FILE_AGGRESSIVE_WS_TRIM");
            }
            if ((characteristics & 0x0020) != 0)
            {
                //IMAGE_FILE_LARGE_ADDRESS_ AWARE 0x0020  Application can 
                //                                handle > 2 GB addresses.
                setCharacteristics.Add("IMAGE_FILE_LARGE_ADDRESS_AWARE");
            }
            if ((characteristics & 0x0040) != 0)
            {
                //RESERVED  0x0040  This flag is reserved for future use.
                setCharacteristics.Add("RESERVED");
            }
            if ((characteristics & 0x0080) != 0)
            {
                //IMAGE_FILE_BYTES_REVERSED_LO    0x0080  Little endian: the 
                //                                least significant bit(LSB) 
                //                                precedes the most significant 
                //                                bit(MSB) in memory.This flag 
                //                                is deprecated and should be 
                //                                zero.
                setCharacteristics.Add("IMAGE_FILE_BYTES_REVERSED_LO");
            }
            if ((characteristics & 0x0100) != 0)
            {
                //IMAGE_FILE_32BIT_MACHINE    0x0100  Machine is based on a 
                //                                32 - bit - word architecture.
                setCharacteristics.Add("IMAGE_FILE_32BIT_MACHINE");
            }
            if ((characteristics & 0x0200) != 0)
            {
                //IMAGE_FILE_DEBUG_STRIPPED   0x0200  Debugging information is 
                //                                removed from the image file.
                setCharacteristics.Add("IMAGE_FILE_DEBUG_STRIPPED");
            }
            if ((characteristics & 0x0400) != 0)
            {
                //IMAGE_FILE_REMOVABLE_RUN_ FROM_SWAP 0x0400  If the image is 
                //                                on removable media, fully 
                //                                load it and copy it to the 
                //                                swap file.
                setCharacteristics.Add("IMAGE_FILE_REMOVABLE_RUN_FROM_SWAP");
            }
            if ((characteristics & 0x0800) != 0)
            {
                //IMAGE_FILE_NET_RUN_FROM_SWAP    0x0800  If the image is on 
                //                                network media, fully load it 
                //                                and copy it to the 
                //                                swap file.
                setCharacteristics.Add("IMAGE_FILE_NET_RUN_FROM_SWAP");
            }
            if ((characteristics & 0x1000) != 0)
            {
                //IMAGE_FILE_SYSTEM   0x1000  The image file is a system file, 
                //                                not a user program.
                setCharacteristics.Add("IMAGE_FILE_SYSTEM");
            }
            if ((characteristics & 0x2000) != 0)
            {
                //IMAGE_FILE_DLL  0x2000  The image file is a dynamic - link 
                //                                library(DLL). Such files are 
                //                                considered executable files 
                //                                for almost all purposes, 
                //                                although they cannot be 
                //                                directly run.
                setCharacteristics.Add("IMAGE_FILE_DLL");
            }
            if ((characteristics & 0x4000) != 0)
            {
                //IMAGE_FILE_UP_SYSTEM_ONLY   0x4000  The file should be run 
                //                                only on a uniprocessor 
                //                                machine.
                setCharacteristics.Add("IMAGE_FILE_UP_SYSTEM_ONLY");
            }
            if ((characteristics & 0x8000) != 0)
            {
                //IMAGE_FILE_BYTES_REVERSED_HI    0x8000  Big endian: the MSB 
                //                                precedes the LSB in memory.
                //                                This flag is deprecated and 
                //                                should be zero.
                setCharacteristics.Add("IMAGE_FILE_BYTES_REVERSED_HI");
            }
            return string.Join(",", setCharacteristics);
        }
    }
}
