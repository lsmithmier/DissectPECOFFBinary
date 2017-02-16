using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace DissectPECOFFBinary.SpecFlow
{
    [Binding]
    public class OptionalHeaderWindowsSpecificPE32Steps
    {
        [When(@"I read in the OptionalHeaderWindowsSpecificPE32")]
        public void WhenIReadInTheOptionalHeaderWindowsSpecificPE32()
        {
            var fileName = ScenarioContext.Current.Get<string>("FileName");
            using (FileStream inputFile =
                File.OpenRead(
                    string.Format(@"..\..\TestArtifacts\{0}", fileName)))
            {
                var msdos20Section = ScenarioContext.Current.Get<MSDOS20Section>("MSDOS20Section");
                inputFile.Position = OptionalHeaderWindowsSpecificPE32.StartingPosition(msdos20Section);
                OptionalHeaderWindowsSpecificPE32? optionalHeaderWindowsSpecificPE32 =
                    inputFile.ReadStructure<OptionalHeaderWindowsSpecificPE32>();
                ScenarioContext.Current.Add("OptionalHeaderWindowsSpecificPE32", optionalHeaderWindowsSpecificPE32.Value);
            }
        }

        [Then(@"the BaseOfData shoud be (.*)")]
        public void ThenTheBaseOfDataShoudBe(string baseOfData)
        {
            uint baseOfDataValue = Convert.ToUInt16(baseOfData, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(baseOfDataValue, optionalHeaderWindowsSpecificPE32.BaseOfData);
        }

        [Then(@"the ImageBase should be (.*)")]
        public void ThenTheImageBaseShouldBe(string imageBase)
        {
            UInt32 imageBaseValue = Convert.ToUInt32(imageBase, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(imageBaseValue, optionalHeaderWindowsSpecificPE32.ImageBase);
        }

        [Then(@"the SectionAlignment should be (.*)")]
        public void ThenTheSectionAlignmentShouldBe(string sectionAlignment)
        {
            UInt32 sectionAlignmentValue = Convert.ToUInt32(sectionAlignment, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sectionAlignmentValue, optionalHeaderWindowsSpecificPE32.SectionAlignment);
        }

        [Then(@"the FileAlignment should be (.*)")]
        public void ThenTheFileAlignmentShouldBe(string fileAlignment)
        {
            UInt32 fileAlignmentValue = Convert.ToUInt32(fileAlignment, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(fileAlignmentValue, optionalHeaderWindowsSpecificPE32.FileAlignment);
        }

        [Then(@"the MajorOperatingSystemVersion should be (.*)")]
        public void ThenTheMajorOperatingSystemVersionShouldBe(UInt16 majorOperatingSystemVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(majorOperatingSystemVersion, optionalHeaderWindowsSpecificPE32.MajorOperatingSystemVersion);
        }

        [Then(@"the MinorOperatingSystemVersion should be (.*)")]
        public void ThenTheMinorOperatingSystemVersionShouldBe(UInt16 minorOperatingSystemVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(minorOperatingSystemVersion, optionalHeaderWindowsSpecificPE32.MinorOperatingSystemVersion);
        }

        [Then(@"the MajorImageVersion should be (.*)")]
        public void ThenTheMajorImageVersionShouldBe(UInt16 majorImageVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(majorImageVersion, optionalHeaderWindowsSpecificPE32.MajorImageVersion);
        }

        [Then(@"the MinorImageVersion should be (.*)")]
        public void ThenTheMinorImageVersionShouldBe(UInt16 minorImageVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(minorImageVersion, optionalHeaderWindowsSpecificPE32.MinorImageVersion);
        }

        [Then(@"the MajorSubsystemVersion should be (.*)")]
        public void ThenTheMajorSubsystemVersionShouldBe(UInt16 majorSubsystemVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(majorSubsystemVersion, optionalHeaderWindowsSpecificPE32.MajorSubsystemVersion);
        }

        [Then(@"the MinorSubsystemVersion should be (.*)")]
        public void ThenTheMinorSubsystemVersionShouldBe(UInt16 minorSubsystemVersion)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(minorSubsystemVersion, optionalHeaderWindowsSpecificPE32.MinorSubsystemVersion);
        }

        [Then(@"the Win32VersionValue should be (.*)")]
        public void ThenTheWin32VersionValueShouldBe(UInt32 win32VersionValue)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(win32VersionValue, optionalHeaderWindowsSpecificPE32.Win32VersionValue);
        }

        [Then(@"the SizeOfImage should be (.*)")]
        public void ThenTheSizeOfImageShouldBe(UInt32 sizeOfImage)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfImage, optionalHeaderWindowsSpecificPE32.SizeOfImage);
        }

        [Then(@"the SizeOfHeaders should be (.*)")]
        public void ThenTheSizeOfHeadersShouldBe(UInt32 sizeOfHeaders)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfHeaders, optionalHeaderWindowsSpecificPE32.SizeOfHeaders);
        }

        [Then(@"the CheckSum should be (.*)")]
        public void ThenTheCheckSumShouldBe(string checkSum)
        {
            UInt32 checkSumValue = Convert.ToUInt32(checkSum, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(checkSumValue, optionalHeaderWindowsSpecificPE32.CheckSum);
        }

        [Then(@"the Subsystem should be (.*)")]
        public void ThenTheSubsystemShouldBe(string subsystem)
        {
            UInt16 subsystemValue = Convert.ToUInt16(subsystem, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(subsystemValue, optionalHeaderWindowsSpecificPE32.Subsystem);
        }

        [Then(@"the DllCharacteristics should be (.*)")]
        public void ThenTheDllCharacteristicsShouldBe(string dllCharacteristics)
        {
            UInt16 dllCharacteristicsValue = Convert.ToUInt16(dllCharacteristics, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(dllCharacteristicsValue, optionalHeaderWindowsSpecificPE32.DllCharacteristics);
        }

        [Then(@"the SizeOfStackReserve should be (.*)")]
        public void ThenTheSizeOfStackReserveShouldBe(UInt32 sizeOfStackReserve)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfStackReserve, optionalHeaderWindowsSpecificPE32.SizeOfStackReserve);
        }

        [Then(@"the SizeOfStackCommit should be (.*)")]
        public void ThenTheSizeOfStackCommitShouldBe(UInt32 sizeOfStackCommit)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfStackCommit, optionalHeaderWindowsSpecificPE32.SizeOfStackCommit);
        }

        [Then(@"the SizeOfHeapReserve should be (.*)")]
        public void ThenTheSizeOfHeapReserveShouldBe(UInt32 sizeOfHeapReserve)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfHeapReserve, optionalHeaderWindowsSpecificPE32.SizeOfHeapReserve);
        }

        [Then(@"the SizeOfHeapCommit should be (.*)")]
        public void ThenTheSizeOfHeapCommitShouldBe(UInt32 sizeOfHeapCommit)
        {
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(sizeOfHeapCommit, optionalHeaderWindowsSpecificPE32.SizeOfHeapCommit);
        }

        [Then(@"the LoaderFlags should be (.*)")]
        public void ThenTheLoaderFlagsShouldBe(string loaderFlags)
        {
            UInt32 loaderFlagsValue = Convert.ToUInt32(loaderFlags, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(loaderFlagsValue, optionalHeaderWindowsSpecificPE32.LoaderFlags);
        }

        [Then(@"the NumberOfRvaAndSizes should be (.*)")]
        public void ThenTheNumberOfRvaAndSizesShouldBe(string numberOfRvaAndSizes)
        {
            UInt32 numberOfRvaAndSizesValue = Convert.ToUInt32(numberOfRvaAndSizes, 16);
            var optionalHeaderWindowsSpecificPE32 = ScenarioContext.Current.Get<OptionalHeaderWindowsSpecificPE32>("OptionalHeaderWindowsSpecificPE32");
            Assert.AreEqual(numberOfRvaAndSizesValue, optionalHeaderWindowsSpecificPE32.NumberOfRvaAndSizes);
        }
    }
}
