using DissectPECOFFBinary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;

namespace PECOFFBinary.SpecFlow
{
    [Binding]
    public class PESignatureSteps
    {
        [When(@"I read in the PESignature")]
        public void WhenIReadInThePESignature()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            var filePath = string.Format(@".\TestArtifacts\{0}", fileName);
            if (!File.Exists(filePath))
            {
                filePath = string.Format(@".\{0}", fileName);
                Console.WriteLine(string.Format(@"File not Found: .\TestArtifacts\{0}", fileName));
            }
            using (FileStream inputFile = File.OpenRead(filePath))
            {
                var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
                inputFile.Position = PESignature.StartingPosition(msdos20Section);
                PESignature? peSignature =
                    inputFile.ReadStructure<PESignature>();
                ScenarioContext.Current.Add("PESignature", peSignature.Value);
            }
        }
        [Then(@"the PE Signature shoud be (.*)")]
        public void ThenThePESignatureShoudBePE(string signature)
        {
            signature = WebUtility.HtmlDecode(signature);
            var peSignature = ScenarioContext.Current.Get<PESignature>("PESignature");
            Assert.AreEqual(signature, peSignature.Signature);
        }
    }
}
