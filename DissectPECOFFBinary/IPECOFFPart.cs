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
            var z = Convert.ToChar((uint32ToConvert >> 24) & 0xFF);
            var y = Convert.ToChar((uint32ToConvert >> 16) & 0xFF);
            var x = Convert.ToChar((uint32ToConvert >> 8) & 0xFF);
            var w = Convert.ToChar(uint32ToConvert & 0xFF);
            return String.Format("{3}{2}{1}{0}", z, y, x, w);
        }

        internal static string ConvertUInt16ToString(UInt16 uint16ToConvert)
        {
            var x = Convert.ToChar((uint16ToConvert >> 8) & 0xFF);
            var w = Convert.ToChar(uint16ToConvert & 0xFF);
            return String.Format("{1}{0}", x, w).Trim();
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
