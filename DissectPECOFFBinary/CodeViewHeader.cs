using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

/*

 */
namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct CodeViewHeader : IPECOFFPart
    {
        public static long StartingPosition(DebugDirectory debugDirectory, 
                                            List<SectionTable> sectionTables)
        {
            return debugDirectory.PointerToRawData;
        }

        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 CvSig;

        public string CvSignature => IPECOFFPart.ConvertUInt32ToString(CvSig);

        [FieldOffset(0x4)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Sig1;

        [FieldOffset(0xC)]
        [MarshalAs(UnmanagedType.U8)]
        public UInt64 Sig2;

        public Guid Signature => IPECOFFPart.ConvertUInt64ToGUID(Sig1, Sig2);

        [FieldOffset(0x14)]
        [MarshalAs(UnmanagedType.U4)]
        public UInt32 Age;

        [FieldOffset(0x18)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x104)]
        public string PdbFileName;

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("CvSignature: {0}", CvSignature);
            returnValue.AppendLine();
            returnValue.AppendFormat("Signature: {0}", Signature);
            returnValue.AppendLine();
            returnValue.AppendFormat("Age: 0x{0:X}", Age);
            returnValue.AppendLine();
            returnValue.AppendFormat("PdbFileName: {0}", PdbFileName);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
