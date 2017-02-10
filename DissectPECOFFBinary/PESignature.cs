using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PESignature
    {
        [FieldOffset(0x0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x4)]
        public string Signature;
        public override string ToString()
        {
            StringBuilder returnValue = new StringBuilder();
            returnValue.AppendFormat("PE Signature: {0}", Signature);
            returnValue.AppendLine();
            return returnValue.ToString();
        }
    }
}
