using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DissectPECOFFBinary
{
    class PECOFFBinary
    {
        static LinkedList<Type> PartTypes = new LinkedList<Type>();
        private string fileName;
        LinkedList<IPECOFFPart> Parts = new LinkedList<IPECOFFPart>();

        static PECOFFBinary()
        {
            PartTypes.AddLast(typeof(MSDOS20Section));
            PartTypes.AddLast(typeof(PESignature));
            PartTypes.AddLast(typeof(COFFHeader));
            PartTypes.AddLast(typeof(COFFOptionalHeaderStandardFields));
            PartTypes.AddLast(typeof(OptionalHeaderWindowsSpecificPE32));
            PartTypes.AddLast(typeof(OptionalHeaderWindowsSpecificPE32Plus));
            PartTypes.AddLast(typeof(OptionalHeaderDataDirectories));
            PartTypes.AddLast(typeof(SectionTable));
            PartTypes.AddLast(typeof(PESignature));
        }
    }
}
