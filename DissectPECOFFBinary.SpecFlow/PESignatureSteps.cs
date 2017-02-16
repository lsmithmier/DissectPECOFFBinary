using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class PESignatureSteps
    {
        [When(@"I read in the PESignature")]
        public void WhenIReadInThePESignature()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            using (FileStream inputFile =
                File.OpenRead(
                    string.Format(@"..\..\TestArtifacts\{0}", fileName)))
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
