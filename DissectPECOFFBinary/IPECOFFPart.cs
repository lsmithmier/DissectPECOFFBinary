using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    interface IPECOFFPart
    {
        internal static string ConvertUInt32ToString(UInt32 uint32ToConvert)
        {
            return Convert.ToChar((uint32ToConvert >> 24) & 0xFF) == 0 ? null : String.Format("{3}{2}{1}{0}", Convert.ToChar((uint32ToConvert >> 24) & 0xFF), Convert.ToChar((uint32ToConvert >> 16) & 0xFF), Convert.ToChar((uint32ToConvert >> 8) & 0xFF), Convert.ToChar(uint32ToConvert & 0xFF)).Trim();
        }

        internal static Guid ConvertUInt64ToGUID(UInt64 uint32ToConvertPart1, UInt64 uint32ToConvertPart2)
        {
            byte[] guidData = new byte[16];
            Array.Copy(BitConverter.GetBytes(uint32ToConvertPart1), guidData, 8);
            Array.Copy(BitConverter.GetBytes(uint32ToConvertPart2), 0, guidData, 8, 8);
            return new Guid(guidData);
        }
    }
}
