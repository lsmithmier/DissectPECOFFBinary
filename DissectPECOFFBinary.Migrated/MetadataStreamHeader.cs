using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    public class MetadataStreamHeader : IPECOFFPart
    {
        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
        private struct MetadataStreamHeaderNative : IPECOFFPart
        {
            internal static long StartingPosition(GeneralMetadataHeader generalMetadataHeader)
            {
                return generalMetadataHeader.startingAddress + 0x10 +
                                    generalMetadataHeader.iVersionString + 0x4;
            }

            [FieldOffset(0x0)]
            [MarshalAs(UnmanagedType.U4)]
            internal UInt32 iOffset;

            [FieldOffset(0x4)]
            [MarshalAs(UnmanagedType.U4)]
            internal UInt32 iSize;

            public override string ToString()
            {
                StringBuilder returnValue = new StringBuilder();
                returnValue.AppendFormat("iOffset: 0x{0:X}", iOffset);
                returnValue.AppendLine();
                returnValue.AppendFormat("iSize: 0x{0:X}", iSize);
                returnValue.AppendLine();
                return returnValue.ToString();
            }
        }

        private MetadataStreamHeaderNative native;

        public UInt32 iOffset { get { return native.iOffset; } }

        public UInt32 iSize { get { return native.iSize; } }

        public string rcName;

        public long startingAddress;

        public MetadataStreamHeader(GeneralMetadataHeader generalMetadataHeader,
                                        FileStream inputFile)
        {
            MetadataStreamHeaderNative? metadataStreamHeaderNative;
            startingAddress = MetadataStreamHeaderNative.StartingPosition(generalMetadataHeader);
            inputFile.Position = startingAddress;
            ReadMetadataStreamHeaderFromFile(inputFile);
        }

        public MetadataStreamHeader(FileStream inputFile)
        {
            ReadMetadataStreamHeaderFromFile(inputFile);
        }

        private void ReadMetadataStreamHeaderFromFile(FileStream inputFile)
        {
            native = inputFile.
                    ReadStructure<MetadataStreamHeaderNative>().Value;
            byte[] nameBytes = new byte[32];
            for (int i = 0; i < 32; i += 4)
            {
                nameBytes[i] = (byte)inputFile.ReadByte();
                nameBytes[i + 1] = (byte)inputFile.ReadByte();
                nameBytes[i + 2] = (byte)inputFile.ReadByte();
                nameBytes[i + 3] = (byte)inputFile.ReadByte();
                if (nameBytes[i] == 0
                    || nameBytes[i + 1] == 0
                    || nameBytes[i + 2] == 0
                    || nameBytes[i + 3] == 0)
                {
                    break;
                }
            }
            rcName = System.Text.Encoding.Default.GetString(nameBytes).Replace("\0", "");
        }

        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.Append(native.ToString());
            returnValue.AppendFormat("rcName: {0}", rcName);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
