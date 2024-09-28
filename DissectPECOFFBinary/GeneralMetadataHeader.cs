using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    public class GeneralMetadataHeader : IPECOFFPart
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        private struct GeneralMetadataHeaderNative : IPECOFFPart
        {
            internal static long StartingPosition(CLRHeader clrHeader, 
                                                   List<SectionTable> sectionTables)
            {
                foreach (var sectionTable in sectionTables)
                {
                    if (clrHeader.MetadataAddress >= sectionTable.VirtualAddress
                        &&
                      clrHeader.MetadataAddress <= sectionTable.VirtualAddress 
                        + sectionTable.VirtualSize)
                    {
                        return sectionTable.PointerToRawData + 
                            clrHeader.MetadataAddress - sectionTable.VirtualAddress;
                    }
                }
                throw new ArgumentOutOfRangeException("CLRHeader Metadata Address", 
                    "The CLRHeader Metadata Address did not fall within the address"+
                    " range of any of the Section Tables");
            }


            [FieldOffset(0x0)]
            [MarshalAs(UnmanagedType.U4)]
            internal UInt32 lSig;

            internal string lSignature => IPECOFFPart.ConvertUInt32ToString(lSig);

            [FieldOffset(0x4)]
            [MarshalAs(UnmanagedType.U2)]
            internal UInt16 iMajorVer;

            [FieldOffset(0x6)]
            [MarshalAs(UnmanagedType.U2)]
            internal UInt16 iMinorVer;

            [FieldOffset(0x8)]
            [MarshalAs(UnmanagedType.U4)]
            internal UInt32 iExtraData;

            [FieldOffset(0xC)]
            [MarshalAs(UnmanagedType.U4)]
            internal UInt32 iVersionString;

            public override string ToString()
            {
                StringBuilder returnValue = new StringBuilder();
                returnValue.AppendFormat("lSignature: {0}", lSignature);
                returnValue.AppendLine();
                returnValue.AppendFormat("iMajorVer: {0}", iMajorVer);
                returnValue.AppendLine();
                returnValue.AppendFormat("iMinorVer: {0}", iMinorVer);
                returnValue.AppendLine();
                returnValue.AppendFormat("iExtraData: 0x{0:X}", iExtraData);
                returnValue.AppendLine();
                returnValue.AppendFormat("iVersionString: 0x{0:X}", iVersionString);
                returnValue.AppendLine();
                return returnValue.ToString();
            }
        }

        private readonly GeneralMetadataHeaderNative native;

        public string lSignature { get { return native.lSignature; } }

        public UInt16 iMajorVer { get { return native.iMajorVer; } }

        public UInt16 iMinorVer { get { return native.iMinorVer; } }

        public UInt32 iExtraData { get { return native.iExtraData; } }

        public UInt32 iVersionString { get { return native.iVersionString; } }

        public readonly string pVersion;

        public long startingAddress;

        public GeneralMetadataHeader(CLRHeader clrHeader, 
                                        List<SectionTable> sectionTables, 
                                        FileStream inputFile)
        {
            //General Metadata Header
            GeneralMetadataHeaderNative? generalMetadataHeaderNative;
            startingAddress = GeneralMetadataHeaderNative.StartingPosition(clrHeader, 
                                                                sectionTables.ToList());
            inputFile.Position = startingAddress;
            native = inputFile.
                    ReadStructure<GeneralMetadataHeaderNative>().Value;
            byte[] signatureBytes = new byte[native.iVersionString];
            inputFile.Read(signatureBytes, 0, (int)native.iVersionString);
            pVersion = System.Text.Encoding.Default.GetString(signatureBytes).Replace("\0","");
        }

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.Append(native.ToString());
            returnValue.AppendFormat("pVersion: {0}", pVersion);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
