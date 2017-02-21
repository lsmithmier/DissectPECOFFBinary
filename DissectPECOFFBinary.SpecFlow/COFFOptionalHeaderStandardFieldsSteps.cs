using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class COFFOptionalHeaderStandardFieldsSteps
    {
        [When(@"I read in the COFFOptionalHeaderStandardFields")]
        public void WhenIReadInTheCOFFOptionalHeaderStandardFields()
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
                inputFile.Position = COFFOptionalHeaderStandardFields.StartingPosition(msdos20Section);
                COFFOptionalHeaderStandardFields? coffOptionalHeaderStandardFields =
                    inputFile.ReadStructure<COFFOptionalHeaderStandardFields>();
                ScenarioContext.Current.Add("COFFOptionalHeaderStandardFields", coffOptionalHeaderStandardFields.Value);
            }
        }

        [Then(@"the Magic shoud be (.*)")]
        public void ThenTheMagicShoudBe(string magic)
        {
            UInt16 magicValue = Convert.ToUInt16(magic, 16);
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(magicValue, coffOptionalHeaderStandardFields.Magic);
        }

        [Then(@"the MajorLinkerVersion should be (.*)")]
        public void ThenTheMajorLinkerVersionShouldBe(string majorLinkerVersion)
        {
            byte majorLinkerVersionValue = Convert.ToByte(majorLinkerVersion, 16);
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(majorLinkerVersionValue, coffOptionalHeaderStandardFields.MajorLinkerVersion);
        }

        [Then(@"the MinorLinkerVersion should be (.*)")]
        public void ThenTheMinorLinkerVersionShouldBe(string minorLinkerVersion)
        {
            byte minorLinkerVersionValue = Convert.ToByte(minorLinkerVersion, 16);
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(minorLinkerVersionValue, coffOptionalHeaderStandardFields.MinorLinkerVersion);
        }

        [Then(@"the SizeOfCode should be (.*)")]
        public void ThenTheSizeOfCodeShouldBe(UInt32 sizeOfCode)
        {
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(sizeOfCode, coffOptionalHeaderStandardFields.SizeOfCode);
        }

        [Then(@"the SizeOfInitializedData should be (.*)")]
        public void ThenTheSizeOfInitializedDataShouldBe(UInt32 sizeOfInitializedData)
        {
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(sizeOfInitializedData, coffOptionalHeaderStandardFields.SizeOfInitializedData);
        }

        [Then(@"the SizeOfUninitializedData should be (.*)")]
        public void ThenTheSizeOfUninitializedDataShouldBe(UInt32 sizeOfUninitializedData)
        {
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(sizeOfUninitializedData, coffOptionalHeaderStandardFields.SizeOfUninitializedData);
        }

        [Then(@"the AddressOfEntryPoint should be (.*)")]
        public void ThenTheAddressOfEntryPointShouldBe(string addressOfEntryPoint)
        {
            UInt32 addressOfEntryPointValue = Convert.ToUInt32(addressOfEntryPoint, 16);
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(addressOfEntryPointValue, coffOptionalHeaderStandardFields.AddressOfEntryPoint);
        }

        [Then(@"the BaseOfCode should be (.*)")]
        public void ThenTheBaseOfCodeShouldBe(string baseOfCode)
        {
            UInt32 baseOfCodeValue = Convert.ToUInt32(baseOfCode, 16);
            var coffOptionalHeaderStandardFields = ScenarioContext.Current.Get<COFFOptionalHeaderStandardFields>("COFFOptionalHeaderStandardFields");
            Assert.AreEqual(baseOfCodeValue, coffOptionalHeaderStandardFields.BaseOfCode);
        }
    }
}
