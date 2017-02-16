using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class MSDOS20SectionSteps
    {
        [Given(@"a PECOFF binary file named (.*)")]
        public void GivenAPECOFFBinaryFileNamed(string fileName)
        {
            ScenarioContext.Current.Add("FileName", fileName);
        }
        
        [When(@"I read in the MSDOS20Section")]
        public void WhenIReadInTheMSDOSSection()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            using (FileStream inputFile =
                File.OpenRead(
                    string.Format(@"..\..\TestArtifacts\{0}", fileName)))
            {
                inputFile.Position = MSDOS20Section.StartingPosition();
                MSDOS20Section? msdos20Section =
                    inputFile.ReadStructure<MSDOS20Section>();
                ScenarioContext.Current.Add("MSDOS20Section", msdos20Section.Value);
            }
        }


        [Then(@"the Signature shoud be (.*)")]
        public void ThenTheSignatureShoudBe(string signature)
        {
            signature = WebUtility.HtmlDecode(signature);
            var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
            Assert.AreEqual(signature, msdos20Section.Signature);
        }

        [Then(@"the OffsetToPEHeader should be (.*)")]
        public void ThenTheOffsetToPEHeaderShouldBe(string offsetToPEHeader)
        {
            uint offsetToPEHeaderValue = Convert.ToUInt16(offsetToPEHeader, 16);
            var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
            Assert.AreEqual(offsetToPEHeaderValue, msdos20Section.OffsetToPEHeader);
        }
    }
}
